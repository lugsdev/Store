using System.Reflection.Metadata.Ecma335;

namespace Core.Entity
{
	public class Pedido : EntityBase
	{
		public int ClienteId { get; set; }
        public int LivroId { get; set; }

        public Cliente Cliente { get; set; }
        public Livro Livro { get; set; }

    }
}
