using Mottu.Domain.Entities;

public class Patio
{
    public int Id { get; set; }
    public required string Nome { get; set; }
    public ICollection<Moto> Motos { get; set; } = new List<Moto>();   
    public ICollection<UsuarioPatio> Usuarios { get; set; } = new List<UsuarioPatio>();
}