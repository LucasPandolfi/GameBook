using System.ComponentModel.DataAnnotations;

namespace GameBook.Entities.Usuario
{
    public class UsuarioResponse
    {
        public UsuarioResponse()
        {
        }

        public UsuarioResponse(int id, string nome, string documento, string email, bool ativo, DateTime dataCriacao, DateTime? dataUltimaAlteracao, string responsavel)
        {
            Id = id;
            Nome = nome;
            Documento = documento;
            Email = email;
            Ativo = ativo;
            DataCriacao = dataCriacao;
            DataUltimaAlteracao = dataUltimaAlteracao;
            Responsavel = responsavel;
        }

        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataUltimaAlteracao { get; set; }
        public string Responsavel { get; set; }
    }
}
