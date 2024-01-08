using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GameBook.Data.Models.Mappings
{
    internal class CategoriaQuadroMapping : IEntityTypeConfiguration<CategoriaQuadro>
    {
        public void Configure(EntityTypeBuilder<CategoriaQuadro> builder)
        {
            builder.ToTable("Usuario");
            builder.Property(t => t.Id).HasColumnName("Id");
            builder.Property(t => t.Nome).HasColumnName("Nm_CategoriaQuadro");
            builder.Property(t => t.Ativo).HasColumnName("Fl_Ativo");
            builder.Property(t => t.Criacao).HasColumnName("Dt_Criacao");
            builder.Property(t => t.UltimaAlteracao).HasColumnName("Dt_UltimaAlteracao");
            builder.Property(t => t.Responsavel).HasColumnName("Ds_Responsavel");
        }
    }
}
