namespace GameBook.Entities.Usuario
{
    public class UsuarioRequest
    {
        public UsuarioRequest(string nome, string documento, string email)
        {
            Nome = nome;
            Documento = documento;
            Email = email;
        }

        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }
    }
}
