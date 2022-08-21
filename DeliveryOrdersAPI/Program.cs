using DeliveryOrdersAPI.Domain.Repositories.Abstract;
using DeliveryOrdersAPI.Domain;
using DeliveryOrdersAPI.Domain.Repositories.EntityFramework;
using DeliveryOrdersAPI.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Configuration.Bind("Project", new Config()); //������ ���� ������� �� service\config

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//���������� ������ ���������� ���������� � �������� ��������
builder.Services.AddTransient<IDeliveryOrdersRepository, EFDeliveryOrdersRepository>();

//���������� �������� ��
builder.Services.AddDbContext<AppDbContext>(x =>
x.UseSqlServer(Config.ConnectionString));



var app = builder.Build();

app.UseCors(options =>
options.WithOrigins("http://localhost:3000")
.AllowAnyMethod()
.AllowAnyHeader());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
