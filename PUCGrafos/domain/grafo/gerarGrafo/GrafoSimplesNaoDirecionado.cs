

using System.Security.Cryptography;
using PUCGrafos.domain.grafo.grafo_simples.grafo_simples_direcionado;
using PUCGrafos.domain.grafo.grafo_simples.grafo_simples_nao_direcionado;

namespace PUCGrafos.domain.grafo.gerarGrafo{
  public static class gerarGrafoNaoDirecionado{
    public static GrafoNaoDirecionado CriaGrafoAleatorio(int vertice, int aresta)
    {
      GrafoNaoDirecionado g = new GrafoNaoDirecionado(vertice);
      
      return PopulaGrafo(aresta, vertice, g);
    }
    public static GrafoNaoDirecionado CriaGrafoAleatorioVertice(int vertice){
      GrafoNaoDirecionado g = new GrafoNaoDirecionado(vertice);
      Random random = new Random();
      int nAleatorioAresta = random.Next(0, vertice * (vertice - 1) / 2);

      return PopulaGrafo(nAleatorioAresta, vertice, g);
    }
    public static GrafoNaoDirecionado CriaGrafoAleatorioAresta(int aresta){
      Random random = new Random();
      // TODO: Achar fórmula mínimo e máximo de arestas
      int nAleatorioVertice = random.Next(0, aresta);
      // V * (V - 1) / 2 >= número de arestas
      // número de arestas = V * (V - 1)

      GrafoNaoDirecionado g = new GrafoNaoDirecionado(nAleatorioVertice);

      return new GrafoNaoDirecionado(5);
    }
    public static GrafoNaoDirecionado CriaGrafoAleatorio(){
      return new GrafoNaoDirecionado(5);
    }
    private static GrafoNaoDirecionado PopulaGrafo(int aresta, int vertice, GrafoNaoDirecionado grafo){
      Random random = new Random();

      int[] verticeInicio = new int[aresta];
      int[] verticeFim = new int[aresta];

      for (int i = 0; i < aresta; i++)
      {
        int novoInicio, novoFim;
        // Garante que o número não se repita
        do
        {
          novoInicio = random.Next(0, vertice);
          novoFim = random.Next(0, vertice);
          // Ele sai do looping quando o novo inicio for diferente do novoFim
          // Se o array1 tem 1 e o array2 tem o item 2, o array1 não pode ter o item 2 e o array2 ter o item 1
        } while (novoInicio == novoFim || verificaDuplaInversa(verticeInicio, verticeFim, novoInicio, novoFim));

        verticeInicio[i] = novoInicio;
        verticeFim[i] = novoFim;
      }

      for (int i = 0; i < aresta - 1; i++)
      {
        grafo.AdicionarAresta(verticeInicio[i], verticeFim[i], 0, true);
      }

      return grafo;
    }
    private static bool verificaDuplaInversa(int [] array1, int [] array2, int novoNumero1, int novoNumero2){
      for (int i = 0; i < array1.Length; i++)
        {
          // Verificar se a nova dupla (novoNumero1, novoNumero2) ou sua inversa (novoNumero2, novoNumero1) já existe
          if ((array1[i] == novoNumero1 && array2[i] == novoNumero2) || (array1[i] == novoNumero2 && array2[i] == novoNumero1))
          {
              return true;
          }
        }
      return false;
    }
  }
}