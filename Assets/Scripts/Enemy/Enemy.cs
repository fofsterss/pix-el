using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    private bool isEnabled = true;

    public LayerMask playerLayer;

    public int attackDamage = 1;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange = 0.5f;

    public int maxHealth = 2;
    int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" && isEnabled == true)
        {
            animator.SetTrigger("Attack");

            Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);

            StartCoroutine(AttackPlayer(hitPlayer[0]));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            StopAllCoroutines();
        }
    }


    IEnumerator AttackPlayer(Collider2D player)
    {

        yield return new WaitForSeconds(2);

        if(isEnabled)
            player.GetComponent<Health>().TakeDamage(attackDamage);

        yield return new WaitForSeconds(2);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if(currentHealth <= 0)
        {
            Die();
        }

    }

    void Die()
    {
        Debug.Log("Enemy died!");

        animator.SetBool("IsDead", true);

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        isEnabled = false;
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

