using LR3;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<CalcService>();
builder.Services.AddTransient<TimeService>();
var app = builder.Build();

//INTRO
app.MapGet("/", () => "Welcome to LR3");

//TASK 1
double a = 4, b = 5;
app.MapGet("/task1", async (context) => 
{
    var calcService = app.Services.GetService<CalcService>();
    await context.Response.WriteAsync($"Sum: {a}+{b}={calcService?.Plus(a,b)}\n" +
        $"Dif: {a}-{b}={calcService?.Minus(a, b)}\n" +
        $"Mul: {a}*{b}={calcService?.Multiply(a, b)}\n" +
        $"Div: {a}/{b}={calcService?.Divide(a, b)}\n");
});

//TASK 2
app.MapGet("/task2", async (context) => 
{
    var timeService = app.Services.GetService<TimeService>();
    await context.Response.WriteAsync($"{timeService?.GetDayTime()}");
});

app.Run();
