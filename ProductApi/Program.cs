using Microsoft.EntityFrameworkCore;
using ProductApi.Context;
using ProductApi.DAL;
using ProductApi.Service;

namespace ProductApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<ProductService>();
            builder.Services.AddScoped<IProductRepo, ProductRepo>();
            var dbHost = Environment.GetEnvironmentVariable("DB_HOST");

            var dbName = Environment.GetEnvironmentVariable("DB_NAME");
            var dbPassword = Environment.GetEnvironmentVariable("DB_MSSQL_SA_PASSWORD");
            var connectiontString = $"server={dbHost};database={dbName};user id=sa;password={dbPassword};TrustServerCertificate=True";
            builder.Services.AddDbContext<ProductDbContext>(op => op.UseSqlServer(builder.Configuration["ConnectionStrings:MyC"]));
            //builder.Services.AddDbContext<ProductDbContext>(op => op.UseSqlServer(connectiontString));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<ProductDbContext>();
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }
            }
            app.Run();
        }
    }
}