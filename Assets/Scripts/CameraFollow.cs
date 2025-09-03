using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // reference for the camera to follow
    public Vector2 minBounds; // bottom left limit of camera movement
    public Vector2 maxBounds; // top right limit of camera movement
    public float yAxisLock = 0f; // locks y axis for levels that don't need vertical movement
    void LateUpdate()
    {
        if (player == null) // if player is not assigned, do nothing
            return;

        float x = player.position.x; 
        float y = (yAxisLock != 0) ? yAxisLock : player.position.y;  // lock y axis if yAxisLock is set

        x = Mathf.Clamp(x, minBounds.x, maxBounds.x); 
        y = Mathf.Clamp(y, minBounds.y, maxBounds.y);

        transform.position = new Vector3(x, y, transform.position.z); 

    }
}
