using PUCGrafos.domain.grafo;
using PUCGrafos.domain.interfaces;
using PUCGrafos.domain.utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace PUCGrafos.domain.buscas
{
    public class BuscaEmLargura : IBuscaEmGrafo
    {
        protected Grafo Grafo { get; set; }
        protected int IdVerticeInicial;
        protected ResultadoBusca[] resultado;

        protected Queue<int> Fila = new Queue<int>();
        public BuscaEmLargura(Grafo grafo)
        {
            this.Grafo = grafo;
            resultado = new ResultadoBusca[this.Grafo.Vertices.Length];
            for (int i = 0; i < resultado.Length; i++)
            {
                resultado[i].IdVertice = this.Grafo.Vertices[i].Id;
            }
        }
        public void Processar()
        {
            Inicializar();

            while (Fila.Count != 0)
            {
                int v = Fila.First();
                foreach (int w in Grafo.Vertices[v].Adjacencia)
                {
                    if (resultado[w].Status == Constantes.VerticeNaoExplorado)
                    {
                        resultado[w].Status = Constantes.VerticeExplorado;
                        resultado[w].Nivel = resultado[v].Nivel + 1;
                        resultado[w].IdPai = v;
                        Fila.Enqueue(w);
                    }
                }
                Fila.Dequeue();
                resultado[v].Status = Constantes.VerticeFinalizado;
            }
        }

        public ResultadoBusca[] GetResultado()
        {
            return this.resultado;
        }

        protected void Inicializar()
        {
            for (int i = 0; i < resultado.Length; i++)
            {
                resultado[i].Status = Constantes.VerticeNaoExplorado;
                resultado[i].Nivel = Constantes.Infinito;
                resultado[i].IdPai = Constantes.VerticeInexistente;
            }

            Fila.Clear();

            int IdInicio = EscolheVerticeInicio();

            resultado[IdInicio].Status = Constantes.VerticeExplorado;
            resultado[IdInicio].Nivel = 0;

            Fila.Enqueue( IdInicio );
        }

        protected int EscolheVerticeInicio()
        {
            return this.IdVerticeInicial;
        }

        public void SetVerticeInicial(int Id)
        {
            this.IdVerticeInicial = Id;
        }
    }

}
