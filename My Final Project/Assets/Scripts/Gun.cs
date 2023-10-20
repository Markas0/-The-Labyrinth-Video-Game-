using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float fireRate;
    public EnemyMan enemyMan;
    public float range = 20f;
    public float verticalRange = 20f; 

    private BoxCollider gunTrigger; 
    private float nextTimeToFire;


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
