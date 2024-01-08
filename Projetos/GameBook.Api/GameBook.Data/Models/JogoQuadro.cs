using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBook.Data.Models
{
    public class JogoQuadro
    {
        public JogoQuadro() { }

        public JogoQuadro(int idQuadro, int idJogo, bool ativo, DateTime criacao, DateTime? ultimaAlteracao, string responsavel)
        {
            IdQuadro = idQuadro;
            IdJogo = idJogo;
            Ativo = ativo;
            Criacao = criacao;
            UltimaAlteracao = ultimaAlteracao;
            Responsavel = responsavel;
        }

        public int Id { get; set; }
        public int IdQuadro { get; set; }
        public int IdJogo { get; set; }
        public bool Ativo { get; set; }
        public DateTime Criacao { get; set; }
        public DateTime? UltimaAlteracao { get; set; }
        public string Responsavel { get; set; }
    }
}
