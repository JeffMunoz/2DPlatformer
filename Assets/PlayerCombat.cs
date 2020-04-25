// Author: Jeffry Munoz

using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator attackAnimator;

    public Transform attackPoint;

    public float attackRange = 0.5f;

    public LayerMask enemyLayer;

    public int attackDamage = 40;

    public float attackrate = 2f;
    
    private float nextAttackTime = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            attackAnimator.SetTrigger("attackStance");
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            attackAnimator.SetTrigger("idleStance");
        }

        // Limits the amount of times the player can attack 
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
                nextAttackTime = Time.time + 1 / attackrate;
            }
        }

        
    }

    public void Attack()
    {
        attackAnimator.SetTrigger("attackTrigger");
        // Collects the information about each item hit 
        Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in enemiesHit)
        {
            enemy.GetComponent<Enemy>().takeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint != null)
        {
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }

        return;
    }
}