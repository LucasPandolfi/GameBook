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
            Id_Quadro = idQuadro;
            Id_Jogo = idJogo;
            Fl_Ativo = ativo;
            Dt_Criacao = criacao;
            Dt_UltimaAlteracao = ultimaAlteracao;
            Ds_Responsavel = responsavel;
        }

        public int Id { get; set; }
        public int Id_Quadro { get; set; }
        public int Id_Jogo { get; set; }
        public bool Fl_Ativo { get; set; }
        public DateTime Dt_Criacao { get; set; }
        public DateTime? Dt_UltimaAlteracao { get; set; }
        public string Ds_Responsavel { get; set; }
    }
}
