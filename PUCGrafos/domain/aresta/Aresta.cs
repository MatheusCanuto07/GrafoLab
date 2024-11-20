using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PUCGrafos.domain.grafo;
using PUCGrafos.domain.interfaces;
using PUCGrafos.domain.vertice;

namespace PUCGrafos.domain.aresta;

public class Aresta : IRotulavel, IPonderavel
{
    private Grafo grafo;
    private Vertice origem, destino;

    private string rotulo;
    private int peso;

    private string key = String.Empty;

    public string Key { get => key; private set => key = value; }

    public Aresta(Grafo grafo, Vertice origem, Vertice destino)
    {
        this.grafo = grafo;

        this.origem = origem;
        this.destino = destino;

        this.Key = Aresta.GerarKey(this.origem.Id, this.destino.Id);

        this.MontaRotulo();

    }

    public Vertice GetOrigem()
    {
        return origem;
    }

    public int GetIdOrigem()
    {
        return origem.Id;
    }

    public int GetIdDestino() 
    {
        return destino.Id;
    }

    public Vertice GetDestino()
    {
        return destino;
    }

    public static string GerarKey(int IdOrigem, int IdDestino)
    {
        return IdOrigem.ToString() + "_" + IdDestino.ToString();
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
        if (grafo.IsDirecionado())
        {
            return "(" + this.rotulo + ")";
        }
        else
        {
            return "{" + this.rotulo + "}";
        }
    }

    public void MontaRotulo()
    {
        this.rotulo = origem.GetRotulo() + ", " + destino.GetRotulo();
    }
}
