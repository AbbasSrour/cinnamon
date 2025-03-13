using System.Text.Json.Serialization;

namespace Cinnamon.Common.Dto;

public abstract class AbstractDto {
  [JsonPropertyOrder(1)]
  [JsonPropertyName("id")]
  public string Id { get; set; }

  [JsonPropertyOrder(2)]
  [JsonPropertyName("createdAt")]
  public DateTime CreatedAt { get; set; }

  [JsonPropertyOrder(3)]
  [JsonPropertyName("updatedAt")]
  public DateTime UpdatedAt { get; set; }
}