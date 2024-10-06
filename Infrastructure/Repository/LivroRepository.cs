using Core.Entity;
using Core.Repository;

namespace Infrastructure.Repository
{
	public class LivroRepository : EFRepository<Livro>, ILivroRepository
	{
		public LivroRepository(ApplicationDbContext context) : base(context)
		{
		}
	}
}
