using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using PUCGrafos.domain.grafo;
using PUCGrafos.domain.grafo.grafo_simples.grafo_simples_direcionado;
using System.IO;

namespace PUCGrafos.domain.utilidades
{
    public class Utilidades
    {
        public static int GetBinarySearchIndex<T>(T item, List<T> lista, ref bool found)
        {
            int index = lista.BinarySearch(item);

            found = (index >= 0);

            return (found) ? index : ~index;
        }

        public static int GetIDVerticeInterno(int id)
        {
            return id - 1;
        }

        public static int GetIDVerticeExterno(int id)
        {
            return id + 1;
        }

        public static void SalvaEmCSV(Grafo grafo)
        {
            string caminhoArquivo = @"..\..\..\Arquivos\grafo.csv";
          
                using (StreamWriter escritor = new StreamWriter(caminhoArquivo))
                {
                    for (int i = 0; i < grafo.Vertices.Length; i++)
                    {               
                        string linha = $"{i};";
   
                            // Adiciona os vértices adjacentes separados por ponto e vírgula
                            foreach (int vertice in grafo.Vertices[i].Adjacencia)
                            {
                                linha += $"{vertice};";
                            }
                       

                        // Escreve a linha no arquivo CSV
                        escritor.WriteLine(linha);
                    }
                }

                Console.WriteLine("Dados do grafo salvos com sucesso em: " + caminhoArquivo);
           
            
           
        }
        public static void LerArquivo(string _caminho_arquivo){
            //depois que pergar o n vertices eu instancio
            int TotalVertices = 0;
            
                string[] linhas = File.ReadAllLines(_caminho_arquivo);

                 TotalVertices = linhas.Length;
                 GrafoDirecionado grafoDirecionado= new GrafoDirecionado(TotalVertices);

                 foreach(string linha in linhas){
                    if(string.IsNullOrWhiteSpace(linha))
                    continue;

                    string[] Vertices = linha.Split(';');

                    //vertice nó origem
                    string origem = Vertices[0];

                    for(int i = 1; i < Vertices.Length; i++){

                        string VeticeDestino = Vertices[i];
                        if (VeticeDestino == ""){
                            continue;

                        }
                        int idorigemInterno = Utilidades.GetIDVerticeExterno(int.Parse(origem));
                        int idVerticeDestino = Utilidades.GetIDVerticeExterno(int.Parse(VeticeDestino));
                        grafoDirecionado.AdicionarAresta(idorigemInterno ,idVerticeDestino);

                        Console.WriteLine($"({origem}, {VeticeDestino})");
                    }
                 }

                
           
            
           
        }
    }
}
