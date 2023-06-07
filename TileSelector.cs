using UnityEngine;

public class TileSelector : MonoBehaviour
{
    public TileSpawner tileSpawner;
    public TileMover tileMover;

    private GameObject selectedTile;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SelectTile();
        }

        if (Input.GetMouseButtonUp(0))
        {
            ReleaseTile();
        }
    }

    private void SelectTile()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Physics2D.OverlapPoint(mousePos, tileSpawner.matchingLayer))
        {
            selectedTile = Physics2D.OverlapPoint(mousePos, tileSpawner.matchingLayer).gameObject;
            tileMover.selectedTile = selectedTile;
        }
    }

    private void ReleaseTile()
    {
        selectedTile = null;
        tileMover.selectedTile = null;
    }
}
