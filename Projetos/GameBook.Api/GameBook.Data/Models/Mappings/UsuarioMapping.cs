using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameBook.Data.Models.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.Property(t => t.Id).HasColumnName("Id");
            builder.Property(t => t.Nome).HasColumnName("Nm_Usuario");
            builder.Property(t => t.Documento).HasColumnName("Ds_Documento");
            builder.Property(t => t.Email).HasColumnName("Ds_Email");
            builder.Property(t => t.Ativo).HasColumnName("Fl_Ativo");
            builder.Property(t => t.Criacao).HasColumnName("Dt_Criacao");
            builder.Property(t => t.UltimaAlteracao).HasColumnName("Dt_UltimaAlteracao");
            builder.Property(t => t.Responsavel).HasColumnName("Ds_Responsavel");
        }
    }
}
