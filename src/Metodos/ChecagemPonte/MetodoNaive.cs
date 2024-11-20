namespace GrafoLab.Algoritmos.ChecagemPonte.MetodoNaive
{
  public static class MetodoNaive{

    // O método ingênuo (ou "naive") de checagem de pontes em um grafo consiste em verificar, para cada aresta, se a remoção dessa aresta desconecta o grafo. Em outras palavras, para cada aresta, o método verifica se, ao removê-la, ainda existe um caminho entre todos os pares de vértices que estavam conectados anteriormente. Se não, a aresta é uma ponte.

    // Para cada aresta (u, v) no grafo:
    // Remova a aresta (u, v)
    // Inicie DFS a partir de u
    
    // Se v não for alcançável a partir de u:
    //     A aresta (u, v) é uma ponte
    // Caso contrário:
    //     A aresta (u, v) não é uma ponte
    
    // Restaure a aresta (u, v)

  } 
}