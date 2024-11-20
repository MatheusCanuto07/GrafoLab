using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUCGrafos.domain.interfaces
{
    public interface IGrafoOutput
    {
        void ImprimirMatrizIncidencia();

        void ImprimirMatrizAdjacencia();

        void ImprimirDFS();

        void ImprimirBFS();

        void ImprimirPontesPorNaive();

        void ImprimirPontesPorTarjan();

        void ImprimirCaminhoEuleriano();

    }
}
