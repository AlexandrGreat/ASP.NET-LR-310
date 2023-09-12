using LR2;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Configuration.AddJsonFile("appleConfig.json");
var apple = new Company();
app.Configuration.Bind(apple);
builder.Configuration.AddXmlFile("microsoftConfig.xml");
var microsoft = new Company();
app.Configuration.Bind(microsoft);
builder.Configuration.AddIniFile("googleConfig.ini");
var google = new Company();
app.Configuration.Bind(google);

//INTRO
app.MapGet("/", () => "LR2 Kutsev 310");

//TASK1
app.MapGet("/task1", async (context) => {
    await context.Response.WriteAsync($"{apple.Name}: {apple.Workers} workers \n{microsoft.Name}: {microsoft.Workers} workers \n{google.Name}: {google.Workers} workers");
    Company [] companies = new Company[3];
    companies[0] = google;
    companies[1] = apple;
    companies[2] = microsoft;
    int maxWork = companies.Max(x => x.Workers);
    Company result = companies.First(x => x.Workers == maxWork);
    await context.Response.WriteAsync($"\nMaximum workers in {result.Name}");
    });

//TASK2
app.MapGet("/task2", async (context) => {
    builder.Configuration.AddJsonFile("task2.json");
    var alex = new Student();
    app.Configuration.Bind(alex);
    string name = $"Name: {alex.Name}";
    string group = $"Group: {alex.Group}";
    string study = $"University: {alex.Study?.University}";
    string langs = "Programming: ";
    foreach (var lang in alex.ProgramLanguages)
    {
        langs += $"{lang}, ";
    }
    await context.Response.WriteAsync($"\n{name}\n{group}\n{study}\n{langs}");
});
app.Run();