// Author: Jeffry Munoz


using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator enemyAnimator;
    
    public int maxHealth = 100;

     int currentHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

    }

    public void takeDamage(int damageTaken)
    {
        currentHealth -= damageTaken;

        enemyAnimator.SetTrigger("hurt");
        if (currentHealth <= 0)
        {
            death();
        }
    }

    void death()
    {
        enemyAnimator.SetBool("isDead",true);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
