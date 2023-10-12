using LR5;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "logger.txt"));

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

app.MapGet("/ErrorLoggerPage", async (context) =>
{
    app.Logger.LogInformation($"Path: {context.Request.Path} Time:{DateTime.Now.ToLongTimeString()} Sudden Exception has occured! U r not lucky today :(");
    await context.Response.WriteAsync("Sudden exception has occured.\nCheck logger for more info");
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
