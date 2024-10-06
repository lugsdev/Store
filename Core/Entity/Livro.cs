namespace Core.Entity
{
	public class Livro : EntityBase
	{
		public required string Nome { get; set; }
        public required string Editora { get; set; }

        public ICollection<Pedido> Pedidos { get; set; }
    }
}
