

using System.Security.Cryptography;
using PUCGrafos.domain.grafo.grafo_simples.grafo_simples_direcionado;
using PUCGrafos.domain.grafo.grafo_simples.grafo_simples_nao_direcionado;

namespace PUCGrafos.domain.grafo.gerarGrafo{
  public static class gerarGrafoNaoDirecionado{
    // Cria um grafo simples aleatório que pode ou não ser conexo
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
      // V * (V - 1) / 2 >= número de arestas
      // número de arestas = V * (V - 1)

      return CriaGrafoAleatorio(aresta + 1, aresta);
    }
    public static GrafoNaoDirecionado CriaGrafoAleatorio(int nAleatorio){
      Random random = new Random();
      int nAleatorioVertice = random.Next(1, nAleatorio);
      int nAleatorioAresta = random.Next(0, nAleatorioVertice * (nAleatorioVertice - 1) / 2);

      return CriaGrafoAleatorio(nAleatorioVertice, nAleatorioAresta);
    }

    public static GrafoNaoDirecionado CriaAleatorioGrafoEuleriano(int numeroVertices){

      return GerarGrafoEulerianoNaoDirecionado(numeroVertices);
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
    private static GrafoNaoDirecionado GerarGrafoEulerianoNaoDirecionado(int numeroVertices)
    {
      Random random = new Random();
      var grafo = new GrafoNaoDirecionado(numeroVertices);

      if (numeroVertices < 2)
      {
          Console.WriteLine("Número de vértices deve ser pelo menos 2.");
          return grafo;
      }

      for (int i = 0; i < numeroVertices - 1; i++)
      {
          grafo.AdicionarAresta(i, i + 1, 0, true);
      }

      // Se a quantidade de vertices for par ele adiciona uma aresta
      if (numeroVertices % 2 == 0)
      {
        grafo.AdicionarAresta(0, numeroVertices - 1, 0, true);
      }

      int aleatoriedade = random.Next(0, numeroVertices * (numeroVertices - 1) - grafo.Arestas.Count());
      
      while(aleatoriedade > 0){
        int verticeAleatorio1 = random.Next(0, numeroVertices);
        int verticeAleatorio2 = random.Next(0, numeroVertices);

        if(!grafo.VerificaExistenciaAresta(verticeAleatorio1, verticeAleatorio2, true) 
          && verticeAleatorio1 != verticeAleatorio2 
        ){
          grafo.AdicionarAresta(verticeAleatorio1, verticeAleatorio2, 0, true);
        }

        aleatoriedade -= 1;
      }

      List<int> grauImpar = new List<int>();
      Dictionary<int,bool> VerticeProcessado = new Dictionary<int, bool>();
      int restantes;

      // Busca os vértices com grau ímpar
      for (int i = 0; i < grafo.Vertices.Length; i++)
      { 
        if(grafo.Vertices[i].Grau % 2 == 1){
          grauImpar.Add(i);
          VerticeProcessado.Add(i, false);
        }
      }

      restantes = grauImpar.Count();

      // Conecta os vértices com grau ímpar entre si
      for (int i = 0; i < grauImpar.Count; i++)
      {
        if (restantes == 2) return grafo; // Se sobrar 2 de grau ímpar, nenhum processamento a mais é necessário

        int IdOrigem = grauImpar[i];
        if (VerticeProcessado[IdOrigem])
          continue;
        for (int j = i + 1; j < grauImpar.Count; j++)
        {
          int IdDestino = grauImpar[j];
          if (VerticeProcessado[IdDestino] || grafo.VerificaExistenciaAresta(IdOrigem, IdDestino, true))
            continue;
          grafo.AdicionarAresta(IdOrigem,IdDestino,0,true);
          VerticeProcessado[IdOrigem] = VerticeProcessado[IdDestino] = true;
          restantes -= 2;
          break;
        }
      }

      // Remove os que já foram processados
      grauImpar.RemoveAll(e => VerticeProcessado[e]);

      // Separa por duplas e conecta em vértices aleatórios com grau par
      List<(int,int)> duplas = new();
      (int,int) dupla = new(-1,-1);
      foreach (int id in grauImpar) {
        if (dupla.Item1 == -1) {
          dupla.Item1 = id;
        } else {
          dupla.Item2 = id;
          duplas.Add(dupla);
          dupla = (-1,-1);
        }
      }

      foreach ((int,int) duplaVertices in duplas)
      {
        int IdVertice;
        do {
          IdVertice = random.Next(0, grafo.Vertices.Count());
        } while (grafo.Vertices[IdVertice].Grau % 2 != 0 ||                             // O vértice escolhido deve ter grau par
                 grafo.Vertices[duplaVertices.Item1].Adjacencia.Contains(IdVertice) ||  // Não deve estar conectado a nenhum dos vértices de 
                 grafo.Vertices[duplaVertices.Item2].Adjacencia.Contains(IdVertice));   // grau impar
        
        grafo.AdicionarAresta(IdVertice, duplaVertices.Item1, 0 ,true);
        grafo.AdicionarAresta(IdVertice, duplaVertices.Item2, 0 ,true);
      }

      return grafo;
    }
  }
}