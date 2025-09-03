using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 1;

    public void Damaged(int damage)
    {

        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}