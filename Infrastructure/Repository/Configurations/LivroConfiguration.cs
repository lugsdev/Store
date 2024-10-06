using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Configurations
{
	public class LivroConfiguration : IEntityTypeConfiguration<Livro>
	{
		public void Configure(EntityTypeBuilder<Livro> builder)
		{

			builder.ToTable(("Livro"));
			builder.HasKey(p => p.Id);
			builder.Property(p => p.Id).HasColumnType("INT").UseIdentityColumn();
			builder.Property(p => p.DataCriacao).HasColumnType("DATETIME").IsRequired();
			builder.Property(p => p.Nome).HasColumnType("VARCHAR(100)").IsRequired();
			builder.Property(p => p.Editora).HasColumnType("VARCHAR(100)").IsRequired();

		}
	}
}
