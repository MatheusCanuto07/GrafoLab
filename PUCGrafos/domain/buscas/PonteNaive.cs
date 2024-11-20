

using PUCGrafos.domain.grafo;

namespace PUCGrafos.domain.buscas
{
    public class PonteNaive {
        private Grafo grafo;

        public PonteNaive(Grafo grafo)
        {
            this.grafo = grafo;
        }

        public List<(int, int)> EncontrarPontes()
        {
            Grafo copia = this.grafo.GetCopia();
            List<(int, int)> pontes = new List<(int, int)>();

            for (int u = 0; u < copia.Vertices.Length; u++)
            {
                foreach (int v in grafo.Vertices[u].Adjacencia)
                {
                    if (u < v) // Evita processar arestas duplicadas
                    {
                        copia.RemoverAresta(u,v, true);

                        if (!IsConexo(copia))
                        {
                            pontes.Add((u, v));
                        }

                        copia.AdicionarAresta(u, v, 0, true);
                    }
                }
            }

            return pontes;
        }

        private bool IsConexo(Grafo grafo)
        {
            HashSet<int> visitados = new HashSet<int>();
            DFS(grafo, 0, visitados);
            return visitados.Count == grafo.Vertices.Length;
        }

        private void DFS(Grafo grafo, int vertice, HashSet<int> visitados)
        {
            visitados.Add(vertice);

            foreach (int vizinho in grafo.Vertices[vertice].Adjacencia)
            {
                if (!visitados.Contains(vizinho))
                {
                    DFS(grafo, vizinho, visitados);
                }
            }
        }

    }
}