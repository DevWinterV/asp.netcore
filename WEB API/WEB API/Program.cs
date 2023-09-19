using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WEB_API.Models;
using WEB_API.Services.ContactsService;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        // Connect DB
        builder.Services.AddDbContext<ContactContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("RangDongDb"))
        );
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddAutoMapper(typeof(Program).Assembly);
        builder.Services.AddScoped<IContactService, ContactService>();

        // Cấu hình CORS
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowSpecificOrigin",
                builder =>
                {
                    builder.WithOrigins("http://localhost:3000") // Chỉ cho phép các yêu cầu từ origin localhost:3000 này
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        // Sử dụng Cors
        app.UseCors("AllowSpecificOrigin");

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}