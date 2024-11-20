using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PUCGrafos.domain.grafo.grafo_simples;
using PUCGrafos.domain.interfaces;
using PUCGrafos.domain.utilidades;

namespace PUCGrafos.domain.grafo.grafo_simples.grafo_simples_nao_direcionado
{
    public class GrafoNaoDirecionado : Grafo
    {
        public GrafoNaoDirecionado(int NumVertices) : base(NumVertices)
        {
        }

        public override bool IsDirecionado()
        {
            return false;
        }

        public override int GetMaximoArestas()
        {
            int n = this.Vertices.Length;
            return (n * (n - 1)) / 2;
        }

        public override bool IsSimplesmenteConexo()
        {
            if (this.GetResultadoBuscaEmLargura() == null)
            {
                RealizarBuscaEmLargura();
            }
            return this.IsTodosVerticesAlcançaveis(GetResultadoBuscaEmLargura());
        }

        public override bool IsSemiFortementeConexo()
        {
            // Conceito não se aplica a grafos não direcionados
            return false;
        }

        public override bool IsFortementeConexo()
        {
            // Conceito não se aplica a grafos não direcionados
            return false;
        }

    }
}
