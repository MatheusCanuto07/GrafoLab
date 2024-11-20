using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafoLab
{
    public class Vertice
    {
      public int? numero;
      public float? peso;
      public string? rotulo;
      public List<int>[]? _listaAdjacencia;
      public Vertice(int n){
        numero = n;
        peso = null;
        rotulo = null;
        _listaAdjacencia = null;
      }
      public void alterarPeso(float p){
        peso = p;
      }
      public void alterarRotulo(string r){
        rotulo = r;
      }
    }
}
