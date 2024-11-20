using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafoLab
{
    public class Aresta{
      public float peso;
      public string rotulo;
      public Vertice inicio;
      public Vertice fim;
      public int NverticeInicio;
      public int NverticeFim;
      public Aresta(Vertice vInicio, Vertice vFim){
        inicio = vInicio;
        fim = vFim;
      }
      public Aresta(int NuVeInicio, int NuVeFim){
        NverticeInicio = NuVeInicio;
        NverticeFim = NuVeFim;
      }
      public void alterarPeso(float p){
        peso = p;
      }
      public void alterarRotulo(string r){
        rotulo = r;
      }
    }
}
