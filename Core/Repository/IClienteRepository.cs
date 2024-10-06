using Core.Entity;

namespace Core.Repository
{
	public interface IClienteRepository: IRepository<Cliente>
	{
		Cliente ObterPorData(int id, string dataInicio, string dataFim);
	}
}
