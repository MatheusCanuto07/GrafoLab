using PUCGrafos.domain.grafo;
using PUCGrafos.domain.grafo.gerarGrafo;
using PUCGrafos.domain.grafo.grafo_simples.grafo_simples_direcionado;
using PUCGrafos.domain.grafo.grafo_simples.grafo_simples_nao_direcionado;

#region Manipulacao
// Funções básicas para manipulação de grafos em ambas representações, incluindo:

// Criação de um grafo com X vértices (o número de vértices deve ser inserido pelo usuário)
Grafo grafoNaoDirecionado = new GrafoNaoDirecionado(15);
Grafo grafoDirecionado = new GrafoDirecionado(15);

// Criação e remoção de arestas
grafoNaoDirecionado.AdicionarAresta(1,2);
grafoNaoDirecionado.AdicionarAresta(1,3);
grafoNaoDirecionado.AdicionarAresta(1,4);

grafoDirecionado.AdicionarAresta(1, 2);
grafoDirecionado.AdicionarAresta(1, 3);
grafoDirecionado.AdicionarAresta(1, 4);

// Ponderação e rotulação de vértices
grafoNaoDirecionado.InserirRotuloVertice("Rua a", 1);
grafoDirecionado.InserirRotuloVertice("Rua b", 1);

grafoNaoDirecionado.InserirPesoVertice(1, 1);
grafoDirecionado.InserirPesoVertice(4, 1);
// Ponderação e rotulação de arestas
grafoNaoDirecionado.InserirRotuloAresta("Rua 3", 1, 2);
grafoDirecionado.InserirRotuloAresta("Rua 902", 1 , 2);

grafoNaoDirecionado.InserirPesoAresta(50, 1 ,2);
grafoDirecionado.InserirPesoAresta(150, 1, 2);

// Checagem de adjacência entre vértices
grafoDirecionado.VerificaAdjacenciaEntreVertices(1, 2);
grafoNaoDirecionado.VerificaAdjacenciaEntreVertices(1, 2);

// Checagem de adjacência entre arestas
//grafoDirecionado.VerificaAdjacenciaEntreArestas(1, 2, 1, 3, true);
//grafoNaoDirecionado.VerificaAdjacenciaEntreArestas(1, 2, 1, 3, true);

// Checagem da existência de arestas
grafoDirecionado.VerificaExistenciaAresta(1,2);
grafoNaoDirecionado.VerificaExistenciaAresta(1,3);

// Checagem da quantidade de vértices e arestas
grafoDirecionado.GetQuantidadeArestas();
grafoDirecionado.GetQuantidadeVertices();

grafoNaoDirecionado.GetQuantidadeArestas();
grafoNaoDirecionado.GetQuantidadeArestas();

// Checagem de grafo vazio e completo
grafoDirecionado.VerificaGrafoVazio();
grafoDirecionado.VerificaGrafoCompleto();

grafoNaoDirecionado.VerificaGrafoVazio();
grafoNaoDirecionado.VerificaGrafoCompleto();

// Checagem de conectividade em simplismente conexo, semi-fortemente conexo e fortemente conexo
// IsSimplesmenteConexo - Ambos
grafoDirecionado.IsSimplesmenteConexo();
grafoNaoDirecionado.IsSimplesmenteConexo();

// semi-fortemente - Somente não direcionados
grafoNaoDirecionado.IsSemiFortementeConexo();

// fortemente conexo - Somente não direcionados
grafoNaoDirecionado.IsFortementeConexo();

// Checagem de quantidade de componentes fortemente conexos com Kosaraju
grafoDirecionado.GetComponentesFConexosKosaraju();
grafoNaoDirecionado.GetComponentesFConexosKosaraju();

// Checagem de ponte e articulação
grafoDirecionado.BuscaPontesNaive();
grafoNaoDirecionado.BuscaPontesNaive();

grafoDirecionado.BuscarArticulacoes();
grafoNaoDirecionado.BuscarArticulacoes();

#endregion

#region Representações
// Representação de grafos utilizando Matriz de Adjacência
grafoDirecionado.ImprimirMatrizAdjacencia();
grafoNaoDirecionado.ImprimirMatrizAdjacencia();

// Representação de grafos utilizando Matriz de Incidência
grafoDirecionado.ImprimirMatrizIncidencia();
grafoNaoDirecionado.ImprimirMatrizIncidencia();

// Representação de grafos utilizando Lista de Adjacência
grafoDirecionado.ImprimirListaAdjacencia();
grafoNaoDirecionado.ImprimirListaAdjacencia();
#endregion

#region Testes de grafo euleriano - Joao e Higor
// Criação de um grafo com X vértices (o número de vértices deve ser inserido pelo usuário)
//Grafo grafoDirecionado = new GrafoDirecionado(6);

// grafoDirecionado.AdicionarAresta(1,2);
// grafoDirecionado.AdicionarAresta(1,3);

// grafoDirecionado.AdicionarAresta(2,3);

// Criação e remoção de arestas
//grafoDirecionado.AdicionarAresta(1, 2);
//grafoDirecionado.AdicionarAresta(1, 3);
// grafoNaoDirecionado.AdicionarAresta(1, 2);
// grafoNaoDirecionado.AdicionarAresta(1, 3);

// grafoNaoDirecionado.AdicionarAresta(2, 3);
// grafoNaoDirecionado.AdicionarAresta(2, 4);
// grafoNaoDirecionado.AdicionarAresta(2, 5);

// grafoNaoDirecionado.AdicionarAresta(3, 4);
// grafoNaoDirecionado.AdicionarAresta(3, 6);

// grafoNaoDirecionado.AdicionarAresta(4, 5);
// grafoNaoDirecionado.AdicionarAresta(4, 6);

// grafoNaoDirecionado.AdicionarAresta(5, 6);
// grafoNaoDirecionado.AdicionarAresta(5, 7);

// grafoNaoDirecionado.AdicionarAresta(6, 7);

//grafoNaoDirecionado.ImprimirCaminhoEuleriano();
#endregion

Grafo grafoEuleriano = gerarGrafoNaoDirecionado.CriaGrafoAleatorioAresta(15);

grafoEuleriano.ImprimirListaAdjacencia();