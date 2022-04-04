using RestaurantPlanner.Data;
using RestaurantPlanner.Extensions;
using RestaurantPlanner.Models;
using Microsoft.AspNetCore.Identity;
using NToastNotify;
using RestaurantPlanner.Apis;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterRepos();
builder.Services.RegisterAuth(builder.Configuration);

builder.Services.AddRazorPages();
builder.Services.AddMvc(o =>
{
    //Add Authentication to all Controllers by default.
    //var policy = new AuthorizationPolicyBuilder()
    //    .RequireAuthenticatedUser()
    //    .Build();
    //o.Filters.Add(new AuthorizeFilter(policy));
}).AddNToastNotifyToastr(new ToastrOptions()
{
    ProgressBar = false,
    PositionClass = ToastPositions.BottomCenter
});

builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var userManager = (UserManager<ApplicationUser>?)scope.ServiceProvider.GetService(typeof(UserManager<ApplicationUser>));

    var roleManager = (RoleManager<IdentityRole>?)scope.ServiceProvider.GetRequiredService(typeof(RoleManager<IdentityRole>));


    await IdentitySeed.SeedRolesAsync(userManager, roleManager);
    await IdentitySeed.SeedSuperAdminAsync(userManager, roleManager);
    await IdentitySeed.SeedBasicUserAsync(userManager, roleManager);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();


//app.MapRazorPages();
app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
    endpoints.MapRazorPages(); // This one!
});

app.ConfigureApi();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.Run();