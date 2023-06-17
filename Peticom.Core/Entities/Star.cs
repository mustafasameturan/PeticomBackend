using System.Text.Json.Serialization;

namespace Peticom.Core.Entities;

public class Star : BaseEntity
{
    public string UserId { get; set; }
    public Guid AdId { get; set; }
    public int StarCount { get; set; }
    [JsonIgnore]
    public Ad Ad { get; set; }
}