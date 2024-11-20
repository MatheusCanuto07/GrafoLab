using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PUCGrafos.domain.grafo.grafo_simples;
using PUCGrafos.domain.grafo.grafo_simples.grafo_simples_nao_direcionado;
using PUCGrafos.domain.utilidades;

namespace PUCGrafos.domain.grafo.grafo_simples.grafo_simples_direcionado
{
    public class GrafoDirecionado : Grafo
    {
        public GrafoDirecionado(int NumVertices) : base(NumVertices)
        {
        }

        public override bool IsDirecionado()
        {
            return true;
        }

        public override int GetMaximoArestas()
        {
            int n = this.Vertices.Length;
            return n * (n - 1);
        }

        public override bool IsSimplesmenteConexo()
        {
            Grafo grafo = this.GetSubjascente();

            grafo.RealizarBuscaEmLargura();

            return IsTodosVerticesAlcançaveis(grafo.GetResultadoBuscaEmLargura());
        }

        public override bool IsSemiFortementeConexo()
        {
            Grafo grafo = this.GetSubjascente();

            grafo.RealizarBuscaEmLargura();

            return IsTodosVerticesAlcançaveis(grafo.GetResultadoBuscaEmLargura());
        }

        public override bool IsFortementeConexo()
        {
            this.RealizarBuscaEmLargura();

            if (!IsTodosVerticesAlcançaveis(GetResultadoBuscaEmLargura())) {
                return false;
            }

            Grafo grafoDirecaoInvertida = this.GetGrafoDirecaoInvertida();

            grafoDirecaoInvertida.RealizarBuscaEmLargura();

            return IsTodosVerticesAlcançaveis(grafoDirecaoInvertida.GetResultadoBuscaEmLargura());
        }

        private GrafoDirecionado GetGrafoDirecaoInvertida()
        {
            int IdOrigemExterno, IdDestinoExterno;
            GrafoDirecionado grafo = new GrafoDirecionado(this.Vertices.Length);

            foreach (string key in Arestas.Keys)
            {
                IdOrigemExterno = Utilidades.GetIDVerticeExterno(Arestas[key].GetIdOrigem());
                IdDestinoExterno = Utilidades.GetIDVerticeExterno(Arestas[key].GetIdDestino());
                grafo.AdicionarAresta(IdDestinoExterno, IdOrigemExterno);
            }

            return grafo;
        }
    }
}
