using PUCGrafos.domain.buscas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUCGrafos.domain.interfaces
{
    public interface IBuscaEmGrafo
    {
        public ResultadoBusca[] GetResultado();

        public void Processar();

        public void SetVerticeInicial(int Id);
    }

    public struct ResultadoBusca
    {
        public int IdVertice;
        public int Descoberta;
        public int Termino;
        public int Nivel;
        public int IdPai;
        public int Status;
    }
}
