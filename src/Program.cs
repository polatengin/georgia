var app = Helpers.Start(args);

app.MapPost("/", RootHandler.Process).WithOpenApi();
app.MapPost("/doctors", DoctorsHandler.Process).WithOpenApi();
app.MapPost("/patients", PatientsHandler.Process).WithOpenApi();

app.Run();
