﻿using PUCGrafos.domain.aresta;
using PUCGrafos.domain.buscas;
using PUCGrafos.domain.exceptions;
using PUCGrafos.domain.grafo.grafo_simples.grafo_simples_nao_direcionado;
using PUCGrafos.domain.interfaces;
using PUCGrafos.domain.Saida;
using PUCGrafos.domain.utilidades;
using PUCGrafos.domain.vertice;


namespace PUCGrafos.domain.grafo
{
    public abstract class Grafo
    {
        public Vertice[] Vertices { get; protected set; }
        public Dictionary<string, Aresta> Arestas { get ; protected set ; }

        public int[,] MatrizAdjacencia { get ; protected set ; }

        protected ResultadoBusca[] ResultadoBuscaEmLargura;
        protected ResultadoBusca[] ResultadoBuscaEmProfundidade;

        protected IGrafoOutput outputObject;

        protected IBuscaEmGrafo ObjBuscaEmLargura;
        protected IBuscaEmGrafo ObjBuscaEmProfundidade;

        public Grafo(int NumVertices) {
            InicializaMembros(NumVertices);

            InicializaObjetoSaida();

            InicializaObjetoDeBuscas();
        }

        public abstract bool IsDirecionado();

        public abstract int GetMaximoArestas();

        public abstract bool IsSimplesmenteConexo();

        public abstract bool IsSemiFortementeConexo();

        public abstract bool IsFortementeConexo();

        public Grafo GetSubjascente()
        {
            int IdOrigemExterno, IdDestinoExterno;
            GrafoNaoDirecionado grafo = new GrafoNaoDirecionado(this.Vertices.Length);

            foreach (string key in Arestas.Keys)
            {
                IdOrigemExterno  = Utilidades.GetIDVerticeExterno(Arestas[key].GetIdOrigem());
                IdDestinoExterno = Utilidades.GetIDVerticeExterno(Arestas[key].GetIdDestino());
                grafo.AdicionarAresta(IdOrigemExterno, IdDestinoExterno);
            }

            return grafo;
        }

        public void AdicionarAresta(int IdOrigem, int IdDestino, int Peso = 0)
        {
            IdOrigem  = Utilidades.GetIDVerticeInterno(IdOrigem);
            IdDestino = Utilidades.GetIDVerticeInterno(IdDestino);

            if (!VerticeValido(IdOrigem) || !VerticeValido(IdDestino))
            {
                throw new ExceptionArestaInvalida();
            }

            string key = Aresta.GerarKey(IdOrigem, IdDestino);

            if (Arestas.ContainsKey(key))
            {
                throw new ExceptionArestaInvalida();
            }

            Aresta newAresta = new Aresta(this, this.Vertices[IdOrigem], this.Vertices[IdDestino]);
            newAresta.SetPeso(Peso);

            this.Vertices[IdOrigem].AdicionarIncidente(key);
            this.Vertices[IdDestino].AdicionarIncidente(key);

            this.MatrizAdjacencia[IdOrigem, IdDestino] = newAresta.GetPeso();
            this.Vertices[IdOrigem].AdicionarAdjacente(IdDestino);

            this.Vertices[IdOrigem].AdicionarSucessor(IdDestino);
            this.Vertices[IdDestino].AdicionarPredecessor(IdOrigem);

            if (!IsDirecionado())
            {
                this.MatrizAdjacencia[IdDestino, IdOrigem] = newAresta.GetPeso();
                this.Vertices[IdDestino].AdicionarAdjacente(IdOrigem);

                this.Vertices[IdDestino].AdicionarSucessor(IdOrigem);
                this.Vertices[IdOrigem].AdicionarPredecessor(IdDestino);
            }

            Arestas[key] = newAresta;

        }

        public void RemoverAresta(int IdOrigem, int IdDestino)
        {

            IdOrigem  = Utilidades.GetIDVerticeInterno(IdOrigem);
            IdDestino = Utilidades.GetIDVerticeInterno(IdDestino);

            if (!VerticeValido(IdOrigem) || !VerticeValido(IdDestino))
            {
                throw new ExceptionArestaInvalida();
            }

            string key = Aresta.GerarKey(IdOrigem, IdDestino);

            if (!Arestas.ContainsKey(key))
            {
                return;
            }

            this.Vertices[IdOrigem].RemoverIncidente(key);
            this.Vertices[IdDestino].RemoverIncidente(key);

            this.MatrizAdjacencia[IdOrigem, IdDestino] = Constantes.ArestaInexistente;
            this.Vertices[IdOrigem].RemoverAdjacente(IdDestino);

            this.Vertices[IdOrigem].RemoveSucessor(IdDestino);
            this.Vertices[IdDestino].RemovePredecessor(IdOrigem);

            if (!IsDirecionado())
            {
                this.MatrizAdjacencia[IdDestino, IdOrigem] = Constantes.ArestaInexistente;
                this.Vertices[IdDestino].RemoverAdjacente(IdOrigem);

                this.Vertices[IdDestino].RemoveSucessor(IdOrigem);
                this.Vertices[IdOrigem].RemovePredecessor(IdDestino);
            }

            Arestas.Remove(key);

        }

        public void InserirRotuloVertice(string rotulo, int IdVertice)
        {
            IdVertice = Utilidades.GetIDVerticeInterno(IdVertice);

            if (!VerticeValido(IdVertice)) {
                throw new ExceptionVerticeInvalido();
            }

            this.Vertices[IdVertice].SetRotulo(rotulo);
        }

        public void InserirRotuloAresta(string rotulo, int IdVerticeOrigem, int IdVerticeDestino)
        {
            IdVerticeOrigem = Utilidades.GetIDVerticeInterno(IdVerticeOrigem);
            IdVerticeDestino = Utilidades.GetIDVerticeInterno(IdVerticeDestino);

            if (!VerticeValido(IdVerticeOrigem) || !VerticeValido(IdVerticeDestino))
            {
                throw new ExceptionArestaInvalida();
            }

            string key = Aresta.GerarKey(IdVerticeOrigem, IdVerticeDestino);

            if (!Arestas.ContainsKey(key))
            {
                throw new ExceptionArestaInvalida();
            }

            this.Arestas[key].SetRotulo(rotulo);
        }

        public bool VerificaAdjacenciaEntreVertices(int IdVerticeA, int IdVerticeB)
        {
            IdVerticeA = Utilidades.GetIDVerticeInterno(IdVerticeA);
            IdVerticeB = Utilidades.GetIDVerticeInterno(IdVerticeB);

            if (!VerticeValido(IdVerticeA) || !VerticeValido(IdVerticeB))
            {
                throw new ExceptionVerticeInvalido();
            }

            return ( this.MatrizAdjacencia[IdVerticeA, IdVerticeB] != Constantes.ArestaInexistente );
        }

        public bool VerificaAdjacenciaEntreArestas(int IdOrigemA, int IdDestinoA, int IdOrigemB, int IdDestinoB)
        {
            IdOrigemA = Utilidades.GetIDVerticeInterno(IdOrigemA);
            IdDestinoA = Utilidades.GetIDVerticeInterno(IdDestinoA);

            if (!VerticeValido(IdOrigemA)  || 
                !VerticeValido(IdDestinoA) ||
                !VerticeValido(IdOrigemB)  ||
                !VerticeValido(IdDestinoB) )
            {
                throw new ExceptionVerticeInvalido();
            }

            if (!VerificaExistenciaAresta(IdOrigemA, IdDestinoA) ||
                !VerificaExistenciaAresta(IdOrigemB, IdDestinoB))
            {
                return false;
            }

            return (
                IdOrigemA  == IdOrigemB  ||
                IdOrigemA  == IdDestinoB ||
                IdDestinoA == IdOrigemB  ||
                IdDestinoA == IdDestinoB
            );
        }

        public bool VerificaExistenciaAresta(int IdOrigem, int IdDestino)
        {
            IdOrigem = Utilidades.GetIDVerticeInterno(IdOrigem);
            IdDestino = Utilidades.GetIDVerticeInterno(IdDestino);

            if (!VerticeValido(IdOrigem) || !VerticeValido(IdDestino))
            {
                throw new ExceptionArestaInvalida();
            }

            return (this.MatrizAdjacencia[IdOrigem, IdDestino] != Constantes.ArestaInexistente);
        }

        public int GetQuantidadeVertices()
        {
            return this.Vertices.Length;
        }

        public int GetQuantidadeArestas()
        {
            return this.Arestas.Count;
        }

        public bool VerificaGrafoVazio()
        {
            return this.Arestas.Count == 0;
        }

        public bool VerificaGrafoCompleto()
        {
            return this.Arestas.Count == GetMaximoArestas();
        }

        public void RealizarBuscaEmLargura(int IdVerticeInicio = 1)
        {
            IdVerticeInicio = Utilidades.GetIDVerticeInterno(IdVerticeInicio);
            this.ObjBuscaEmLargura.SetVerticeInicial(IdVerticeInicio);
            this.ObjBuscaEmLargura.Processar();
            this.ResultadoBuscaEmLargura = this.ObjBuscaEmLargura.GetResultado();
        }

        public ResultadoBusca[] GetResultadoBuscaEmLargura()
        {
            return this.ResultadoBuscaEmLargura;
        }

        public void RealizarBuscaEmProfundidade(int IdVerticeInicio = 1)
        {
            IdVerticeInicio = Utilidades.GetIDVerticeInterno(IdVerticeInicio);
            this.ObjBuscaEmProfundidade.SetVerticeInicial(IdVerticeInicio);
            this.ObjBuscaEmProfundidade.Processar();
            this.ResultadoBuscaEmProfundidade = this.ObjBuscaEmProfundidade.GetResultado();
        }

        public ResultadoBusca[] GetResultadoBuscaEmProfundidade()
        {
            return this.ResultadoBuscaEmProfundidade;
        }

        public void ImprimirMatrizIncidencia()
        {
            this.outputObject.ImprimirMatrizIncidencia();
        }

        public void ImprimirMatrizAdjacencia()
        {
            this.outputObject.ImprimirMatrizAdjacencia();
        }

        public void ImprimirResultadoDFS()
        {
            this.outputObject.ImprimirDFS();
        }

        protected void InicializaObjetoDeBuscas()
        {
            this.ObjBuscaEmLargura      = new BuscaEmLargura(this);
            this.ObjBuscaEmProfundidade = new BuscaEmProfundidade(this);
        }

        protected void InicializaObjetoSaida()
        {
            this.outputObject = new DefaultOutput(this);
        }

        protected void InicializaMembros(int NumVertices)
        {
            this.Vertices = new Vertice[NumVertices];
            this.Arestas = new Dictionary<string, Aresta>();
            this.MatrizAdjacencia = new int[NumVertices, NumVertices];

            for (int i = 0; i < NumVertices; i++)
            {
                this.Vertices[i] = new Vertice(this, i);

                for (int j = 0; j < NumVertices; j++)
                {
                    this.MatrizAdjacencia[i, j] = Constantes.ArestaInexistente;
                }
            }
        }
        public bool IsTodosVerticesAlcançaveis(ResultadoBusca[] resultado) { 
            return !resultado.Any(
                (verticeProcessado) => verticeProcessado.Status == Constantes.VerticeNaoExplorado
            );
        }

        private bool VerticeValido(int IdVertice)
        {
            if (IdVertice < 0 || IdVertice >= this.Vertices.Length)
            {
                return false;
            }
            return true;
        }

    }
}