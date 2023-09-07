using LR1;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//INTRO
app.MapGet("/", () => "LR1 Kutsev 310");

//TASK 1
app.MapGet("/task1", async (context) =>
{
    Company company = new Company();
    company.Name = "Google";
    company.Workers = 187000;
    await context.Response.WriteAsync($"{company.GetInfo()}");
});

//TASK 2
app.MapGet("/task2", async (context) =>
{
    Random rnd = new Random();
    int result = rnd.Next(1, 101);
    await context.Response.WriteAsync($"Random number: {result}");
});

app.Run(); 