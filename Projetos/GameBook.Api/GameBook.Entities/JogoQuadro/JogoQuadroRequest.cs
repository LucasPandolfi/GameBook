namespace GameBook.Entities.JogoQuadro
{
    public class JogoQuadroRequest
    {
        public JogoQuadroRequest(int idQuadro, int idJogo)
        {
            IdQuadro = idQuadro;
            IdJogo = idJogo;
        }

        public int IdQuadro { get; set; }
        public int IdJogo { get; set; }
    }
}
