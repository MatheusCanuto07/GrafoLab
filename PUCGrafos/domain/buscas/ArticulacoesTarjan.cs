using PUCGrafos.domain.grafo;
using PUCGrafos.domain.utilidades;

namespace PUCGrafos.domain.buscas
{
    public class ArticulacaoTarjan
        {
            private Grafo grafo;
            private int tempo;
            private int[] temposDescoberta;
            private int[] valoresLow;
            private int[] pais;
            private bool[] visitados;
            private HashSet<int> articulacoes;

            public ArticulacaoTarjan(Grafo grafo)
            {
                this.grafo = grafo;
                this.temposDescoberta = new int[grafo.Vertices.Length];
                this.valoresLow = new int[grafo.Vertices.Length];
                this.pais = new int[grafo.Vertices.Length];
                this.visitados = new bool[grafo.Vertices.Length];
                this.articulacoes = new HashSet<int>();
                Inicializar();
            }

            private void Inicializar() {
                this.tempo = 0;
                Array.Fill(temposDescoberta, Constantes.VerticeInexistente); // Inicializa como não visitado
                Array.Fill(valoresLow, Constantes.VerticeInexistente);
                Array.Fill(pais, Constantes.VerticeInexistente); // Nenhum vértice tem pai no início
            }

            public List<int> EncontrarArticulacoes()
            {
                for (int i = 0; i < grafo.Vertices.Length; i++)
                {
                    if (!visitados[i])
                    {
                        DFS(i);
                    }
                }

                return new List<int>(articulacoes);
            }

            private void DFS(int u)
            {
                visitados[u] = true;
                temposDescoberta[u] = valoresLow[u] = tempo++;
                int filhos = 0;

                foreach (int v in grafo.Vertices[u].Adjacencia)
                {
                    if (!visitados[v])
                    {
                        pais[v] = u;
                        filhos++;

                        DFS(v);

                        // Atualiza valoresLow do vértice atual
                        valoresLow[u] = Math.Min(valoresLow[u], valoresLow[v]);

                        // Verifica condições para articulação:
                        // 1. Não raiz: Se valoresLow[v] >= temposDescoberta[u]
                        if (pais[u] != -1 && valoresLow[v] >= temposDescoberta[u])
                        {
                            articulacoes.Add(u);
                        }

                        // 2. Raiz: Se tem mais de um filho na DFS
                        if (pais[u] == -1 && filhos > 1)
                        {
                            articulacoes.Add(u);
                        }
                    }
                    else if (v != pais[u]) // Atualiza valoresLow se v é um vértice de retorno
                    {
                        valoresLow[u] = Math.Min(valoresLow[u], temposDescoberta[v]);
                    }
                }
            }
        }
}