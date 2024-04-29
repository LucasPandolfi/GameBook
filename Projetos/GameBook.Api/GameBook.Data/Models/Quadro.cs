namespace GameBook.Data.Models
{
    public class Quadro
    {
        public Quadro() { }

        public Quadro(string nome, int idUsuario, int idCategoriaQuadro, bool ativo, DateTime criacao, DateTime? ultimaAlteracao, string responsavel)
        {
            Nm_Quadro = nome;
            Id_Usuario = idUsuario;
            Id_CategoriaQuadro = idCategoriaQuadro;
            Fl_Ativo = ativo;
            Dt_Criacao = criacao;
            Dt_UltimaAlteracao = ultimaAlteracao;
            Ds_Responsavel = responsavel;
        }

        public int Id { get; set; }
        public string Nm_Quadro { get; set; }
        public int Id_Usuario { get; set; }
        public int Id_CategoriaQuadro { get; set; }
        public bool Fl_Ativo { get; set; }
        public DateTime Dt_Criacao { get; set; }
        public DateTime? Dt_UltimaAlteracao { get; set; }
        public string Ds_Responsavel { get; set; }
    }
}
