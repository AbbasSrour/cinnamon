using FluentResults.Extensions.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace Cinnamon.Common.Config;

public class ResultEndpointProfile : DefaultAspNetCoreResultEndpointProfile {
  public override ActionResult TransformFailedResultToActionResult(
    FailedResultToActionResultTransformationContext context
  ) {
    return new ObjectResult(context.Result.Errors.ToList());
  }
}