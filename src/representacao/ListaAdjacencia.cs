namespace GrafoLab
{
  public static class ListaAdjacencia{
    public static void imprimir(Grafo grafo)
      {
        for (int i = 0; i < grafo._numeroVertices; i++)
        {
          Console.Write($"Vértice {i}: ");
          foreach (var vertice in grafo._listaAdjacencia[i])
          {
            Console.Write($"{vertice} ");
          }
          Console.WriteLine();
        }
      }
  }
}