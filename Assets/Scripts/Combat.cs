using UnityEngine;

public class Combat : MonoBehaviour
{
    public GameObject attackHitbox; // Assign the GameObject with AttackHitbox script in Inspector
    public Animator animator;
    private bool isAttacking = false;

    void Start()
    {

        animator = GetComponent<Animator>();
        attackHitbox.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && !isAttacking)
        {
            Attack();
        }
    }

    void Attack()
    {
        isAttacking = true;
        animator.SetTrigger("isAttacking"); // Attack animation state

        attackHitbox.SetActive(true);
        Invoke(nameof(DeactivateHitbox), 0.2f);
    }

    void DeactivateHitbox()
    {
        attackHitbox.SetActive(false);
        isAttacking = false;
    }
}
