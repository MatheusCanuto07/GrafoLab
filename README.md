# Biblioteca de Manipulação de Grafos

Este projeto consiste na implementação de uma biblioteca para manipulação de grafos em **Python**, permitindo a criação, manipulação e exportação de grafos em diferentes representações. A biblioteca também oferece algoritmos para verificação de propriedades e análise de conectividade, com suporte à exportação de grafos para visualização no **Gephi**.

## Funcionalidades

### Representações de Grafos
- **Matriz de Adjacência**: Matriz que indica a presença de arestas entre os vértices.
- **Matriz de Incidência**: Representa as arestas com relação aos vértices conectados.
- **Lista de Adjacência**: Cada vértice é associado a uma lista com seus vértices adjacentes.

### Operações de Manipulação
- **Criação de Grafos**: Defina o número de vértices ao criar um grafo.
- **Adição e Remoção de Arestas**.
- **Rotulação e Ponderação de Vértices e Arestas**.
- **Verificação de Adjacência** entre vértices e arestas.
- **Checagem de Propriedades do Grafo**: vazio, completo, conectividade simples, semi-forte, forte, entre outras.
- **Identificação de Componentes Fortemente Conexos** com o algoritmo de Kosaraju.
- **Detecção de Pontes e Articulações**: Verifica se a remoção de arestas ou vértices desconecta o grafo.

### Exportação e Visualização
Exporta os grafos criados para formatos suportados pelo Gephi, como:
- **GEXF**
- **GraphML**
- **GML**
- **GraphViz DOT**

## Requisitos

- **Python 3.x**
