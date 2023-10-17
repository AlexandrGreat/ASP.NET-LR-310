var builder = WebApplication.CreateBuilder(args);

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

app.MapGet("/ErrorAgePage", async (context) =>
{ 
    await context.Response.WriteAsync("You have to be at least 16 years old to make an order");
});

app.MapGet("/ErrorCountPage", async (context) =>
{
    await context.Response.WriteAsync("You have to order at least 1 item");
});

app.MapGet("/ErrorPage", async (context) =>
{
    await context.Response.WriteAsync("Something went wrong");
});

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
