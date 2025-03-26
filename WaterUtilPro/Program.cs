using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.OpenApi.Models;
using WaterUtilPro.Data;
using WaterUtilPro.Extensions;
using WaterUtilPro.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterRepos();
builder.Services.RegisterAuth(builder.Configuration);

builder.Services.AddRazorPages();
builder.Services.AddControllers(config =>
{
    var policy = new AuthorizationPolicyBuilder()
                     .RequireAuthenticatedUser()
                     .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});
builder.Services.AddFluentValidationAutoValidation();
builder.WebHost.UseStaticWebAssets();

builder.Services.AddMvc(o =>
{
    //Add Authentication to all Controllers by default.
    //var policy = new AuthorizationPolicyBuilder()
    //    .RequireAuthenticatedUser()
    //    .Build();
    //o.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Restaurant Planner", Version = "v1" });
    c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
    {
        Description = "ApiKey must appear in header",
        Type = SecuritySchemeType.ApiKey,
        Name = "XApiKey",
        In = ParameterLocation.Header,
        Scheme = "ApiKeyScheme"
    });
    var key = new OpenApiSecurityScheme()
    {
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "ApiKey"
        },
        In = ParameterLocation.Header
    };
    var requirement = new OpenApiSecurityRequirement
                    {
                             { key, new List<string>() }
                    };
    c.AddSecurityRequirement(requirement);
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var userManager = (UserManager<ApplicationUser>?)scope.ServiceProvider.GetService(typeof(UserManager<ApplicationUser>));

    var roleManager = (RoleManager<IdentityRole>?)scope.ServiceProvider.GetRequiredService(typeof(RoleManager<IdentityRole>));


    await IdentitySeed.SeedRolesAsync(userManager!, roleManager!);
    await IdentitySeed.SeedSuperAdminAsync(userManager!, roleManager!);
    await IdentitySeed.SeedBasicUserAsync(userManager!, roleManager!);
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
//app.UseMiddleware<ApiKeyMiddleware>();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Restaurant Planner API");
    });
}

app.Run();
