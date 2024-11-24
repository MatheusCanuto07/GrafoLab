using PUCGrafos.domain.grafo;
using PUCGrafos.domain.grafo.gerarGrafo;
using PUCGrafos.domain.grafo.grafo_simples.grafo_simples_direcionado;
using PUCGrafos.domain.grafo.grafo_simples.grafo_simples_nao_direcionado;
using PUCGrafos.domain.utilidades;

#region Manipulacao
// Funções básicas para manipulação de grafos em ambas representações, incluindo:

// Criação de um grafo com X vértices (o número de vértices deve ser inserido pelo usuário)
void DemonstracaoCriarGrafo() {
    Grafo grafoNaoDirecionado = new GrafoNaoDirecionado(15);
    Grafo grafoDirecionado = new GrafoDirecionado(15);
}

//DemonstracaoCriarGrafo();

// Criação e remoção de arestas
void CriarRemoverArestas() {
    Grafo grafoNaoDirecionado = new GrafoNaoDirecionado(3);
    grafoNaoDirecionado.AdicionarAresta(1,2);
    grafoNaoDirecionado.AdicionarAresta(1,3);

    Grafo grafoDirecionado = new GrafoDirecionado(3);
    grafoDirecionado.AdicionarAresta(1,2);
    grafoDirecionado.AdicionarAresta(2,3);
}

//CriarRemoverArestas();

// Ponderação e rotulação de vértices e arestas
void PonderarRotularVerticesArestas() {
    Grafo grafoNaoDirecionado = new GrafoNaoDirecionado(2);
    grafoNaoDirecionado.AdicionarAresta(1,2);
    grafoNaoDirecionado.InserirRotuloVertice("A", 1);
    grafoNaoDirecionado.InserirRotuloAresta("Rua 3", 1, 2);

    Grafo grafoDirecionado = new GrafoDirecionado(3);
    grafoDirecionado.AdicionarAresta(1,2);
    grafoDirecionado.InserirRotuloVertice("B", 1);
    grafoDirecionado.InserirRotuloAresta("Rua 5", 1, 2);

    grafoNaoDirecionado.ImprimirMatrizAdjacencia();
    grafoDirecionado.ImprimirMatrizAdjacencia();

    grafoNaoDirecionado.ImprimirMatrizIncidencia();
    grafoDirecionado.ImprimirMatrizIncidencia();

    grafoNaoDirecionado.InserirPesoVertice(5, 1);
    grafoDirecionado.InserirPesoVertice(3, 1);

    Console.WriteLine($"Peso vertice 1 grafo não direcionado: {grafoNaoDirecionado.Vertices[0].GetPeso()}");
    Console.WriteLine($"Peso vertice 1 grafo direcionado: {grafoDirecionado.Vertices[0].GetPeso()}");
}

//PonderarRotularVerticesArestas();

// Checagem de adjacência
void DemonstracaoChecagemAdjacencia() {
    Grafo grafoNaoDirecionado = new GrafoNaoDirecionado(3);
    grafoNaoDirecionado.AdicionarAresta(1,2);
    grafoNaoDirecionado.AdicionarAresta(2,3);

    Grafo grafoDirecionado = new GrafoDirecionado(3);
    grafoDirecionado.AdicionarAresta(1,2);
    grafoDirecionado.AdicionarAresta(2,3);

    Console.WriteLine("Não direcionado");
    Console.WriteLine($"1 e 2 são adjascentes? {grafoNaoDirecionado.VerificaAdjacenciaEntreVertices(1,2)}");
    Console.WriteLine($"2 e 1 são adjascentes? {grafoNaoDirecionado.VerificaAdjacenciaEntreVertices(2,1)}");
    Console.Write("{1,2} e {2,3} são adjascentes? ");
    Console.WriteLine(grafoNaoDirecionado.VerificaAdjacenciaEntreArestas(1,2,2,3));

    Console.WriteLine("Direcionado");
    Console.WriteLine($"1 e 2 são adjascentes? {grafoDirecionado.VerificaAdjacenciaEntreVertices(1,2)}");
    Console.WriteLine($"2 e 1 são adjascentes? {grafoDirecionado.VerificaAdjacenciaEntreVertices(2,1)}");
    Console.Write("(1,2) e (2,3) são adjascentes? ");
    Console.WriteLine(grafoDirecionado.VerificaAdjacenciaEntreArestas(1,2,2,3));

}

//DemonstracaoChecagemAdjacencia();

// Checagem da quantidade de vértices e arestas
void DemonstracaoChecarQtdArestasVertices() {
    Grafo grafoNaoDirecionado = new GrafoNaoDirecionado(3);
    grafoNaoDirecionado.AdicionarAresta(1,2);
    grafoNaoDirecionado.AdicionarAresta(2,3);

    Grafo grafoDirecionado = new GrafoDirecionado(3);
    grafoDirecionado.AdicionarAresta(1,2);

    Console.WriteLine("Não direcionado");
    Console.WriteLine($"Vertices: {grafoNaoDirecionado.GetQuantidadeVertices()}");
    Console.WriteLine($"Arestas: {grafoNaoDirecionado.GetQuantidadeArestas()}");

    Console.WriteLine("Direcionado");
    Console.WriteLine($"Vertices: {grafoDirecionado.GetQuantidadeVertices()}");
    Console.WriteLine($"Arestas: {grafoDirecionado.GetQuantidadeArestas()}");
}

//DemonstracaoChecarQtdArestasVertices();

void DemonstracaoChecarVazioCompleto() {
    Grafo grafoNaoDirecionado = new GrafoNaoDirecionado(3);
    grafoNaoDirecionado.AdicionarAresta(1,2);
    grafoNaoDirecionado.AdicionarAresta(1,3);
    grafoNaoDirecionado.AdicionarAresta(2,3);

    Grafo grafoDirecionado = new GrafoDirecionado(3);

    Console.WriteLine("Não direcionado");
    Console.WriteLine($"Vazio? {grafoNaoDirecionado.VerificaGrafoVazio()}");
    Console.WriteLine($"Completo? {grafoNaoDirecionado.VerificaGrafoCompleto()}");

    Console.WriteLine("Direcionado");
    Console.WriteLine($"Vazio? {grafoDirecionado.VerificaGrafoVazio()}");
    Console.WriteLine($"Completo? {grafoDirecionado.VerificaGrafoCompleto()}");
}

//DemonstracaoChecarVazioCompleto();

void DemonstracaoConectividade() {
    Grafo grafoNaoDirecionado = new GrafoNaoDirecionado(3);
    grafoNaoDirecionado.AdicionarAresta(1,2);
    grafoNaoDirecionado.AdicionarAresta(1,3);

    Grafo grafoDirecionado = new GrafoDirecionado(3);
    grafoDirecionado.AdicionarAresta(1,2);
    grafoDirecionado.AdicionarAresta(1,3);

    Console.WriteLine("Não direcionado");
    Console.WriteLine($"S-Conexo? {grafoNaoDirecionado.IsSimplesmenteConexo()}");

    Console.WriteLine("Direcionado");
    Console.WriteLine($"SF-Conexo? {grafoDirecionado.IsSemiFortementeConexo()}");
    Console.WriteLine($"F-Conexo? {grafoDirecionado.IsFortementeConexo()}");
}

//DemonstracaoConectividade();

void DemonstracaoComponentesFConexosKosaraju() {
    Grafo grafo = new GrafoDirecionado(7);

    grafo.AdicionarAresta(1, 2);
    grafo.AdicionarAresta(1, 4);

    grafo.AdicionarAresta(2, 5);

    grafo.AdicionarAresta(5, 3);
    grafo.AdicionarAresta(5, 7);

    grafo.AdicionarAresta(3, 1);
    grafo.AdicionarAresta(3, 6);

    grafo.AdicionarAresta(4, 6);

    grafo.AdicionarAresta(6, 7);

    grafo.AdicionarAresta(7, 6);

    Console.WriteLine($"Componentes F-Conexos: {grafo.GetComponentesFConexosKosaraju()}");
}

//DemonstracaoComponentesFConexosKosaraju();

void DemonstracaoBuscaPontesArticulacoes() {
    Grafo grafoNaoDirecionado = new GrafoNaoDirecionado(3);
    grafoNaoDirecionado.AdicionarAresta(1,2);
    grafoNaoDirecionado.AdicionarAresta(2,3);

    Grafo grafoDirecionado = new GrafoDirecionado(3);
    grafoDirecionado.AdicionarAresta(1,2);
    grafoDirecionado.AdicionarAresta(1,3);

    Console.WriteLine("[Não direcionado] Pontes por Tarjan");
    foreach (var ponte in grafoNaoDirecionado.BuscaPontesTarjan())
    {
        Console.WriteLine("({0},{1})",grafoNaoDirecionado.Vertices[ponte.Item1].GetRotulo(),grafoNaoDirecionado.Vertices[ponte.Item2].GetRotulo());
    }

    Console.WriteLine("[Não direcionado] Pontes por Naive");
    foreach (var ponte in grafoNaoDirecionado.BuscaPontesNaive())
    {
        Console.WriteLine("({0},{1})",grafoNaoDirecionado.Vertices[ponte.Item1].GetRotulo(),grafoNaoDirecionado.Vertices[ponte.Item2].GetRotulo());
    }

    Console.WriteLine("[Direcionado] Pontes por Tarjan");
    foreach (var ponte in grafoDirecionado.BuscaPontesTarjan())
    {
        Console.WriteLine("({0},{1})",grafoDirecionado.Vertices[ponte.Item1].GetRotulo(),grafoDirecionado.Vertices[ponte.Item2].GetRotulo());
    }

    Console.WriteLine("[Direcionado] Pontes por Naive");
    foreach (var ponte in grafoDirecionado.BuscaPontesNaive())
    {
        Console.WriteLine("({0},{1})",grafoDirecionado.Vertices[ponte.Item1].GetRotulo(),grafoDirecionado.Vertices[ponte.Item2].GetRotulo());
    }

    Console.WriteLine("[Não direcionado] Articulações");
    foreach (var artic in grafoNaoDirecionado.BuscarArticulacoes())
    {
        Console.WriteLine("{0} ",grafoNaoDirecionado.Vertices[artic].GetRotulo());
    }

    Console.WriteLine("[Direcionado] Articulações");
    foreach (var artic in grafoDirecionado.BuscarArticulacoes())
    {
        Console.WriteLine("{0} ",grafoDirecionado.Vertices[artic].GetRotulo());
    }
}

//DemonstracaoBuscaPontesArticulacoes();

#endregion

#region Representações

void ImprimirRepresentações() {
    Grafo grafoNaoDirecionado = new GrafoNaoDirecionado(3);
    grafoNaoDirecionado.AdicionarAresta(1,2);
    grafoNaoDirecionado.AdicionarAresta(2,3);

    Grafo grafoDirecionado = new GrafoDirecionado(3);
    grafoDirecionado.AdicionarAresta(1,2);
    grafoDirecionado.AdicionarAresta(1,3);

    grafoDirecionado.ImprimirMatrizAdjacencia();
    grafoDirecionado.ImprimirMatrizIncidencia();
    grafoDirecionado.ImprimirListaAdjacencia();

    grafoNaoDirecionado.ImprimirMatrizAdjacencia();
    grafoNaoDirecionado.ImprimirMatrizIncidencia();
    grafoNaoDirecionado.ImprimirListaAdjacencia();
}

//ImprimirRepresentações()

#endregion

#region Testes de grafo euleriano

void TesteGrafoEuleriano() {

    Grafo g = new GrafoNaoDirecionado(7);

    g.AdicionarAresta(1,2);
    g.AdicionarAresta(1,3);

    g.AdicionarAresta(2,3);
    g.AdicionarAresta(2,4);
    g.AdicionarAresta(2,5);

    g.AdicionarAresta(3,4);
    g.AdicionarAresta(3,6);

    g.AdicionarAresta(4,5);
    g.AdicionarAresta(4,6);

    g.AdicionarAresta(5,6);
    g.AdicionarAresta(5,7);

    g.AdicionarAresta(6,7);

    if (false) { // Marcar como true para medir o tempo de execução do algoritmo de Fleury 
        g.EnableClock();
    }

    g.ImprimirCaminhoEuleriano();       // Fleury com busca de pontes Tarjan
    g.ImprimirCaminhoEulerianoNaive();  // Naive com busca de pontes Naive

}

//TesteGrafoEuleriano();

#endregion

void DemonstracaoGrafoAleatorio() {

    Grafo grafoEuleriano = gerarGrafoNaoDirecionado.CriaGrafoAleatorioAresta(15);

    grafoEuleriano.ImprimirListaAdjacencia();

}

//DemonstracaoGrafoAleatorio()

void DemonstracaoGrafoEulerianoAleatorio() {

    GrafoNaoDirecionado g = gerarGrafoNaoDirecionado.CriaAleatorioGrafoEuleriano(100);

    Utilidades.SalvaEmCSV(g);

    g.ImprimirCaminhoEuleriano();

}

DemonstracaoGrafoEulerianoAleatorio();

