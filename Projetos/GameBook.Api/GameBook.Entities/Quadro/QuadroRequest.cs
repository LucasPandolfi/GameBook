namespace GameBook.Entities.Quadro
{
    public class QuadroRequest
    {
        public QuadroRequest(string nome, int idUsuario, int idCategoriaQuadro)
        {
            Nome = nome;
            IdUsuario = idUsuario;
            IdCategoriaQuadro = idCategoriaQuadro;
        }

        public string Nome { get; set; }
        public int IdUsuario { get; set; }
        public int IdCategoriaQuadro { get; set; }
    }
}
