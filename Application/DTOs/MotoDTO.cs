using System.Text.Json.Serialization;

namespace Mottu.Application.DTOs
{
    public class MotoDTO
    {
        public int Id { get; set; }
        public required string Modelo { get; set; }
        public required string Placa { get; set; }
        public required string Status { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? PatioId { get; set; }

        public required string NomePatio { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Setor { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Cor { get; set; }
    }
}