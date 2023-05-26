using Microsoft.AspNetCore.Mvc;

public class RootHandler
{
  public record RootHandlerRequestModel(string Name, int Age);
  public record RootHandlerResponseModel(string Message);

  [Consumes(typeof(RootHandlerRequestModel), "application/json")]
  [Produces(typeof(RootHandlerResponseModel))]
  public static async Task<RootHandlerResponseModel> Process(IPRService pr, [FromBody]RootHandlerRequestModel model)
  {
    return await Task.FromResult(
      new RootHandlerResponseModel("Hello world")
    );
  }
}
