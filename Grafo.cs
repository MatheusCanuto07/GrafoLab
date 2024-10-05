using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafoLab
{
    public class Grafo
    {
        private int _numeroVertices;
        private List<int>[] _listaAdjacencia;

        // Construtor que inicializa o grafo com o número de vértices
        public Grafo(int numeroVertices)
        {
            _numeroVertices = numeroVertices;
            _listaAdjacencia = new List<int>[_numeroVertices];

            // Inicializa cada lista de adjacência
            for (int i = 0; i < _numeroVertices; i++)
            {
                _listaAdjacencia[i] = new List<int>();
            }
        }

        // Método para adicionar uma aresta ao grafo
        public void AdicionarAresta(int verticeInicio, int verticeFim)
        {
            if (verticeInicio >= 0 && verticeInicio < _numeroVertices &&
                verticeFim >= 0 && verticeFim < _numeroVertices)
            {
                _listaAdjacencia[verticeInicio].Add(verticeFim);
                _listaAdjacencia[verticeFim].Add(verticeInicio); // Para um grafo não direcionado
            }
            else
            {
                throw new ArgumentOutOfRangeException("Vértice fora do intervalo válido.");
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
    }
}

