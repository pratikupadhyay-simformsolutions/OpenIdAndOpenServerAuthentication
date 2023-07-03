using Microsoft.IdentityModel.Logging;

var builder = WebApplication.CreateBuilder(args);
IdentityModelEventSource.ShowPII = true; //Add this line

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "cookie";
    options.DefaultChallengeScheme = "oidc";
})
           .AddCookie("cookie")
           .AddOpenIdConnect("oidc", options =>
           {
               options.Authority = "https://localhost:7161";
               options.ClientId = "oidcMVCApp";
               options.ClientSecret = "IdentityServer";

               options.ResponseType = "code";
               options.UsePkce = true;
               options.ResponseMode = "query";

               options.Scope.Add("weatherApi.read");
               options.SaveTokens = true;
           });

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
