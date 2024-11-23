using PUCGrafos.domain.grafo;
using PUCGrafos.domain.grafo.gerarGrafo;
using PUCGrafos.domain.grafo.grafo_simples.grafo_simples_direcionado;
using PUCGrafos.domain.grafo.grafo_simples.grafo_simples_nao_direcionado;
// Criação de um grafo com X vértices (o número de vértices deve ser inserido pelo usuário)
// Criação e remoção de arestas
// Ponderação e rotulação de vértices
// Ponderação e rotulação de arestas
// Checagem de adjacência entre vértices
// Checagem de adjacência entre arestas
// Checagem da existência de arestas
// Checagem da quantidade de vértices e arestas
// Checagem de grafo vazio e completo
// Checagem de conectividade em simplismente conexo, semi-fortemente conexo e fortemente conexo
// Checagem de quantidade de componentes fortemente conexos com Kosaraju
// Checagem de ponte e articulação

// Criação de um grafo com X vértices (o número de vértices deve ser inserido pelo usuário)
//Grafo grafoDirecionado = new GrafoDirecionado(6);
Grafo grafoNaoDirecionado = new GrafoNaoDirecionado(7);

// Criação e remoção de arestas
//grafoDirecionado.AdicionarAresta(1, 2);
//grafoDirecionado.AdicionarAresta(1, 3);
grafoNaoDirecionado.AdicionarAresta(1, 2);
grafoNaoDirecionado.AdicionarAresta(1, 3);

grafoNaoDirecionado.AdicionarAresta(2, 3);
grafoNaoDirecionado.AdicionarAresta(2, 4);
grafoNaoDirecionado.AdicionarAresta(2, 5);

grafoNaoDirecionado.AdicionarAresta(3, 4);
grafoNaoDirecionado.AdicionarAresta(3, 6);

grafoNaoDirecionado.AdicionarAresta(4, 5);
grafoNaoDirecionado.AdicionarAresta(4, 6);

grafoNaoDirecionado.AdicionarAresta(5, 6);
grafoNaoDirecionado.AdicionarAresta(5, 7);

grafoNaoDirecionado.AdicionarAresta(6, 7);

grafoNaoDirecionado.GetCaminhoEuleriano();

//grafoDirecionado.RemoverAresta(4 ,6);

// Ponderação e rotulação de vértices
// grafoDirecionado.InserirRotuloVertice("c", 1);
// grafoDirecionado.InserirRotuloVertice("a", 2);
// grafoDirecionado.InserirRotuloVertice("e", 3);
// grafoDirecionado.InserirRotuloVertice("b", 4);
// grafoDirecionado.InserirRotuloVertice("f", 5);
// grafoDirecionado.InserirRotuloVertice("d", 6);

// Ponderação e rotulação de arestas
// grafoDirecionado.InserirRotuloAresta("Matheus", 1, 2);
// grafoDirecionado.InserirRotuloAresta("Joao Cesar",1,2);
//Essa aresta não existe
//grafoDirecionado.InserirRotuloAresta("Jose Faria", 2, 3);

// Checagem de adjacência entre vértices
//Console.WriteLine(grafoDirecionado.VerificaAdjacenciaEntreVertices(1,2) ? "Existe" : "Não existe");

// Checagem de adjacência entre arestas
// Elas tem que ter um vertice em comum para ser adjacentes
//Console.WriteLine(grafoDirecionado.VerificaAdjacenciaEntreArestas(1,2,2,4) ? "São adjacentes" : "Não são adjacentes");

// Checagem da existência de arestas
//Console.WriteLine(grafoDirecionado.VerificaExistenciaAresta(1,2) ? "Existe essa aresta" : "Não existe essa aresta");

// Checagem da quantidade de vértices e arestas
//Console.WriteLine(grafoDirecionado.GetQuantidadeArestas());
//Console.WriteLine(grafoDirecionado.GetQuantidadeVertices());

// Checagem de grafo vazio e completo
//Console.WriteLine(grafoDirecionado.VerificaGrafoVazio() ? "É Vazio" : "Não é vazio");
//Console.WriteLine();
//grafoDirecionado.VerificaGrafoCompleto();

// Checagem de conectividade em simplismente conexo, semi-fortemente conexo e fortemente conexo
//grafoDirecionado.IsSimplesmenteConexo();
//TODO: grafoDirecionado.IsSemiFortementeConexo();
//grafoDirecionado.IsFortementeConexo();

// Checagem de quantidade de componentes fortemente conexos com Kosaraju

// TODO: Checagem de ponte e articulação

// Representação de grafos utilizando Matriz de Adjacência

// Representação de grafos utilizando Matriz de Incidência

// Representação de grafos utilizando Lista de Adjacência

// Uma ponte em um grafo é definido como uma aresta cuja remoção desconectado o grafoDirecionado. O problema de se determinar pontes existentes em um grafo apresenta várias aplicações, dentre elas encontrar caminhos (ou ciclos) eulerianos. Na segunda etapa deste trabalho você deverá  implementar dois métodos para identificação de pontes: (i) método naive em que testa-se a conectividade de um grafo para cada remoção de aresta (utilizando uma busca em largura ou profundidade por exemplo); e (ii) método baseado em Tarjan (artigo em anexo). Após implementadas as duas soluções para detecção de pontes, você deverá encontrar um caminho euleriano, usando Algoritmo de Fleury, em um grafo euleriano usando as duas estratégias implementadas. Ilustre os tempos computacionais necessários para as duas estratégias utilizando como teste grafos aleatórios simples contendo 100, 1000, 10000 e 100000 vértices.

// TODO: Gerar grafo aleatório a partir de um número de vertices
//Grafo gAleatorioVerticeEAresta = gerarGrafoNaoDirecionado.CriaGrafoAleatorio(5, 10);
//Grafo gAleatorioVertice = gerarGrafoNaoDirecionado.CriaGrafoAleatorioVertice(150);
//Grafo gAleatorioAresta = gerarGrafoNaoDirecionado.CriaGrafoAleatorioAresta(150);

// TODO: Gerar grafo aleatório a partir de um número de arestas

// Metodo para gerar um arquivo com as configuraçoes do grafo criado

// Metodo para Ler um arquivo e gerar um grafo

