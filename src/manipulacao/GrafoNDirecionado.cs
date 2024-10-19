using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafoLab
{
 public class Grafo
  {
    public int _numeroVertices;
    public List<int>[] _listaAdjacencia;
    public List<Vertice> listaVertices;
    public List<Aresta> listaArestas;
    //5 vertices
    //[3],[],[1],[],[]
    //Criação de um grafo com X vértices (o número de vértices deve ser inserido pelo usuário)
    public Grafo(int numeroVertices)
    {
      _numeroVertices = numeroVertices;
      _listaAdjacencia = new List<int>[_numeroVertices];
      listaVertices = new List<Vertice>{};
      listaArestas = new List<Aresta>{};

      // Inicializa cada lista de adjacência
      for (int i = 1; i < _numeroVertices; i++)
      {
        Vertice v = new Vertice(i);
        listaVertices.Add(v);
        _listaAdjacencia[i] = new List<int>();
      }
    }

    // Método para adicionar uma aresta ao grafo
    public void AdicionarAresta(int verticeInicio, int verticeFim)
    {
      //Aresta a = new Aresta();
        if (verticeInicio >= 0 && verticeInicio < _numeroVertices &&
            verticeFim >= 0 && verticeFim < _numeroVertices)
        {
          Aresta a = new Aresta(verticeInicio, verticeFim);
          listaArestas.Add(a);
            _listaAdjacencia[verticeInicio].Add(verticeFim);
            _listaAdjacencia[verticeFim].Add(verticeInicio);
        }
        else
        {
            throw new ArgumentOutOfRangeException("Vértice fora do intervalo válido.");
        }
    }
    public void RemoverAresta(int verticeInicio, int verticeFim){
      if (verticeInicio >= 0 && verticeInicio < _numeroVertices &&
            verticeFim >= 0 && verticeFim < _numeroVertices)
        {
            _listaAdjacencia[verticeInicio].Remove(verticeFim);
            _listaAdjacencia[verticeFim].Remove(verticeInicio); 
        }
      else{
        throw new ArgumentOutOfRangeException("Vértice fora da intervalo válido.");
      }
    }
    // Método para exibir o grafo
    public void MostrarGrafo()
    {
        for (int i = 0; i < _numeroVertices; i++)
        {
            Console.Write($"Vértice {i}: ");
            foreach (var vertice in _listaAdjacencia[i])
            {
                Console.Write($"{vertice} ");
            }
            Console.WriteLine();
        }
    }

    public void alterarPesoVertice(int Nvertice, float peso){
      Vertice v = listaVertices.Find(v => v.numero == Nvertice);

      if(v != null){
        v.peso = peso;
        listaVertices[Nvertice] = v;
      }
    }

    // public void alterarPesoAresta(int inicioA, int fimAres, float peso){
    //   Aresta a = listaArestas.Find(v => v. == Nvertice);

    //   if(v != null){
    //     v.peso = peso;
    //     listaVertices[Nvertice] = v;
    //   }
    // }

    public void checarAdjacenciaVertice(){

    }
    public void checarAdjacenciaAresta(){
      
    }

    public void checarExistenciaAresta(int aresta1, int aresta2){

    }

    public int quantVertice(){
      return 0;
    }

    public int quantAresta(){
      return 0;
    }

    public void checarGrafoVazio(){
      
    }
    public void checarGrafoCompleto(){

    }
    // Simplesmente conexo: Verifique se há conectividade ignorando as direções (para grafos direcionados).
    // Semi-fortemente conexo: Verifique a conectividade do grafo após remover as direções.
    // Fortemente conexo: Verifique a conectividade considerando as direções e, em seguida, faça a checagem no grafo invertido.
    public void checarSimplementeConexo(){

    }
    public void checarSemiForementeConexo(){

    }

    public void checarFortementeConexo(){

    }

    public void checarQuantFortementeConexoKosaraju(){

    }

    public void checarPonte(){

    }

    public void checarArticulacao(){
      
    }
  }
}

