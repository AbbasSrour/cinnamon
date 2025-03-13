using System.Text.Json.Serialization;
using FluentResults.Extensions.AspNetCore;

namespace Cinnamon.Common.Dto;

public class SystemErrorDto : IErrorDto {
  public SystemErrorDto(string message, string? code, List<IErrorDto> reasons) {
    Message = message;
    Code = code;
    Reasons = reasons;
  }

  [JsonPropertyName("code")] public string? Code { get; }

  [JsonPropertyName("reasons")] public List<IErrorDto> Reasons { get; }

  [JsonPropertyName("message")] public string Message { get; set; }
}