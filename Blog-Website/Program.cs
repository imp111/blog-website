using Blog_Website.Data;
using Blog_Website.Data.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnention"))); // Database added

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 10;
}
)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddTransient<IRepository, Repository>();

var app = builder.Build();

try
{
    var scope = app.Services.CreateScope();
    var ctx = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>(); // database context
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>(); // manages all the user accounts
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>(); // manages all the roles that you can assign an account to

    ctx.Database.EnsureCreated();

    var adminRole = new IdentityRole("Admin");
    if (!ctx.Roles.Any())
    {
        // create a role
        roleManager.CreateAsync(adminRole);
    }

    if (!ctx.Users.Any(u => u.UserName == "Admin"))
    {
        // create admin user
        var adminUser = new IdentityUser { UserName = "admin", Email = "admin@test.com" };

        string password = "praseta123";
        userManager.CreateAsync(adminUser, password);

        // add role to user
        userManager.AddToRoleAsync(adminUser, adminRole.Name);
    }

}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();