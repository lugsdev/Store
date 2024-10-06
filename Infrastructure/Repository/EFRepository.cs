using Core.Entity;
using Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
	public class EFRepository<T> : IRepository<T> where T : EntityBase
	{
		protected ApplicationDbContext _context;
		protected DbSet<T> _dbSet;

		public EFRepository(ApplicationDbContext context)
		{
			_context = context;
			_dbSet = _context.Set<T>();
		}

		public void Alterar(T entidade)
		{
			_dbSet.Update(entidade);
			_context.SaveChanges();
		}

		public void Cadastrar(T entidade)
		{
			entidade.DataCriacao = DateTime.Now;

			_dbSet.Add(entidade);
			_context.SaveChanges();
		}

		public void Excluir(int id)
		{
			_dbSet.Remove(ObterPorIrd(id));
			_context.SaveChanges();
		}

		public T ObterPorIrd(int id)
		{
			return _dbSet.FirstOrDefault(entity => entity.Id == id);
		}

		public IList<T> ObterTodos()
		{
			return _dbSet.ToList();
		}
	}
}
