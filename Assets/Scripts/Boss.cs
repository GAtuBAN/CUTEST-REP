using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    //  public Animator animator;
    public int maxHealth = 2000;
    int currentHealth;
    
    void Start()
    {
        currentHealth = maxHealth;
    }

    
    void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        //zort animasyonu

        //animator.SetTrigger("Hurt");

        if(currentHealth <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        //zort animasyonu
        //animator.SetBool("IsDead", true); 

        Debug.Log("You are not cutest anymore");

        //boss artýk geri plana düþer
        //üzerinden yürüyebiliriz.
       
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
