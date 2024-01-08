namespace GameBook.Entities.RequestsViewModel
{
    public class QuadroRequestViewModel
    {
        public QuadroRequestViewModel(string nome, int idUsuario, int idCategoriaQuadro)
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
