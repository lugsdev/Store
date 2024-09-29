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
	}
}
