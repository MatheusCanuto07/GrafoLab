// See https://aka.ms/new-console-template for more information
using GrafoLab;

Grafo g = new Grafo(5);

//[Lista()],[Lista(2,3,4)],[Lista(1)],[Lista(1)],[Lista(1)]
g.AdicionarAresta(1,2);
g.AdicionarAresta(1,3);
g.AdicionarAresta(1,4);
g.AdicionarAresta(2,3);
//g.AlterarPesoAresta(1,2,3.65);
//g.RemoverAresta(2,4);

// if(g.checarAdjacenciaVertice(2,4)){
//   Console.WriteLine("Eles são adjacentes");
// } else{
//   Console.WriteLine("Eles não são adjacentes");
// }

// Console.WriteLine(g.quantAresta());
// Console.WriteLine(g.quantVertice());

// if(g.checarGrafoVazio()){
//   Console.WriteLine("Grafo está vazio");
// } else{
//   Console.WriteLine("O grafo não está vazio");
// }

// if(g.checarGrafoCompleto()){
//   Console.WriteLine("Grafo completo");
// } else{
//   Console.WriteLine("Grafo não completo");
// }

// if(g.checarPonte(1,2)){
//   Console.WriteLine("Tem ponte");
// } else{
//   Console.WriteLine("Não tem ponte");
// }

ListaAdjacencia.imprimir(g);
