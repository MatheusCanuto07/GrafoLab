using PUCGrafos.domain.grafo;
using PUCGrafos.domain.interfaces;
using PUCGrafos.domain.utilidades;
using PUCGrafos.domain.vertice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUCGrafos.domain.buscas
{
    public class BuscaEmProfundidade : IBuscaEmGrafo
    {
        protected Grafo Grafo { get; set; }
        protected int IdVerticeInicial;
        protected ResultadoBusca[] resultado;
        protected int tempo = 0;
        protected List<int> vertices_nao_descobertos = new();

        public BuscaEmProfundidade(Grafo grafo)
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
            return this.resultado;
        }

        public void Processar()
        {
            Inicializar();

            while (this.vertices_nao_descobertos.Count > 0)
            {
                int v = vertices_nao_descobertos.First();
                this.BuscaRecursiva(v);
            }
        }

        public void SetVerticeInicial(int Id)
        {
            this.IdVerticeInicial = Id;
        }

        protected void Inicializar()
        {
            tempo = 0;
            vertices_nao_descobertos.Clear();
            vertices_nao_descobertos.Add(IdVerticeInicial);

            for (int i = 0; i < resultado.Length; i++)
            {
                resultado[i].Descoberta = Constantes.VerticeNaoExplorado;
                resultado[i].Termino    = Constantes.VerticeNaoExplorado;
                resultado[i].IdPai      = Constantes.VerticeInexistente;

                if (resultado[i].IdVertice != IdVerticeInicial)
                {
                    vertices_nao_descobertos.Add(resultado[i].IdVertice);
                }

            }
        }

        protected int EscolheVerticeInicio()
        {
            return this.IdVerticeInicial;
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
