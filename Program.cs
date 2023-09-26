using LR4;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Welcome to LR4");

app.MapGet("/library", async (context) => {
    await context.Response.WriteAsync($"Hello, Reader! Welcome to our library!"); ;
});

app.MapGet("/library/books", async (context) => {
    builder.Configuration.AddJsonFile("bookList.json");
    Book book = new Book();
    app.Configuration.Bind(book);
    string books = "Books are:";
    foreach (var b in book.Books)
    {
        books += $"\n{b.Author}: \"{b.Name}\"";
    }
    await context.Response.WriteAsync($"{books}");
});

app.MapGet("/library/profile/{id:int:range(0,5)?}", (int?id) => {
    if (id.HasValue)
    {
        builder.Configuration.AddJsonFile("userList.json");
        User user = new User();
        app.Configuration.Bind(user);
        return ($"User info:" +
        $"\nName: {user.Users[id.Value].Name}" +
        $"\nEmail: {user.Users[id.Value].Mail}" +
        $"\nRegistration date: {user.Users[id.Value].RegistrationDate}");
    }
    else 
    {
        builder.Configuration.AddJsonFile("currentUser.json");
        User user = new User();
        app.Configuration.Bind(user);
        return($"Current user info:" +
        $"\nName: {user.Users[0].Name}" +
        $"\nEmail: {user.Users[0].Mail}" +
        $"\nRegistration date: {user.Users[0].RegistrationDate}");
    }
});

app.Run();
