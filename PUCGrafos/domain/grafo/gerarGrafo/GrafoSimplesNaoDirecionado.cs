

using System.Security.Cryptography;
using PUCGrafos.domain.grafo.grafo_simples.grafo_simples_direcionado;
using PUCGrafos.domain.grafo.grafo_simples.grafo_simples_nao_direcionado;

namespace PUCGrafos.domain.grafo.gerarGrafo{
  public static class gerarGrafoNaoDirecionado{
    public static GrafoNaoDirecionado CriaGrafoAleatorio(int vertice, int aresta){
      Grafo g = new GrafoNaoDirecionado(vertice);
      Random random = new Random();

      int[] verticeInicio = new int[aresta];
      int[] verticeFim = new int[aresta];

      for (int i = 0; i < aresta; i++)
      {
        int novoInicio, novoFim;
        // Garante que o número não se repita
        do
        {
          novoInicio = random.Next(0, vertice - 1);
          novoFim = random.Next(0, vertice - 1);
          //Conferir se a dupla já existe
        } while (novoInicio == novoFim );

        verticeInicio[i] = novoInicio;
        verticeFim[i] = novoFim;
      }

      for (int i = 0; i < aresta - 1; i++)
      {
        //0 - 3
        //2 - 1
        //3 - 2
        //1 - 2

        g.AdicionarAresta(verticeInicio[i], verticeFim[i]);
      }

      return (GrafoNaoDirecionado)g;
    }
  }
}