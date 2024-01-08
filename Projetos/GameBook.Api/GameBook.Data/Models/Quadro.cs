namespace GameBook.Data.Models
{
    public class Quadro
    {
        public Quadro() { }

        public Quadro(string nome, int idUsuario, int idCategoriaQuadro, bool ativo, DateTime criacao, DateTime? ultimaAlteracao, string responsavel)
        {
            Nome = nome;
            IdUsuario = idUsuario;
            IdCategoriaQuadro = idCategoriaQuadro;
            Ativo = ativo;
            Criacao = criacao;
            UltimaAlteracao = ultimaAlteracao;
            Responsavel = responsavel;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int IdUsuario { get; set; }
        public int IdCategoriaQuadro { get; set; }
        public bool Ativo { get; set; }
        public DateTime Criacao { get; set; }
        public DateTime? UltimaAlteracao { get; set; }
        public string Responsavel { get; set; }
    }
}
