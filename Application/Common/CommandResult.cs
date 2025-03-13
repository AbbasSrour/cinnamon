namespace Application.Common;

public class CommandResult {
  // public IEnumerable<Error> Errors { get; set; }

  public CommandResult(bool success) {
    Success = success;
  }

  public bool Success { get; set; }

  // public CommandResult(IEnumerable<JSType.Error> errors) {
  //     Success = false;
  //     Errors = errors;
  // }
}