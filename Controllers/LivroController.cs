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

		[HttpGet]
		public IActionResult Get()
		{
			try
			{
				return Ok(_livroRepository.ObterTodos());
			}
			catch (Exception e)
			{
				return BadRequest(e);
			}
		}

		[HttpGet("{id:int}")]
		public IActionResult Get([FromRoute]int id)
		{
			try
			{
				return Ok(_livroRepository.ObterPorIrd(id));
			}
			catch (Exception e)
			{
				return BadRequest(e);
			}
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

		[HttpPut]
		public IActionResult Put([FromBody] LivroUpdateInput input)
		{
			try
			{
				var livro = _livroRepository.ObterPorIrd(input.Id);
				livro.Nome = input.Nome;
				livro.Editora = input.Editora;

				_livroRepository.Alterar(livro);
				return Ok();
			}
			catch (Exception e)
			{
				return BadRequest(e);
			}
		}

		[HttpDelete("{id:int}")]
		public IActionResult Delete([FromRoute] int id)
		{
			try
			{
				_livroRepository.Excluir(id);
				return Ok();
			}
			catch (Exception e) 
			{ 
				return BadRequest(e);
			}
		}
	}
}
