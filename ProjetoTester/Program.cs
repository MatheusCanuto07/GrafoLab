using PUCGrafos.domain.grafo;
using PUCGrafos.domain.grafo.grafo_simples.grafo_simples_direcionado;
using PUCGrafos.domain.grafo.grafo_simples.grafo_simples_nao_direcionado;

Grafo grafo = new GrafoDirecionado(6);

grafo.InserirRotuloVertice("c", 1);
grafo.InserirRotuloVertice("a", 2);
grafo.InserirRotuloVertice("e", 3);
grafo.InserirRotuloVertice("b", 4);
grafo.InserirRotuloVertice("f", 5);
grafo.InserirRotuloVertice("d", 6);

grafo.AdicionarAresta(1, 2);
grafo.AdicionarAresta(1, 3);

grafo.AdicionarAresta(2, 4);
grafo.AdicionarAresta(2, 5);

grafo.AdicionarAresta(3, 4);
grafo.AdicionarAresta(3, 5);

grafo.AdicionarAresta(4, 6);
grafo.AdicionarAresta(5, 4);

grafo.AdicionarAresta(6, 5);

grafo.RealizarBuscaEmProfundidade(3);

grafo.ImprimirResultadoDFS();

//grafo.InserirRotuloAresta("Joao Cesar",1,2);
//grafo.InserirRotuloAresta("Jose Faria", 2, 3);

//grafo.ImprimirMatrizAdjacencia();
//grafo.ImprimirMatrizIncidencia();



