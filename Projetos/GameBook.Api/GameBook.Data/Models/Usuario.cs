namespace GameBook.Data.Models
{
    public class Usuario
    {
        public Usuario() { }

        public Usuario(string nome, string documento, string email, bool ativo, DateTime criacao, DateTime? ultimaAlteracao, string responsavel)
        {
            Nm_Usuario = nome;
            Ds_Documento = documento;
            Ds_Email = email;
            Fl_Ativo = ativo;
            Dt_Criacao = criacao;
            Dt_UltimaAlteracao = ultimaAlteracao;
            Ds_Responsavel = responsavel;
        }

        public int Id { get; set; }
        public string Nm_Usuario { get; set; }
        public string Ds_Documento { get; set; }
        public string Ds_Email { get; set; }
        public bool Fl_Ativo { get; set; }
        public DateTime Dt_Criacao { get; set; }
        public DateTime? Dt_UltimaAlteracao { get; set; }
        public string Ds_Responsavel { get; set; }
    }
}
