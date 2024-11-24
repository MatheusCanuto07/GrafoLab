
using PUCGrafos.domain.grafo;

namespace PUCGrafos.domain.buscas
{
    public class FleuryTarjan : AlgoritmoFleury
    {
        public FleuryTarjan(Grafo grafo) : base(grafo)
        {
        }

        protected override List<(int, int)> BuscarPontes(Grafo g)
        {
            return g.BuscaPontesTarjan();
        }
    }
}