

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

            int vertices_desconectados = grafo.Vertices.Where(x => x.Adjacencia.Count == 0).Count();

            for (int u = 0; u < copia.Vertices.Length; u++)
            {
                foreach (int v in grafo.Vertices[u].Adjacencia)
                {
                    if (!copia.IsDirecionado() && u < v) { continue; } // Evita processar arestas duplicadas
                    
                    copia.RemoverAresta(u,v, true);

                    if (!IsConexo(copia, vertices_desconectados))
                    {
                        pontes.Add((u, v));
                    }

                    copia.AdicionarAresta(u, v, 0, true);
                }
            }

            return pontes;
        }

        private bool IsConexo(Grafo grafo, int vertices_desconectados)
        {
            HashSet<int> visitados = new HashSet<int>();
            DFS(grafo, 0, visitados);
            return visitados.Count == ( grafo.Vertices.Length - vertices_desconectados );
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