var app = Helpers.Start(args);

app.MapPost("/", RootHandler.Process).WithOpenApi();
app.MapPost("/doctors", DoctorsHandler.Process).WithOpenApi();

app.Run();
