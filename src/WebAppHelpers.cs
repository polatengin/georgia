using System.Text.Json;
using Microsoft.OpenApi.Models;

public class WebAppHelpers
{
  public static WebApplication Start(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddHttpContextAccessor();
    builder.Services.AddSingleton<IBaseService, BaseService>();

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();

    builder.Services.AddSwaggerGen(c =>
    {
      c.SwaggerDoc("v1", new OpenApiInfo
      {
        Title = "Web API Documentation",
        Version = "v1",
        Contact = new OpenApiContact
        {
          Name = "Contact Information",
          Url = new Uri("https://sample.com/contact")
        },
        License = new OpenApiLicense
        {
          Name = "License",
          Url = new Uri("https://sample.com/license")
        }
      });
    });

    var app = builder.Build();

    app.UseSwagger();
    app.UseSwaggerUI();

    return app;
  }
}

public class BaseUser
{
}

public class DataContext
{
}

public interface IBaseService
{
  BaseUser GetCurrentuser();
  string GetClientIpAddress();
  Task<T> GetRequestModel<T>();
  Task<DataContext> GetDataBase();
}

public class BaseService : IBaseService
{
  private readonly IHttpContextAccessor _httpContextAccessor;

  public BaseService(IHttpContextAccessor httpContextAccessor)
  {
    _httpContextAccessor = httpContextAccessor;
  }

  public BaseUser GetCurrentuser()
  {
    return new BaseUser();
  }

  public string GetClientIpAddress()
  {
    return _httpContextAccessor.HttpContext?.Connection.RemoteIpAddress?.ToString() ?? string.Empty;
  }

  public async Task<T> GetRequestModel<T>()
  {
    var request = _httpContextAccessor.HttpContext?.Request;
    if (request == null)
    {
      return default(T);
    }
    using var streamReader = new StreamReader(request.Body);
    var requestBody = await streamReader.ReadToEndAsync();
    return JsonSerializer.Deserialize<T>(requestBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
  }

  public async Task<DataContext> GetDataBase()
  {
    return await Task.FromResult(new DataContext());
  }
}
