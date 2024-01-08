namespace GameBook.Data.Models
{
    public class Usuario
    {
        public Usuario() { }

        public Usuario(string nome, string documento, string email, bool ativo, DateTime criacao, DateTime? ultimaAlteracao, string responsavel)
        {
            Nome = nome;
            Documento = documento;
            Email = email;
            Ativo = ativo;
            Criacao = criacao;
            UltimaAlteracao = ultimaAlteracao;
            Responsavel = responsavel;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
        public DateTime Criacao { get; set; }
        public DateTime? UltimaAlteracao { get; set; }
        public string Responsavel { get; set; }
    }
}
