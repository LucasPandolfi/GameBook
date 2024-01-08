using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GameBook.Data.Models.Mappings
{
    public class JogoQuadroMapping : IEntityTypeConfiguration<JogoQuadro>
    {
        public void Configure(EntityTypeBuilder<JogoQuadro> builder)
        {
            builder.ToTable("Usuario");
            builder.Property(t => t.Id).HasColumnName("Id");
            builder.Property(t => t.IdQuadro).HasColumnName("Id_Quadro");
            builder.Property(t => t.IdJogo).HasColumnName("Id_Jogo");
            builder.Property(t => t.Ativo).HasColumnName("Fl_Ativo");
            builder.Property(t => t.Criacao).HasColumnName("Dt_Criacao");
            builder.Property(t => t.UltimaAlteracao).HasColumnName("Dt_UltimaAlteracao");
            builder.Property(t => t.Responsavel).HasColumnName("Ds_Responsavel");
        }
    }
}
