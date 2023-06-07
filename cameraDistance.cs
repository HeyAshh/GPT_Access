using UnityEngine;

public class CenterCamera : MonoBehaviour
{
    public int gridWidth = 8;
    public int gridHeight = 8;
    public float cameraDistance = -10f;

    void Start()
    {
        Vector3 gridCenter = new Vector3(gridWidth / 2f, gridHeight / 2f, 0);
        Camera.main.transform.position = gridCenter + new Vector3(0, 0, cameraDistance);
    }
}
