using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Repository.Configurations
{
	public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
	{
		public void Configure(EntityTypeBuilder<Cliente> builder)
		{

			builder.ToTable(("Cliente"));
			builder.HasKey(p => p.Id);
			builder.Property(p => p.Id).HasColumnType("INT").UseIdentityColumn();
			builder.Property(p => p.DataCriacao).HasColumnType("DATETIME").IsRequired();
			builder.Property(p => p.Nome).HasColumnType("VARCHAR(100)").IsRequired();
			builder.Property(p => p.DataNascimento).HasColumnType("DATETIME");
			builder.Property(p => p.Cpf).HasColumnType("VARCHAR(14)").IsRequired();

		}
	}
}
