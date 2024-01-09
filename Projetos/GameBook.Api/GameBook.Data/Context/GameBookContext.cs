using GameBook.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GameBook.Data.Context
{
    public class GameBookContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Arrumar essa conexão, colocar ele em um XML parecido com o da MAC
            // Configurar a string de conexão aqui
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-EEROL80;Initial Catalog=GameBook;Integrated Security=true; Encrypt=False;");
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<CategoriaQuadro> CategoriaQuadro { get; set; }
        public DbSet<Quadro> Quadro { get; set; }
        public DbSet<JogoQuadro> JogoQuadro { get; set; }
    }
}
