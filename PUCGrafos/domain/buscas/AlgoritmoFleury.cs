using PUCGrafos.domain.grafo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PUCGrafos.domain.buscas
{


    public abstract class AlgoritmoFleury
    {
        protected Grafo grafo;

        public AlgoritmoFleury(Grafo grafo)
        {
            this.grafo = grafo;
        }

        public List<int> GetCaminhoEuleriano()
        {
            // Verifica se o grafo possui um caminho/circuito Euleriano
            if (!TemCaminhoOuCircuitoEuleriano())
            {
                throw new InvalidOperationException("O grafo não possui caminho ou circuito Euleriano.");
            }

            Grafo copia = this.grafo.GetCopia(); // Faz uma cópia do grafo
            List<int> caminho = new List<int>(); // Lista para armazenar o caminho Euleriano

            // Começa pelo vértice com grau ímpar (se existir) ou qualquer vértice
            int verticeAtual = EncontrarInicioEuleriano(copia);

            while (copia.GetQuantidadeArestas() != 0)
            {
                //List<int> vizinhos = copia.Vertices[verticeAtual].Adjacencia;

                // Escolhe uma aresta para remover, priorizando as não-pontes
                (int IdOrigem, int IdDestino) arestaEscolhida = EscolherAresta(copia, verticeAtual, copia.Vertices[verticeAtual].Adjacencia);

                // Adiciona o vértice ao caminho e remove a aresta
                caminho.Add(verticeAtual);
                copia.RemoverAresta(arestaEscolhida.IdOrigem, arestaEscolhida.IdDestino, true);

                // Avança para o próximo vértice
                verticeAtual = arestaEscolhida.Item2;
            }

            // Adiciona o último vértice ao caminho
            caminho.Add(verticeAtual);
            return caminho;
        }

        private bool TemCaminhoOuCircuitoEuleriano()
        {
            // Um grafo possui circuito Euleriano se todos os vértices têm grau par
            // Ele possui um caminho Euleriano se exatamente dois vértices têm grau ímpar
            int verticesImpares = grafo.Vertices.Count(v => v.Grau % 2 != 0);
            return verticesImpares == 0 || verticesImpares == 2;
        }

        private int EncontrarInicioEuleriano(Grafo grafo)
        {
            // Retorna um vértice com grau ímpar se existir, ou qualquer vértice
            foreach (var vertice in grafo.Vertices)
            {
                if (vertice.Grau % 2 != 0)
                {
                    return vertice.Id;
                }
            }
            return grafo.Vertices.First().Id;
        }

        protected abstract List<(int, int)> BuscarPontes(Grafo g);

        private (int IdOrigem, int IdDestino) EscolherAresta(Grafo grafo, int verticeAtual, List<int> vizinhos)
        {
            List<(int, int)> pontes = this.BuscarPontes(grafo);

            foreach (int vertice in vizinhos)
            {
                // Verifica se a aresta é uma ponte
                if (!pontes.Contains((verticeAtual, vertice))) {
                    if (!grafo.IsDirecionado() && !pontes.Contains((vertice, verticeAtual))) {
                        return (verticeAtual, vertice);
                    }
                }
            }

            // Se todas as arestas forem pontes, retorna a primeira
            return (verticeAtual, vizinhos.FirstOrDefault());
        }
    }

}