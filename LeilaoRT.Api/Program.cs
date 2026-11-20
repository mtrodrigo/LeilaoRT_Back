using LeilaoRT.Api.Data;
using LeilaoRT.Api.Services;
using LeilaoRT.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LeilaoRT.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddOpenApi();
            builder.Services.AddScoped<IAuctionService, AuctionService>();
            builder.Services.AddScoped<IItemService, ItemService>();
            builder.Services.AddScoped<IItemCostService, ItemCostService>();
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddSwaggerGen();

            var app = builder.Build();


            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.MapControllers();

            app.Run();
        }
    }
}
