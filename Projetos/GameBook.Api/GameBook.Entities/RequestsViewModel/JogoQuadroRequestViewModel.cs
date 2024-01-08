namespace GameBook.Entities.RequestsViewModel
{
    public class JogoQuadroRequestViewModel
    {
        public JogoQuadroRequestViewModel(int idQuadro, int idJogo)
        {
            IdQuadro = idQuadro;
            IdJogo = idJogo;
        }

        public int IdQuadro { get; set; }
        public int IdJogo { get; set; }
    }
}
