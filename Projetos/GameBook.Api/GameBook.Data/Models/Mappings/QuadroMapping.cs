using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GameBook.Data.Models.Mappings
{
    public class QuadroMapping : IEntityTypeConfiguration<Quadro>
    {
        public void Configure(EntityTypeBuilder<Quadro> builder)
        {
            builder.ToTable("Usuario");
            builder.Property(t => t.Id).HasColumnName("Id");
            builder.Property(t => t.Nome).HasColumnName("Nm_Quadro");
            builder.Property(t => t.IdUsuario).HasColumnName("Id_Usuario");
            builder.Property(t => t.IdCategoriaQuadro).HasColumnName("Id_CategoriaQuadro");
            builder.Property(t => t.Ativo).HasColumnName("Fl_Ativo");
            builder.Property(t => t.Criacao).HasColumnName("Dt_Criacao");
            builder.Property(t => t.UltimaAlteracao).HasColumnName("Dt_UltimaAlteracao");
            builder.Property(t => t.Responsavel).HasColumnName("Ds_Responsavel");
        }
    }
}
