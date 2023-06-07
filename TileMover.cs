using UnityEngine;
using System.Collections;

public class TileMover : MonoBehaviour
{
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
