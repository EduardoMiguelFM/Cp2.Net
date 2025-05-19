using System.IO;

namespace Mottu.Domain.Entities
{
    public enum MotoStatus { DISPONIVEL, MANUTENCAO, INDISPONIVEL, SINISTRO }

    public class Moto
    {
        public int Id { get; private set; }
        public string Modelo { get; private set; }
        public string Placa { get; private set; }
        public MotoStatus Status { get; private set; }

        public int PatioId { get; private set; }
        public Patio Patio { get; private set; }

        public Moto(string modelo, string placa, MotoStatus status, int patioId)
        {
            Modelo = modelo;
            Placa = placa;
            Status = status;
            PatioId = patioId;
        }

        public void Atualizar(string modelo, string placa, MotoStatus status, int patioId)
        {
            Modelo = modelo;
            Placa = placa;
            AtualizarStatus(status);
            PatioId = patioId;
        }

        public void AtualizarStatus(MotoStatus novoStatus)
        {
            if (Status == MotoStatus.SINISTRO && novoStatus != MotoStatus.SINISTRO)
                throw new InvalidOperationException("Moto sinistrada não pode mudar de status.");
            Status = novoStatus;
        }
    }
}