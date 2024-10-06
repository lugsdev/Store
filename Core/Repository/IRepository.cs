using Core.Entity;

namespace Core.Repository
{
	public interface IRepository<T> where T : EntityBase
	{
		IList<T> ObterTodos();
		T ObterPorIrd(int id);
		void Cadastrar(T entidade);
		void Alterar(T entidade);
		void Excluir(int id);
	}
}
