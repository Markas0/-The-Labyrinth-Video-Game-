using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyMan enemyMan;
    private float enemyHealth = 2f;



    void Start()
    {
        
    }

      void Update()
    {
        if (enemyHealth <= 0)
        {
           enemyMan.RemoveEnemy(this); 
           Destroy(gameObject);     


        }
    }

    public void TakeDamage(float damage)
    {

        enemyHealth -= damage; 
    }
}
