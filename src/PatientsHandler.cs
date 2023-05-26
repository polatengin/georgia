using Microsoft.AspNetCore.Mvc;

public class PatientsHandler
{
  public record PatientsHandlerRequestModel(string Name);
  public record PatientsHandlerResponseModel(string Message, DateTime CreatedAt, bool Success = true);

  [Produces(typeof(PatientsHandlerResponseModel))]
  [EndpointSummary("Get a hello message for patients summary")]
  [EndpointDescription("Get a hello message for patients description")]
  public static async Task<PatientsHandlerResponseModel> Process(IPRService pr)
  {
    var currentUser = pr.GetCurrentuser();
    var ipAddress = pr.GetClientIpAddress();
    var model = await pr.GetRequestModel<PatientsHandlerRequestModel>();
    var db = await pr.GetDataBase();

    return await Task.FromResult(
      new PatientsHandlerResponseModel($"Hello patient {model.Name} from {ipAddress}", DateTime.UtcNow)
    );
  }
}
