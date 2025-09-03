using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    public GameObject enemyPrefab;
    private GameObject currentEnemy;

    void Update()
    {
        Camera cam = Camera.main;
        if (cam == null) return; // safety check

        // Convert world position of this spawn point to viewport coords
        Vector3 viewportPos = cam.WorldToViewportPoint(transform.position);

        // Viewport is (0,0) bottom-left, (1,1) top-right
        bool insideCamera = viewportPos.x >= 0 && viewportPos.x <= 1 &&
        viewportPos.y >= 0 && viewportPos.y <= 1 &&
        viewportPos.z > 0;

        if (insideCamera && currentEnemy == null)
        {
            currentEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        }

        // Cleanup destroyed enemies
        if (currentEnemy == null)
        {
            currentEnemy = null; // ensures no ghost reference
        }
    }
}
