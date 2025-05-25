using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mottu.Domain.Entities
{
    public enum MotoStatus
    {
        DISPONIVEL,
        RESERVADA,
        INDISPONIVEL,
        MANUTENCAO,
        FALTA_PECA,
        DANOS_ESTRUTURAIS,
        SINISTRO
    }

    public class Moto
    {
        public int Id { get; set; }
        public required string Modelo { get; set; }
        public required string Placa { get; set; }
        public MotoStatus Status { get; set; } = MotoStatus.DISPONIVEL;
        public int PatioId { get; set; }
        public required Patio Patio { get; set; }
        public string Setor => DefinirSetorPorStatus(Status);
        public string Cor => DefinirCorPorStatus(Status);
        public string NomePatio => Patio?.Nome ?? "";

        private string DefinirSetorPorStatus(MotoStatus status) => status switch
        {
            MotoStatus.DISPONIVEL => "Setor A",
            MotoStatus.RESERVADA => "Setor B",
            MotoStatus.MANUTENCAO => "Setor C",
            MotoStatus.FALTA_PECA => "Setor D",
            MotoStatus.INDISPONIVEL => "Setor E",
            MotoStatus.DANOS_ESTRUTURAIS => "Setor F",
            MotoStatus.SINISTRO => "Setor G",
            _ => "Indefinido"
        };

        private string DefinirCorPorStatus(MotoStatus status) => status switch
        {
            MotoStatus.DISPONIVEL => "Verde",
            MotoStatus.RESERVADA => "Azul",
            MotoStatus.MANUTENCAO => "Amarelo",
            MotoStatus.FALTA_PECA => "Laranja",
            MotoStatus.INDISPONIVEL => "Cinza",
            MotoStatus.DANOS_ESTRUTURAIS => "Vermelho",
            MotoStatus.SINISTRO => "Preto",
            _ => "Indefinida"
        };
    }
}