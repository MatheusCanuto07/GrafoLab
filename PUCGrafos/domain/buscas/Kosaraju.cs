using PUCGrafos.domain.grafo;
using PUCGrafos.domain.grafo.grafo_simples.grafo_simples_direcionado;
using PUCGrafos.domain.interfaces;
using PUCGrafos.domain.utilidades;
using PUCGrafos.domain.vertice;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUCGrafos.domain.buscas
{
    public class Kosaraju : IBuscaEmGrafo
    {
        protected GrafoDirecionado Grafo { get; set; }
        protected int IdVerticeInicial;
        protected ResultadoBusca[] resultado;
        protected List<int> vertices_nao_descobertos = new();
        protected int tempo = 0;

        public Kosaraju(GrafoDirecionado grafo)
        {
            this.Grafo = grafo;
            resultado = new ResultadoBusca[this.Grafo.Vertices.Length];
            for (int i = 0; i < resultado.Length; i++)
            {
                resultado[i].IdVertice = this.Grafo.Vertices[i].Id;
            }
        }

        public ResultadoBusca[] GetResultado()
        {
            return resultado;
        }

        public void Processar()
        {
            Inicializar();

            // Realiza DFS em G
            this.Grafo.RealizarBuscaEmProfundidade(this.IdVerticeInicial);
            ResultadoBusca[] result = this.Grafo.GetResultadoBuscaEmProfundidade();

            // Constroi Gr
            Grafo gr = this.Grafo.GetGrafoDirecaoInvertida();

            // Monta lista de vertices ordenado por término
            ResultadoBusca[] result_decrescente = result.OrderByDescending(x => x.Termino).ToArray();
            for (int i = 0; i < result_decrescente.Length; i++)
            {
                vertices_nao_descobertos.Add(result_decrescente[i].IdVertice);
            }

            // Realiza Busca em profundidade
            while (this.vertices_nao_descobertos.Count > 0)
            {
                int v = vertices_nao_descobertos.First();
                this.BuscaRecursiva(v);
            }

        }

        public void SetVerticeInicial(int Id)
        {
            return;
        }

        protected void Inicializar()
        {
            tempo = 0;
            vertices_nao_descobertos.Clear();

            for (int i = 0; i < resultado.Length; i++)
            {
                resultado[i].Descoberta = Constantes.VerticeNaoExplorado;
                resultado[i].Termino = Constantes.VerticeNaoExplorado;
                resultado[i].IdPai = Constantes.VerticeInexistente;
            }
        }

        protected void BuscaRecursiva(int Id)
        {
            tempo++;
            this.resultado[Id].Descoberta = tempo;
            this.vertices_nao_descobertos.Remove(Id);

            Vertice v = this.Grafo.Vertices[Id];

            foreach (int w in v.Sucessores)
            {
                if (this.resultado[w].Descoberta == 0)
                {
                    this.resultado[w].IdPai = v.Id;
                    BuscaRecursiva(w);
                }
            }

            tempo++;
            this.resultado[Id].Termino = tempo;
        }
    }
}
