using Microsoft.AspNetCore.Mvc;

public class PatientsHandler
{
  public record PatientsHandlerRequestModel(string Name);
  public record PatientsHandlerResponseModel(string Message, DateTime CreatedAt, bool Success = true);

  [Produces(typeof(PatientsHandlerResponseModel))]
  [EndpointSummary("Get a hello message for patients summary")]
  [EndpointDescription("Get a hello message for patients description")]
  public static async Task<PatientsHandlerResponseModel> Process(IBaseService service)
  {
    var currentUser = service.GetCurrentuser();
    var ipAddress = service.GetClientIpAddress();
    var model = await service.GetRequestModel<PatientsHandlerRequestModel>();
    var db = await service.GetDataBase();

    return await Task.FromResult(
      new PatientsHandlerResponseModel($"Hello patient {model.Name} from {ipAddress}", DateTime.UtcNow)
    );
  }
}
