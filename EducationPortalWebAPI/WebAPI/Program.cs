
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<SqlDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IEducationDal, EfEducationDal>();
builder.Services.AddScoped<IEducationService, EducationManager>();

builder.Services.AddScoped<ITrainerDal, EfTrainerDal>();
builder.Services.AddScoped<ITrainerService, TrainerManager>();

builder.Services.AddScoped<IMemberDal, EfMemberDal>();
builder.Services.AddScoped<IMemberService, MemberManager>();

builder.Services.AddScoped<IUsersDal, EfUsersDal>();
builder.Services.AddScoped<IUsersService, UsersManager>();

builder.Services.AddScoped<ISourceDal, EfSourceDal>();
builder.Services.AddScoped<ISourceService, SourceManager>();

builder.Services.AddScoped<PasswordTransaction>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
