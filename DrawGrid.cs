using UnityEngine;

public class DrawGrid : MonoBehaviour
{
    public int rows = 8;
    public int columns = 8;
    public float cellSize = 1f; // Cell size in Unity units
    public GameObject gridLinePrefab;

    private void Start()
    {
        DrawLines();
    }

    private void DrawLines()
    {
        float offsetX = columns * cellSize / 2;
        float offsetY = rows * cellSize / 2;

        for (int i = 0; i <= rows; i++)
        {
            GameObject rowLine = Instantiate(gridLinePrefab, transform);
            LineRenderer rowLineRenderer = rowLine.GetComponent<LineRenderer>();
            rowLineRenderer.SetPosition(0, new Vector3(-offsetX, (i * cellSize) - offsetY, 0) + new Vector3(4,4,0));
            rowLineRenderer.SetPosition(1, new Vector3(offsetX, (i * cellSize) - offsetY, 0) + new Vector3(4,4,0));
        }

        for (int i = 0; i <= columns; i++)
        {
            GameObject columnLine = Instantiate(gridLinePrefab, transform);
            LineRenderer columnLineRenderer = columnLine.GetComponent<LineRenderer>();
            columnLineRenderer.SetPosition(0, new Vector3((i * cellSize) - offsetX, -offsetY, 0) + new Vector3(4,4,0));
            columnLineRenderer.SetPosition(1, new Vector3((i * cellSize) - offsetX, offsetY, 0) + new Vector3(4,4,0));
        }
    }
}
