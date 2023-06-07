using UnityEngine;
using System.Collections;

public class TileSpawner : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public GameObject[,] tiles;
    public int boardWidth = 9;
    public int boardHeight = 9;
    public float cellSize = 0.75f;
    public Vector3 gridCenter = new Vector3(4, 3.7f, 0);

    GameObject SpawnTileAt(int x, int y)
    {
        int randomIndex = Random.Range(0, tilePrefabs.Length);
        GameObject tilePrefab = tilePrefabs[randomIndex];
        Vector3 position = new Vector3((x * cellSize) - (boardWidth * cellSize / 2) + cellSize / 2, (y * cellSize) - (boardHeight * cellSize / 2) + cellSize / 2, 0);
        
        float shift = Random.Range(-0.01f, 0.01f);
        position.x += shift;
        
        position += gridCenter;
        tiles[x, y] = Instantiate(tilePrefab, position, Quaternion.identity);
        
        float rotation = Random.Range(-1f, 1f);
        tiles[x, y].transform.Rotate(0, rotation, 0);

        tiles[x, y].transform.localScale = new Vector3(1.7f, 1.7f, 1.7f);

        Tile tileComponent = tiles[x, y].AddComponent<Tile>();
        tileComponent.x = x;
        tileComponent.y = y;

        return tiles[x, y];
    }

    IEnumerator RespawnDelay(int x, int y)
    {
        yield return new WaitForSeconds(0.5f);
        GameObject newTile = SpawnTileAt(x, y);
    }
}
