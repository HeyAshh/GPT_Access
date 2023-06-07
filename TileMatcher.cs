using System.Collections.Generic;
using UnityEngine;

public class TileMatcher : MonoBehaviour
{
    public GameBoard gameBoard;
    private List<GameObject> matchedTiles = new List<GameObject>();

    public void CheckForMatches()
    {
        for (int x = 0; x < gameBoard.boardWidth; x++)
        {
            for (int y = 0; y < gameBoard.boardHeight; y++)
            {
                GameObject tile = gameBoard.tiles[x, y];
                if (tile != null)
                {
                    CheckMatch(tile);
                }
            }
        }
    }

    private void CheckMatch(GameObject tile)
    {
        // TODO: Implement match checking logic
    }

    public void ClearMatches()
    {
        foreach (GameObject tile in matchedTiles)
        {
            gameBoard.ClearAndRespawnTileAt(tile.GetComponent<Tile>().x, tile.GetComponent<Tile>().y);
        }
        matchedTiles.Clear();
    }
}
