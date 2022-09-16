using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutestCombat : MonoBehaviour
{


    //animasyon eklenince yorumdan çýkar
    //public Animator animator;
    public LayerMask enemyLayers;
    public Transform attackPoint;
    public float attackRange = 1.0f;
    public int attackDamage = 40;
    //sürekli atak olmasýn
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    void Update()
    {
        if(Time.time >= nextAttackTime)//þu anki zamaný alsýn diye Time.time
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Hit me baby one more time");
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;

            }
        }
        
        
    }

    void Attack()
    {
        //Saldýrý animasyonu
        //Animator.SetTrigger("Attack");
        //Vurulacak objeyi range içinde tespit etmek
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        //Hasar vermek
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Boss>().TakeDamage(attackDamage);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
             return;
        
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        
    }
}
