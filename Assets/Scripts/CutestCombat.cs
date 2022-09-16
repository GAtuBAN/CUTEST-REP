using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutestCombat : MonoBehaviour
{


    //animasyon eklenince yorumdan ��kar
    //public Animator animator;
    public LayerMask enemyLayers;
    public Transform attackPoint;
    public float attackRange = 1.0f;
    public int attackDamage = 40;
    //s�rekli atak olmas�n
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    void Update()
    {
        if(Time.time >= nextAttackTime)//�u anki zaman� als�n diye Time.time
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
        //Sald�r� animasyonu
        //Animator.SetTrigger("Attack");
        //Vurulacak objeyi range i�inde tespit etmek
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
