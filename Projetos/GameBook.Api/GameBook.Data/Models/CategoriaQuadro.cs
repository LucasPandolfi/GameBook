namespace GameBook.Data.Models
{
    public class CategoriaQuadro
    {
        public CategoriaQuadro() { }

        public CategoriaQuadro(string nome, bool ativo, DateTime criacao, DateTime? ultimaAlteracao, string responsavel)
        {
            Nm_CategoriaQuadro = nome;
            Fl_Ativo = ativo;
            Dt_Criacao = criacao;
            Dt_UltimaAlteracao = ultimaAlteracao;
            Ds_Responsavel = responsavel;
        }

        public int Id { get; set; }
        public string Nm_CategoriaQuadro { get; set; }
        public bool Fl_Ativo { get; set; }
        public DateTime Dt_Criacao { get; set; }
        public DateTime? Dt_UltimaAlteracao { get; set; }
        public string Ds_Responsavel { get; set; }
    }
}
