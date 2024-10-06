using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Input
{
	public class LivroUpdateInput
	{
		public int Id { get; set; }
		public required string Nome { get; set; }
		public required string Editora { get; set; }
	}
}
