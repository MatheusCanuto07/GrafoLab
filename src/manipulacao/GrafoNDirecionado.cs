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
      for (int i = 0; i < _numeroVertices; i++)
      {
        Vertice v = new Vertice(i);
        listaVertices.Add(v);
        _listaAdjacencia[i] = new List<int>();
      }
    }

    private bool checarVerticeValida(int verticeInicio, int verticeFim){
      if (verticeInicio >= 0 && verticeInicio < _numeroVertices && verticeFim >= 0 && verticeFim < _numeroVertices){
        return true;
      }
      return false;
    }

    // Método para adicionar uma aresta ao grafo
    public void AdicionarAresta(int verticeInicio, int verticeFim)
    {
      //Aresta a = new Aresta();
        if (checarVerticeValida(verticeInicio, verticeFim))
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
      if (checarVerticeValida(verticeInicio, verticeFim))
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
      ListaAdjacencia.imprimir(this);
    }

    public void alterarPesoVertice(int Nvertice, float peso){
      Vertice? v = listaVertices.Find(v => v.numero == Nvertice);

      if (v != null){
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

    // Caso de uso:
    // if(g.checarAdjacenciaVertice(2,4)){
    //   Console.WriteLine("Eles são adjacentes");
    // } else{
    //   Console.WriteLine("Eles não são adjacentes");
    // }
    public bool checarAdjacenciaVertice(int verticeInicio, int verticeFim){
      // Verifica se a vertice é válida
      if(checarVerticeValida(verticeInicio, verticeFim)){
        // Se a vertice estiver na lista
        foreach (var v in _listaAdjacencia[verticeInicio])
        {
          if(v == verticeFim){
            return true;
          }
        }
        return false;
      } else{
        throw new ArgumentOutOfRangeException("Vértice fora da intervalo válido.");
      }
    }

    // Como uma aresta teoricamente não existe, o metodo vai ser o mesmo
    public bool checarAdjacenciaAresta(int verticeInicio, int verticeFim){
      if(checarVerticeValida(verticeInicio, verticeFim)){
        // Se a vertice estiver na lista
        foreach (var v in _listaAdjacencia[verticeInicio])
        {
          if(v == verticeFim){
            return true;
          }
        }
        return false;
      } else{
        throw new ArgumentOutOfRangeException("Vértice fora da intervalo válido.");
      }
    }

    //Duas arestas são ditas adjacentes se compartilham pelo menos um vértice em comum. Ou seja, se duas arestas têm um vértice em comum, elas são consideradas adjacentes.
    // TODO: Implementar a aresta para fazer esse metodo
    public bool checarExistenciaAresta(int verticeInicio, int verticeFim){
      if(checarVerticeValida(verticeInicio, verticeFim)){
        foreach (var v in _listaAdjacencia[verticeInicio])
        {
          
        }
        return false;
      } else{
        throw new ArgumentOutOfRangeException("Vértice fora da intervalo válido.");
      }
    }

    public int quantVertice(){
      return _listaAdjacencia.Length;
    }

    public int quantAresta(){
      int totalAresta = 0;
      for (int i = 0; i < _listaAdjacencia?.Length; i++)
      {
        if(_listaAdjacencia[i] != null)
          totalAresta += _listaAdjacencia[i].Count;
      }
      return totalAresta / 2;
    }
    // Um grafo vazio é um grafo que não possui arestas, ou seja, nenhum par de vértices está conectado. Ele pode ter um ou mais vértices, mas não há nenhuma conexão entre eles.
    public bool checarGrafoVazio(){
      for (int i = 0; i < _listaAdjacencia?.Length; i++)
      {
        if(_listaAdjacencia[i].Count > 0){
          return false;
        }
      }
      return true;
    }

    // Um grafo completo é o oposto de um grafo vazio. Em um grafo completo, todos os pares de vértices estão conectados por uma aresta. 
    public bool checarGrafoCompleto(){
      for (int i = 0; i < _listaAdjacencia.Length; i++)
      {
        if(!(_listaAdjacencia[i].Count == _listaAdjacencia.Length - 1)){
          return false;
        }
      }
      return true;
    }
    // Simplesmente conexo (Não direcionado): Verifique se há conectividade ignorando as direções (para grafos direcionados).
    // Um grafo simplesmente conexo (ou apenas "conexo") é um grafo não direcionado no qual existe um caminho entre qualquer par de vértices.
    // Semi-fortemente conexo (Direcionado): Verifique a conectividade do grafo após remover as direções.
    // Grafo direcionado onde existe ao menos um caminho unidirecional entre qualquer par de vértices, mas não necessariamente um caminho de volta.
    // Fortemente conexo (Direcionado): Verifique a conectividade considerando as direções e, em seguida, faça a checagem no grafo invertido.
    // Um grafo fortemente conexo é um grafo direcionado no qual existe um caminho entre qualquer par de vértices em ambas as direções. 
    public void checarSimplementeConexo(){

    }
    public void checarSemiForementeConexo(){

    }

    public void checarFortementeConexo(){

    }

    public void checarQuantFortementeConexoKosaraju(){

    }

    // Em teoria dos grafos, uma ponte (ou aresta de corte) é uma aresta cuja remoção desconecta o grafo, ou seja, faz com que ele deixe de ser simplesmente conexo.
    public bool checarPonte(int verticeInicio, int verticeFim){
      if(checarVerticeValida(verticeInicio, verticeFim)){
        if(_listaAdjacencia[verticeInicio].Contains(verticeFim) && _listaAdjacencia[verticeInicio].Count == 1)
          return true;
        else
          return false;
      }
      else{
        throw new ArgumentOutOfRangeException("Vértice fora da intervalo válido.");
      }
    }

    // É um vértice cuja remoção desconecta o grafo, aumentando o número de componentes conexas. 
    public void checarArticulacao(){
      
    }
  }
}

