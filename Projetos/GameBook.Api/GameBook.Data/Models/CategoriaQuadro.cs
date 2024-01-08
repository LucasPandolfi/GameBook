namespace GameBook.Data.Models
{
    public class CategoriaQuadro
    {
        public CategoriaQuadro() { }

        public CategoriaQuadro(string nome, bool ativo, DateTime criacao, DateTime? ultimaAlteracao, string responsavel)
        {
            Nome = nome;
            Ativo = ativo;
            Criacao = criacao;
            UltimaAlteracao = ultimaAlteracao;
            Responsavel = responsavel;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public DateTime Criacao { get; set; }
        public DateTime? UltimaAlteracao { get; set; }
        public string Responsavel { get; set; }
    }
}
