namespace GameBook.Entities.CategoriaQuadro
{
    internal class CategoriaQuadroRequest
    {
        public CategoriaQuadroRequest(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; set; }
    }
}
