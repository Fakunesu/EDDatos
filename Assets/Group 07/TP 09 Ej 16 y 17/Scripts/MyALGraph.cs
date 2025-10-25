using System.Collections.Generic;

public class MyALGraph<T>
{
    private Dictionary<T, List<(T, int)>> adList;

    public IEnumerable<T> Vertices { get => adList.Keys; }

    public MyALGraph()
    {
        adList = new Dictionary<T, List<(T, int)>>();
    }

    public void AddVertex(T vertex)
    {
        if (!adList.ContainsKey(vertex))
        {
            adList[vertex] = new List<(T, int)>();
        }
    }
    public void RemoveVertex(T vertex)
    {
        if (adList.ContainsKey(vertex))
        {
            adList.Remove(vertex);

            foreach (var pointer in adList.Values)
            {
                for (int i = 0; i < pointer.Count; i++)
                {
                    if (pointer[i].Item1.Equals(vertex))
                    {
                        pointer.RemoveAt(i);
                    }
                }
            }
        }

    }

    public void AddEdge(T from, (T, int) edge)
    {
        if (adList.TryGetValue(from, out var list))
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Item1.Equals(edge.Item1)) return;
            }
            list.Add(edge);
        }


    }

    public void RemoveEdge(T from, T to)
    {
        if (adList.TryGetValue(from, out var list))
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Item1.Equals(to))
                {
                    list.RemoveAt(i);
                }
            }
        }
    }

    public bool ContainsVertex(T vertex)
    {
        if (adList.ContainsKey(vertex)) return true;
        else return false;
    }

    public bool ContainsEdge(T from, T to)
    {
        if (adList.TryGetValue(from, out var edges))
        {
            for(int i = 0; i < edges.Count; i++)
            {
                if(edges[i].Item1.Equals(to)) return true;
            }
            return false;
        }
        return false;
    }

    public int? GetWeight(T from, T to)
    {
        if (adList.TryGetValue(from, out var edges))
        {
            for (int i = 0; i < edges.Count; i++)
            {
                if (edges[i].Item1.Equals(to)) return edges[i].Item2;
            }
            return null;
        }
        return null;
    }
}
