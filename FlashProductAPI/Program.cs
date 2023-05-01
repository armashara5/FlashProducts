using FlashProductAPI.Services.Mapping;
using FlashProductAPI_7.Db;
using FlashProductAPI_7.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

////without mapping to DTO a cycle loop can be generated during the de-serilization of results
//builder.Services.AddControllers().AddJsonOptions(options =>
//    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve
//);

builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnectionToSqlServer")));
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddTransient<IDateTimeProvider, DateTimeProvider>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseExceptionHandler("/error-development");
}
else
{
    app.UseExceptionHandler("/error");
}
app.UseAuthorization();

app.MapControllers();

app.Run();
