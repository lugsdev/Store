namespace Core.Entity
{
	public class Cliente : EntityBase
	{
        public required string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public required string Cpf { get; set; }

        public ICollection<Pedido> Pedidos { get; set; }
    }
}
