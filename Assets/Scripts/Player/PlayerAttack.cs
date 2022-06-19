using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;

    private PlayerMovement playerMovement;

    [SerializeField] private float attackCooldown;
    private float cooldownTimer = Mathf.Infinity;

    [SerializeField]  private Transform attackPoint;
    [SerializeField]  private float attackRange = 0.5f;
    public int attackDamage = 1;

    public LayerMask enemyLayers;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && cooldownTimer > attackCooldown && playerMovement.canAttack())
            Attack();

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        anim.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        
            hitEnemies[0].GetComponent<Enemy>().TakeDamage(attackDamage);
        

        cooldownTimer = 0;
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
