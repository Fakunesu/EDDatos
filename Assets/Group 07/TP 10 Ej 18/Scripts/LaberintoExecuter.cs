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
    public PlayerMovement playerMove;

    private List<Vector3Int> LastRoute = null;

    [Header("Tiles")]
    public TileBase floorTile;
    public TileBase wallTile;
    public TileBase startTile;
    public TileBase endTile;

    [Header("Tamaño del tablero")]
    public int width = 6;   
    public int height = 6;  
    public Vector3Int origin = Vector3Int.zero; 

    [Header("Estado actual")]
    public TileType selectedType = TileType.Floor;

    private Dictionary<Vector3Int, TileType> cellTypes = new Dictionary<Vector3Int, TileType>();

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
        if (Input.GetMouseButton(0))
        {
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

        if (!IsIntoTheArea(cellPos))
            return;

        TileBase tileToSet = GetTileForType(selectedType);

        if (selectedType == TileType.Start)
        {
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
            if (endCell.HasValue && endCell.Value != cellPos)
            {
                tilemap.SetTile(endCell.Value, floorTile);
                tilemap.SetColor(endCell.Value, GetColorForType(TileType.Floor));
                cellTypes[endCell.Value] = TileType.Floor;
            }

            endCell = cellPos;
        }

        tilemap.SetTile(cellPos, tileToSet);
        tilemap.SetColor(cellPos, GetColorForType(selectedType)); 
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
                return Color.white;         
            case TileType.Wall:
                return Color.black;         
            case TileType.Start:
                return Color.blue;          
            case TileType.End:
                return Color.red;           
            default:
                return Color.white;
        }
    }

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

        if (playerMove == null)
            return;

        List<Vector3> puntos = new List<Vector3>();
        foreach (var cell in LastRoute)
        {
            puntos.Add(tilemap.GetCellCenterWorld(cell));
        }

        playerMove.PlayPath(puntos);
    }

    public Dictionary<Vector3Int, TileType> GetAllCells()
    {
        return cellTypes;
    }
}