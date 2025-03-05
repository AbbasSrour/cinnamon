namespace Cinnamon.Common.Dto;

public abstract class AbstractDto {
    public string Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}