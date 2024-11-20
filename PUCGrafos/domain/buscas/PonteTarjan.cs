using PUCGrafos.domain.grafo;
using PUCGrafos.domain.utilidades;

namespace PUCGrafos.domain.buscas {
    public class PonteTarjan {
        private Grafo grafo;
        private int tempo;
        private int[] temposDescoberta;
        private int[] valoresLow;
        private int[] pais;
        private List<(int, int)> pontes;

        public PonteTarjan(Grafo grafo)
        {
            this.grafo = grafo;
            this.tempo = 0;
            this.temposDescoberta = new int[grafo.Vertices.Length];
            this.valoresLow = new int[grafo.Vertices.Length];
            this.pais = new int[grafo.Vertices.Length];
            Array.Fill(temposDescoberta, Constantes.VerticeNaoExplorado); // Inicializa como não visitado
            Array.Fill(valoresLow, Constantes.VerticeNaoExplorado);
            this.pontes = new List<(int, int)>();
        }

        public List<(int, int)> EncontrarPontes()
        {
            for (int i = 0; i < grafo.Vertices.Length; i++)
            {
                if (temposDescoberta[i] == Constantes.VerticeNaoExplorado)
                {
                    DFS(i);
                }
            }

            return pontes;
        }

        private void DFS(int u)
        {
            temposDescoberta[u] = valoresLow[u] = tempo++;
            foreach (int v in grafo.Vertices[u].Adjacencia)
            {
                if (temposDescoberta[v] == Constantes.VerticeNaoExplorado) // Vértice ainda não visitado
                {
                    pais[v] = u;
                    DFS(v);

                    // Atualiza valoresLow do vértice atual
                    valoresLow[u] = Math.Min(valoresLow[u], valoresLow[v]);

                    // Verifica se (u, v) é uma ponte
                    if (valoresLow[v] > temposDescoberta[u])
                    {
                        pontes.Add((u, v));
                    }
                }
                else if (v != pais[u]) // Vértice já visitado, mas não é pai
                {
                    valoresLow[u] = Math.Min(valoresLow[u], temposDescoberta[v]);
                }
            }
        }
    }
}