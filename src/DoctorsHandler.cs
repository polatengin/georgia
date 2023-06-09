using Microsoft.AspNetCore.Mvc;

public class DoctorsHandler
{
  public record DoctorsHandlerRequestModel(string Name);
  public record DoctorsHandlerResponseModel(string Message, DateTime CreatedAt, bool Success = true);

  [ProducesResponseType(StatusCodes.Status201Created)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [Produces(typeof(DoctorsHandlerResponseModel))]
  [Consumes(typeof(DoctorsHandlerRequestModel), "application/json")]
  [EndpointSummary("Get a hello message for doctors summary")]
  [EndpointDescription("Get a hello message for doctors description")]
  public static async Task<DoctorsHandlerResponseModel> Process(IBaseService service, [FromBody]DoctorsHandlerRequestModel model)
  {
    var currentUser = service.GetCurrentuser();
    var ipAddress = service.GetClientIpAddress();

    return await Task.FromResult(
      new DoctorsHandlerResponseModel($"Hello doctor {model.Name} from {ipAddress}", DateTime.UtcNow)
    );
  }
}
