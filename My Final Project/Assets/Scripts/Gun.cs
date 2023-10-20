using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float fireRate;
    public EnemyMan enemyMan;
    public LayerMask raycastLayerMask;
    public float range = 20f;
    public float verticalRange = 20f; 
    public float bigDamage = 2f;
    public float smallDamage = 1f;

    private BoxCollider gunTrigger; 
    private float nextTimeToFire;

    public Vector3 Vector3 { get; private set; }

    void Start()
    {
        
        gunTrigger = GetComponent<BoxCollider>();
        gunTrigger.size = new Vector3(x:1, y:verticalRange, z:range);
        gunTrigger.center = new Vector3(x:0, y:0, z:range*0.5f); 
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0)&& Time.time > nextTimeToFire)
            {

                Fire();
            }

    }

    void Fire()
    { 
        foreach (var enemy in enemyMan.enemiesInTrigger)
        {
               var dir  = enemy.transform.position - transform.position;

                RaycastHit hit;
                if(Physics.Raycast(origin: transform.position, direction: dir, out hit, maxDistance: range * 1.5f, raycastLayerMask))
                {
                    if(hit.transform == enemy.transform)
                    {

                        float dist = Vector3.Distance(a: enemy.transform.position, b:transform.position);

                        if (dist > range * 0.5f)
                        {

                            enemy.TakeDamage(smallDamage); // small damage based on distance 

                        }
                        else
                        {

                             enemy.TakeDamage(bigDamage); // big damage based on distance 
                        }

                    }

                }   
        }
            nextTimeToFire = Time.time + fireRate;
    }

    private void OnTriggerEnter(Collider other) 
    {
       // throw new NotImplementedException();
        Enemy enemy = other.transform.GetComponent<Enemy>();

        if (enemy)
        {
                enemyMan.AddEnemy(enemy);

        }

    }
    private void OnTriggerExit(Collider other) 
    {
        //throw new NotImplementedException();
         Enemy enemy = other.transform.GetComponent<Enemy>();

        if (enemy)
        {
                enemyMan.RemoveEnemy(enemy);            
        }
    }
}
