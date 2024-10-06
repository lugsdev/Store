using Core.Entity;
using Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
	public class ClienteRepository : EFRepository<Cliente>, IClienteRepository
	{

		public ClienteRepository(ApplicationDbContext context) : base(context)
		{
		}

		public Cliente ObterPorData(int id, string dataInicio, string dataFim)
		{
			if (!DateTime.TryParse(dataInicio, out DateTime dataInicioParsed) || !DateTime.TryParse(dataFim, out DateTime dataFimParsed))
			{
				throw new Exception("Formato de data inválida.");
			}

			var cliente = _context.Cliente
				.Include(c => c.Pedidos)
				.ThenInclude(p => p.Livro)
				.FirstOrDefault(c => c.Id == id)
				?? throw new Exception("Cliente não existe.");

			cliente.Pedidos = cliente.Pedidos
				.Where(c => c.DataCriacao >= dataInicioParsed 
						 && c.DataCriacao <= dataFimParsed)
				.Select(p =>
				{
					p.Cliente = null;
					p.Livro.Pedidos = null;
					return p;
				})
				.ToList();

			return cliente;
		}
	}
}
