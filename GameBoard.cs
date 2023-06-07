using System.Collections;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public GameObject[,] tiles;
    public int boardWidth = 9;
    public int boardHeight = 9;
    public float cellSize = 0.75f;
    public Vector3 gridCenter = new Vector3(4, 3.7f, 0);

    Tile selectedTile;
    Tile targetTile;

    void Start()
    {
        tiles = new GameObject[boardWidth, boardHeight];
        for (int x = 0; x < boardWidth; x++)
        {
            for (int y = 0; y < boardHeight; y++)
            {
                SpawnTileAt(x, y);
            }
        }
    }

    GameObject SpawnTileAt(int x, int y)
    {
        int randomIndex = Random.Range(0, tilePrefabs.Length);
        GameObject tilePrefab = tilePrefabs[randomIndex];
        Vector3 position = new Vector3((x * cellSize) - (boardWidth * cellSize / 2) + cellSize / 2, (y * cellSize) - (boardHeight * cellSize / 2) + cellSize / 2, 0);
        
        // Add a random shift from -0.01 to 0.01 to the X coordinate
        float shift = Random.Range(-0.01f, 0.01f);
        position.x += shift;
        
        position += gridCenter;
        tiles[x, y] = Instantiate(tilePrefab, position, Quaternion.identity);
        
        // Add a random rotation from -1 to 1 degrees around the Y axis
        float rotation = Random.Range(-1f, 1f);
        tiles[x, y].transform.Rotate(0, rotation, 0);

        tiles[x, y].transform.localScale = new Vector3(1.7f, 1.7f, 1.7f);

        // Add Tile component to the instantiated tile object
        Tile tileComponent = tiles[x, y].AddComponent<Tile>();
        tileComponent.x = x;
        tileComponent.y = y;

        return tiles[x, y];
    }
    
    public void SelectTile(Tile tile)
    {
        if (selectedTile)
        {
            targetTile = tile;
            SwapSelectedTiles();
        }
        else
        {
            selectedTile = tile;
        }
    }

    void SwapSelectedTiles()
    {
        // TODO: Implement tile swapping
        // For now, simply clear the selected tiles
        selectedTile = null;
        targetTile = null;
    }

    public void ClearAndRespawnTileAt(int x, int y)
    {
        if (x < 0 || x >= boardWidth || y < 0 || y >= boardHeight)
        {
            Debug.LogError("Tile coordinates are out of range: " + x + ", " + y);
            return;
        }

        GameObject tileToClear = tiles[x, y];
        tiles[x, y] = null;
        Destroy(tileToClear);
        StartCoroutine(RespawnDelay(x, y));
    }

    IEnumerator RespawnDelay(int x, int y)
    {
        yield return new WaitForSeconds(0.5f);
        GameObject newTile = SpawnTileAt(x, y);
        StartCoroutine(MoveTileTo(newTile, new Vector3((x * cellSize) - (boardWidth * cellSize / 2) + cellSize / 2, (y * cellSize) - (boardHeight * cellSize / 2) + cellSize / 2, 0) + gridCenter, 0.5f));
    }

    public IEnumerator MoveTileTo(GameObject tile, Vector3 targetPosition, float timeToMove)
    {
        Vector3 startPosition = tile.transform.position;
        float elapsedTime = 0;

        while (elapsedTime < timeToMove)
        {
            elapsedTime += Time.deltaTime;
            tile.transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / timeToMove);
            yield return null;
        }

        tile.transform.position = targetPosition;
    }
}
