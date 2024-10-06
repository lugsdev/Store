using Core.Entity;
using Core.Repository;

namespace Infrastructure.Repository
{
	public class PedidoRepository : EFRepository<Pedido>, IPedidoRepository
	{
		public PedidoRepository(ApplicationDbContext context) : base(context)
		{
		}
	}
}
