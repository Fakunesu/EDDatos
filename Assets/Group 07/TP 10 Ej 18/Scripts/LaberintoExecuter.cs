using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
public class LaberintoExecuter : MonoBehaviour
{
    public enum TileType
    {
        Floor,
        Wall,
        Start,
        End
    }

    [Header("Referencias")]
    public Tilemap tilemap;

    [Header("UI")]
    public TMP_Text outputText;

    [Header("Player")]
    public PlayerMovement playerMover;

    // camino calculado (en celdas)
    private List<Vector3Int> LastRoute = null;



    [Header("Tiles")]
    public TileBase floorTile;
    public TileBase wallTile;
    public TileBase startTile;
    public TileBase endTile;

    [Header("Tamaño del tablero")]
    public int width = 6;   // columnas
    public int height = 6;  // filas
    public Vector3Int origin = Vector3Int.zero; // celda de inicio del tablero (esquina inferior izquierda)

    [Header("Estado actual")]
    public TileType selectedType = TileType.Wall;

    // Qué tipo tiene cada celda
    private Dictionary<Vector3Int, TileType> cellTypes = new Dictionary<Vector3Int, TileType>();

    // Dónde está la Start y la End (solo puede haber una de cada)
    private Vector3Int? startCell = null;
    private Vector3Int? endCell = null;

    private Camera mainCamera;

    private void Awake()
    {
        if (tilemap == null)
            tilemap = GetComponent<Tilemap>();

        mainCamera = Camera.main;
    }

    private void Start()
    {
        AreaLimitation();
    }

    private void Update()
    {
        // Click izquierdo para pintar
        if (Input.GetMouseButton(0))
        {
            // Si el puntero está sobre un elemento de UI, no pintamos
            if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
                return;

            PaintGridWithTile();
        }
    }

    private void PaintGridWithTile()
    {
        if (mainCamera == null) return;

        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int cellPos = tilemap.WorldToCell(mouseWorldPos);

        // si la celda no está dentro del tablero, no hacemos nada
        if (!IsIntoTheArea(cellPos))
            return;

        // Elegimos qué tile usar según el tipo seleccionado
        TileBase tileToSet = GetTileForType(selectedType);

        // Reglas especiales para Start y End (solo una de cada)
        if (selectedType == TileType.Start)
        {
            // Si ya había una Start, la convertimos a Floor
            if (startCell.HasValue && startCell.Value != cellPos)
            {
                tilemap.SetTile(startCell.Value, floorTile);
                tilemap.SetColor(startCell.Value, GetColorForType(TileType.Floor));
                cellTypes[startCell.Value] = TileType.Floor;
            }

            startCell = cellPos;
        }
        else if (selectedType == TileType.End)
        {
            // Si ya había una End, la convertimos a Floor
            if (endCell.HasValue && endCell.Value != cellPos)
            {
                tilemap.SetTile(endCell.Value, floorTile);
                tilemap.SetColor(endCell.Value, GetColorForType(TileType.Floor));
                cellTypes[endCell.Value] = TileType.Floor;
            }

            endCell = cellPos;
        }

        // Pintamos la celda con el tile correspondiente
        tilemap.SetTile(cellPos, tileToSet);
        tilemap.SetColor(cellPos, GetColorForType(selectedType));  // <- NUEVO
        cellTypes[cellPos] = selectedType;
    }

    private TileBase GetTileForType(TileType type)
    {
        switch (type)
        {
            case TileType.Floor:
                return floorTile;
            case TileType.Wall:
                return wallTile;
            case TileType.Start:
                return startTile;
            case TileType.End:
                return endTile;
            default:
                return floorTile;
        }
    }

    private Color GetColorForType(TileType type)
    {
        switch (type)
        {
            case TileType.Floor:
                return Color.white;          // suelo
            case TileType.Wall:
                return Color.black;          // pared
            case TileType.Start:
                return Color.blue;          // inicio
            case TileType.End:
                return Color.red;            // fin
            default:
                return Color.white;
        }
    }
    // --- Métodos para los botones ---

    public void SetFloorType()
    {
        selectedType = TileType.Floor;
    }

    public void SetWallType()
    {
        selectedType = TileType.Wall;
    }

    public void SetStartType()
    {
        selectedType = TileType.Start;
    }

    public void SetEndType()
    {
        selectedType = TileType.End;
    }

    private void AreaLimitation()
    {
        cellTypes.Clear();

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3Int cellPos = new Vector3Int(origin.x + x, origin.y + y, 0);

                tilemap.SetTile(cellPos, floorTile);
                tilemap.SetColor(cellPos, GetColorForType(TileType.Floor));
                cellTypes[cellPos] = TileType.Floor;
            }
        }

        // Al generar nuevo tablero, olvidamos start/end anteriores
        startCell = null;
        endCell = null;
    }

    private bool IsIntoTheArea(Vector3Int cellPos)
    {
        return cellPos.x >= origin.x &&
               cellPos.x < origin.x + width &&
               cellPos.y >= origin.y &&
               cellPos.y < origin.y + height;
    }

    private bool CheckRoute()
    {
        LastRoute = null;

        if (!TryGetStart(out Vector3Int startCell) || !TryGetEnd(out Vector3Int endCell))
        {
            if (outputText != null)
                outputText.text = "Colocá Start y End.";
            return false;
        }

        // si hiciste la clase aparte GridPathfinder:
        LastRoute = PathfinderDijkstra.CalcularCamino(cellTypes, startCell, endCell);

        if (LastRoute == null || LastRoute.Count == 0)
        {
            if (outputText != null)
                outputText.text = "No hay camino.";
            return false;
        }

        if (outputText != null)
            outputText.text = "Camino encontrado. Longitud: " + (LastRoute.Count - 1);

        return true;
    }

    // Getters que vamos a usar después para el grafo / pathfinding
    public bool TryGetStart(out Vector3Int start)
    {
        if (startCell.HasValue)
        {
            start = startCell.Value;
            return true;
        }

        start = default;
        return false;
    }

    public bool TryGetEnd(out Vector3Int end)
    {
        if (endCell.HasValue)
        {
            end = endCell.Value;
            return true;
        }

        end = default;
        return false;
    }

    public void OnButtonCheckRoute()
    {
        CheckRoute();
    }

    public void OnButtonMovePlayer()
    {
        if (LastRoute == null || LastRoute.Count == 0)
        {
            if (outputText != null)
                outputText.text = "Primero comprobá el camino.";
            return;
        }

        if (playerMover == null)
            return;

        // Convertimos celdas a posiciones de mundo
        List<Vector3> puntos = new List<Vector3>();
        foreach (var cell in LastRoute)
        {
            puntos.Add(tilemap.GetCellCenterWorld(cell));
        }

        playerMover.PlayPath(puntos);
    }

    public Dictionary<Vector3Int, TileType> GetAllCells()
    {
        return cellTypes;
    }
}