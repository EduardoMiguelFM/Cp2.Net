namespace Mottu.Domain.Entities
{
    public class Patio
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Setor { get; private set; }
        public ICollection<Moto> Motos { get; private set; }

        public Patio(string nome, string setor)
        {
            Nome = nome;
            Setor = setor;
            Motos = new List<Moto>();
        }
    }
}