using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private EnemyMan enemyMan;
    private Animator spriteAnim;
    private AngleToPlayer angleToPlayer;
    private float enemyHealth = 2f;
    private Transform playerTransform;
    private NavMeshAgent nav;

    public GameObject gunHitEffect;

    void Start()
    {
        spriteAnim = GetComponentInChildren<Animator>();
        angleToPlayer = GetComponent<AngleToPlayer>();

        enemyMan = FindObjectOfType<EnemyMan>();

      //  playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
       // nav = GetComponent<NavMeshAgent>();
    }

      void Update()
    {
        spriteAnim.SetFloat(name:"spriteRot", angleToPlayer.lastIndex);


        if (enemyHealth <= 0)
        {
           enemyMan.RemoveEnemy(this); 
           Destroy(gameObject);     


        }

       // nav.destination = playerTransform.position;
    }

    public void TakeDamage(float damage)
    {
        Instantiate(gunHitEffect, transform.position, Quaternion.identity);
        enemyHealth -= damage; 
    }
}
