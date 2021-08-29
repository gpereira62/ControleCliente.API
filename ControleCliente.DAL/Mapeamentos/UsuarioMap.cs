using ControleCliente.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCliente.DAL.Mapeamentos
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
			builder.HasKey(u => u.UsuarioId);

            builder.Property(u => u.Login).IsRequired().HasMaxLength(20);
            builder.Property(u => u.Senha).IsRequired().HasMaxLength(20);

            builder.ToTable("Usuarios");
        }
    }
}
