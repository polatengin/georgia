var app = Helpers.Start(args);

app.MapPost("/", RootHandler.Process).WithOpenApi();

app.Run();
