using Core.Entity;
using Core.Input;
using Core.Repository;
using Microsoft.AspNetCore.Mvc;

namespace StoreApi.Controllers
{
	[ApiController]
	[Route("/[controller]")]
	public class LivroController : ControllerBase
	{
		private readonly ILivroRepository _livroRepository;

		public LivroController(ILivroRepository livroRepository)
		{
			_livroRepository = livroRepository;
		}

		[HttpPost]
		public IActionResult Post([FromBody] LivroInput input)
		{
			try
			{
				var livro = new Livro()
				{
					Nome = input.Nome,
					Editora = input.Editora,
				};
				_livroRepository.Cadastrar(livro);

				return Ok();
			}
			catch (Exception e) 
			{ 
				return BadRequest(e);
			}
		}
	}
}
