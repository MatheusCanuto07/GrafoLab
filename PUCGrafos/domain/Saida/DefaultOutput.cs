using PUCGrafos.domain.grafo;
using PUCGrafos.domain.interfaces;
using PUCGrafos.domain.utilidades;
using PUCGrafos.domain.vertice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUCGrafos.domain.Saida
{
    internal class DefaultOutput : IGrafoOutput
    {

        protected Grafo grafo;

        public DefaultOutput(Grafo grafoObj) { 
            this.grafo = grafoObj;
        }

        public void ImprimirArticulacoes()
        {
            Console.WriteLine("Articulações: ");
            foreach (int articulacao in this.grafo.BuscarArticulacoes())
            {
                Console.Write($"{Utilidades.GetIDVerticeExterno(articulacao)}, ");
            }
            Console.WriteLine();
        }

        public void ImprimirBFS()
        {
            ResultadoBusca[] resultado = this.grafo.GetResultadoBuscaEmLargura();
        }

        public void ImprimirCaminhoEuleriano()
        {
            List<int> caminho = new();
            if (grafo.IsClockEnabled()) {
                grafo.clockMeter.Start();
                caminho = grafo.GetCaminhoEuleriano();
                grafo.clockMeter.Stop();
                Console.WriteLine($"[Fleury Tarjan] Duração: {grafo.clockMeter.ElapsedMilliseconds} ms");
            } else {
                caminho = grafo.GetCaminhoEuleriano();
            }

            Console.WriteLine("Caminho Euleriano Método Fleury Tarjan: ");
            foreach (int vertice in caminho)
            {
                Console.Write($"{Utilidades.GetIDVerticeExterno(vertice)} ");
            }

            Console.WriteLine();
        }

        public void ImprimirCaminhoEulerianoNaive()
        {
            List<int> caminho = new();
            if (grafo.IsClockEnabled()) {
                grafo.clockMeter.Start();
                caminho = grafo.GetCaminhoEulerianoNaive();
                grafo.clockMeter.Stop();
                Console.WriteLine($"[Fleury Naive] Duração: {grafo.clockMeter.ElapsedMilliseconds} ms");
            } else {
                caminho = grafo.GetCaminhoEulerianoNaive();
            }

            Console.WriteLine("Caminho Euleriano Método Fleury Naive: ");
            foreach (int vertice in caminho)
            {
                Console.Write($"{Utilidades.GetIDVerticeExterno(vertice)} ");
            }

            Console.WriteLine();
        }

        public void ImprimirDFS()
        {
            ResultadoBusca[] resultado = this.grafo.GetResultadoBuscaEmProfundidade();

            foreach (ResultadoBusca item in resultado)
            {
                string rotulo = this.grafo.Vertices[item.IdVertice].GetRotulo();
                string rotuloPai = (item.IdPai != Constantes.VerticeInexistente) ? this.grafo.Vertices[item.IdPai].GetRotulo() : "Ø";
                Console.WriteLine($"|{rotulo}|TD: {item.Descoberta}; TT: {item.Termino}; Pai: {rotuloPai}");
            }
        }

    public void ImprimirPontesPorNaive()
        {
            List<(int,int)> pontes = grafo.BuscaPontesNaive();

            foreach (var ponte in pontes) {
                Console.WriteLine($"({ponte.Item1}, {ponte.Item2})");
            }
        }

        public void ImprimirPontesPorTarjan()
        {
            List<(int,int)> pontes = grafo.BuscaPontesTarjan();

            foreach (var ponte in pontes) {
                Console.WriteLine($"({ponte.Item1}, {ponte.Item2})");
            }
        }

        void IGrafoOutput.ImprimirMatrizAdjacencia()
        {
            int[,] matriz = grafo.MatrizAdjacencia;
            const string separator = "|";

            Console.Write("|Matriz Adjacência|\n  ");

            for (int j = 0; j < grafo.Vertices.Length; j++)
            {
                Console.Write(separator + grafo.Vertices[j].GetRotulo());
            }

            Console.WriteLine(separator);

            for (int i = 0; i < grafo.Vertices.Length; i++)
            {
                Console.Write(separator + grafo.Vertices[i].GetRotulo());

                for (int j = 0; j < grafo.Vertices.Length; j++)
                {
                    Console.Write(separator + matriz[i,j]);
                }

                Console.WriteLine(separator);
            }

        }

        void IGrafoOutput.ImprimirMatrizIncidencia()
        {
            Console.WriteLine("|Matriz Incidência|");
            foreach (Vertice v in grafo.Vertices)
            {
                Console.Write(v.GetRotulo() + ":");

                foreach (string keyAresta in v.Incidencia)
                {
                    Console.Write(" " + grafo.Arestas[keyAresta].GetRotulo());
                }

                Console.WriteLine();
            }
        }
      void IGrafoOutput.ImprimirListaAdjacencia()
      {
        Console.WriteLine("Lista de adjacência");
        for (int i = 0; i < grafo.Vertices.Length; i++)
        {
          Console.Write($"Vértice {i + 1}: ");
          foreach (var item in grafo.Vertices[i].Adjacencia)
          {
            Console.Write($"{item + 1} ");
          }
          Console.WriteLine();
        }
    }
  }
}
