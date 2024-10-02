using Core.Repository;
using Microsoft.AspNetCore.Mvc;


namespace StoreApi.Controllers
{
	[ApiController]
	[Route("/[controller]")]
	public class ClienteController : ControllerBase
	{
		private readonly IClienteRepository _clienteRepository;

		public ClienteController(IClienteRepository clienteRepository)
		{
			_clienteRepository = clienteRepository;
		}

		[HttpGet]
		public IActionResult Get()
		{
			try
			{
				return Ok(_clienteRepository.ObterTodos());
			}
			catch (Exception e)
			{
				return BadRequest(e);
			}
		}

		[HttpGet("{id:int}/{dataInicio}/{dataFim}")]
		public IActionResult Get([FromRoute]int id, string dataInicio, string dataFim)
		{
			try
			{
				return Ok(_clienteRepository.ObterPorData(id, dataInicio, dataFim));
			}
			catch (Exception e)
			{
				return BadRequest(e);
			}
		}
	}
}
