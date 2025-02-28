using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Online_Exam_System.Bl;
using Online_Exam_System.Bl.Interfaces;
using Online_Exam_System.Bl.Repositories;
using Online_Exam_System.Models;
using Online_Exam_System.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ExamContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));//to get connect sql in app.json
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(
    options =>
    {
        //options.SignIn.RequireConfirmedAccount = true;
        options.Password.RequiredLength = 8;
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequireUppercase = true;
        options.User.RequireUniqueEmail = true;
    }).AddEntityFrameworkStores<ExamContext>().AddDefaultTokenProviders();




builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IExam, ClsExams>();
builder.Services.AddScoped<IQuestion, ClsQuestions>();






// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
    name: "admin",
    pattern: "{area:exists}/{controller=Home}/{action=Index}");


    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");




}
);
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");
//app.MapAreaControllerRoute(
//    name: "Areas",
//    areaName: "Admin",
//    pattern: "Admin/{controller=Home}/{action=Index}"
//);

app.Run();
