using UnityEngine;

public class Patrol : MonoBehaviour
{
    public Transform leftPoint;
    public Transform rightPoint;
    public float speed = 2f;
    private bool movingRight = true;
    private SpriteRenderer sr;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (movingRight)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(rightPoint.position.x, transform.position.y), speed * Time.deltaTime);
            if (transform.position.x >= rightPoint.position.x)
            {
                movingRight = false;
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(leftPoint.position.x, transform.position.y), speed * Time.deltaTime);
            if (transform.position.x <= leftPoint.position.x)
            {
                movingRight = true;
            }
        }
        sr.flipX = !movingRight;
    }
}
