
using PUCGrafos.domain.grafo;

namespace PUCGrafos.domain.buscas
{
    public class FleuryNaive : AlgoritmoFleury
    {
        public FleuryNaive(Grafo grafo) : base(grafo)
        {
        }

        protected override List<(int, int)> BuscarPontes(Grafo g)
        {
            return g.BuscaPontesNaive();
        }
    }
}