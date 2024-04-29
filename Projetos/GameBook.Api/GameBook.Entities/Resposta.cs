namespace GameBook.Entities
{
    public class Resposta<T>
    {
        public Resposta()
        {
        }

        public Resposta(bool sucesso, string? mensagem, T? objeto)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
            Objeto = objeto;
        }

        public bool Sucesso { get; set; }
        public string? Mensagem { get; set; } 
        public T? Objeto { get; set; }
    }
}
