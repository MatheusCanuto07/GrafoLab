using PUCGrafos.domain.grafo;

namespace PUCGrafos.domain.buscas
{
    public class AlgoritmoFleury {
        
        protected Grafo grafo;

        public AlgoritmoFleury(Grafo grafo) {
            this.grafo = grafo;
        }

        public List<int> GetCaminhoEuleriano() {

            Grafo copia = this.grafo.GetCopia();

            List<(int,int)> pontes = copia.BuscaPontesTarjan();

            (int,int) ponte;

            ponte.Item1 = 0;
            ponte.Item2 = 0;

            // Acesso ao grau do vertice
            //grafo.Vertices[0].Grau

            return new List<int>();
        }

    }
}