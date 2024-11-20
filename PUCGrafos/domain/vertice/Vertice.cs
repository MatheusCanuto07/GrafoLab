using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PUCGrafos.domain.grafo;
using PUCGrafos.domain.interfaces;
using PUCGrafos.domain.utilidades;

namespace PUCGrafos.domain.vertice
{
    public class Vertice : IRotulavel, IPonderavel
    {
        private Grafo Grafo { get; }

        private List<int> adjacencia = new List<int>();
        private List<string> incidencia = new List<string>();

        private List<int> sucessores = new List<int>();
        private List<int> predecessores = new List<int>();

        private int ID;
        private string rotulo = string.Empty;
        private int peso = 0;
        private int grau = 0;

        public int Id { get => ID; set => ID = value; }
        public List<int> Adjacencia { get => adjacencia; private set => adjacencia = value; }
        public List<string> Incidencia { get => incidencia; private set => incidencia = value; }
        public List<int> Sucessores { get => sucessores; private set => sucessores = value; }
        public List<int> Predecessores { get => predecessores; private set => predecessores = value; }

        public Vertice(Grafo grafo, int ID) { 
            this.Id = ID;
            this.Grafo = grafo;
        }

        public void AdicionarSucessor(int idDestino)
        {
            bool found = false;
            int index = Utilidades.GetBinarySearchIndex(idDestino, Sucessores, ref found);

            if (found) { return; }
   
            Sucessores.Insert(index, idDestino);
            grau++;
        }

        public void RemoveSucessor(int idDestino)
        {
            bool found = false;
            int index = Utilidades.GetBinarySearchIndex(idDestino, Sucessores, ref found);

            if (!found) {  return; }

            Sucessores.RemoveAt(index);
            grau--;
        }

        public void AdicionarPredecessor(int idOrigem)
        {
            bool found = false;
            int index = Utilidades.GetBinarySearchIndex(idOrigem, Predecessores, ref found);

            if (found) { return; }

            Predecessores.Insert(index, idOrigem);
            grau++;
        }

        public void RemovePredecessor(int idOrigem)
        {
            bool found = false;
            int index = Utilidades.GetBinarySearchIndex(idOrigem, Predecessores, ref found);

            if (!found) { return; }

            Predecessores.RemoveAt(index);
            grau--;
        }

        public void AdicionarAdjacente(int IdVertice)
        {
            bool found = false;
            int index = Utilidades.GetBinarySearchIndex(IdVertice, this.Adjacencia, ref found);
            
            if (found) { return; }

            this.Adjacencia.Insert(index, IdVertice);
        }

        public void RemoverAdjacente(int IdVertice)
        {
            bool found = false;
            int index = Utilidades.GetBinarySearchIndex(IdVertice, this.Adjacencia, ref found);

            if (!found) { return; }

            this.Adjacencia.RemoveAt(index);
        }

        public void AdicionarIncidente(string KeyAresta)
        {
            bool found = false;
            int index = Utilidades.GetBinarySearchIndex(KeyAresta, this.Incidencia, ref found);

            if (found) { return; }

            this.Incidencia.Insert(index, KeyAresta);
        }

        public void RemoverIncidente(string KeyAresta)
        {
            bool found = false;
            int index = Utilidades.GetBinarySearchIndex(KeyAresta, this.Incidencia, ref found);
            
            if (!found) { return; }

            this.Incidencia.RemoveAt(index);
        }

        public void SetPeso(int Peso)
        {
            if (Peso < 0) { Peso = 0; }
            this.peso = Peso;
        }

        public int GetPeso()
        {
            return this.peso;
        }

        public void SetRotulo(string rotulo)
        {
            this.rotulo = rotulo;
        }

        public string GetRotulo()
        {
            return (rotulo == String.Empty) ? Utilidades.GetIDVerticeExterno(this.Id).ToString() : rotulo;
        }

        public void MontaRotulo()
        {
            throw new NotImplementedException();
        }

    }
}
