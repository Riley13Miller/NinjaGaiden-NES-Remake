using UnityEngine;

public class Bounds : MonoBehaviour
{
    public Vector2 minBounds; // bottom left limit of camera movement
    public Vector2 maxBounds; // top right limit of camera movement

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CameraFollow cam = Camera.main.GetComponent<CameraFollow>(); 
            cam.minBounds = minBounds; 
            cam.maxBounds = maxBounds;
        }
    }      
}
