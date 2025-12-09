using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static LaberintoExecuter;

public static class PathfinderDijkstra
{
    public static List<Vector3Int> CalcularCamino(Dictionary<Vector3Int, TileType> cellTypes, Vector3Int startCell, Vector3Int endCell)
    {
        MyALGraph<Vector2Int> grafo = ConstruirGrafo(cellTypes);

        Vector2Int inicio = new Vector2Int(startCell.x, startCell.y);
        Vector2Int fin = new Vector2Int(endCell.x, endCell.y);

        List<Vector2Int> camino2D = Dijkstra(grafo, inicio, fin);
        if (camino2D == null || camino2D.Count == 0)
            return null;

        List<Vector3Int> caminoCells = new List<Vector3Int>();
        foreach (var p in camino2D)
        {
            caminoCells.Add(new Vector3Int(p.x, p.y, 0));
        }

        return caminoCells;
    }

    private static MyALGraph<Vector2Int> ConstruirGrafo(Dictionary<Vector3Int, TileType> cellTypes)
    {
        MyALGraph<Vector2Int> grafo = new MyALGraph<Vector2Int>();

        foreach (var kvp in cellTypes)
        {
            if (kvp.Value == TileType.Wall)
                continue;

            Vector3Int cell = kvp.Key;
            Vector2Int nodo = new Vector2Int(cell.x, cell.y);
            grafo.AddVertex(nodo);
        }

        Vector3Int[] dirs = new Vector3Int[]
        {
            new Vector3Int(1, 0, 0),
            new Vector3Int(-1, 0, 0),
            new Vector3Int(0, 1, 0),
            new Vector3Int(0, -1, 0)
        };

        foreach (var kvp in cellTypes)
        {
            if (kvp.Value == TileType.Wall)
                continue;

            Vector3Int cell = kvp.Key;
            Vector2Int from = new Vector2Int(cell.x, cell.y);

            foreach (var dir in dirs)
            {
                Vector3Int vecinoCell = cell + dir;

                if (cellTypes.TryGetValue(vecinoCell, out TileType tipoVecino) && tipoVecino != TileType.Wall)
                {
                    Vector2Int to = new Vector2Int(vecinoCell.x, vecinoCell.y);
                    grafo.AddVertex(to);
                    grafo.AddEdge(from, (to, 1f));
                }
            }
        }

        return grafo;
    }

    private static List<Vector2Int> Dijkstra( MyALGraph<Vector2Int> grafo, Vector2Int inicio, Vector2Int fin)
    {
        var dist = new Dictionary<Vector2Int, float>();
        var prev = new Dictionary<Vector2Int, Vector2Int?>();
        var noVisitados = new List<Vector2Int>();

        foreach (var v in grafo.Vertices)
        {
            dist[v] = float.PositiveInfinity;
            prev[v] = null;
            noVisitados.Add(v);
        }

        if (!dist.ContainsKey(inicio) || !dist.ContainsKey(fin))
            return null;

        dist[inicio] = 0f;

        while (noVisitados.Count > 0)
        {
            Vector2Int u = noVisitados[0];
            float mejor = dist[u];

            for (int i = 1; i < noVisitados.Count; i++)
            {
                var cand = noVisitados[i];
                float d = dist[cand];
                if (d < mejor)
                {
                    mejor = d;
                    u = cand;
                }
            }

            noVisitados.Remove(u);

            if (u == fin)
                break;

            if (float.IsPositiveInfinity(dist[u]))
                break; 

            foreach (var edge in grafo.GetAdjacents(u))
            {
                Vector2Int v = edge.Item1;
                float w = edge.Item2;
                float alt = dist[u] + w;

                if (alt < dist[v])
                {
                    dist[v] = alt;
                    prev[v] = u;
                }
            }
        }

        if (float.IsPositiveInfinity(dist[fin]))
            return null; 

  
        List<Vector2Int> camino = new List<Vector2Int>();
        Vector2Int actual = fin;

        while (true)
        {
            camino.Add(actual);
            if (actual == inicio)
                break;

            if (!prev[actual].HasValue)
                return null;

            actual = prev[actual].Value;
        }

        camino.Reverse();
        return camino;
    }
}

