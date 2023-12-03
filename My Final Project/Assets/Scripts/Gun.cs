using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public EnemyMan enemyMan;
    public LayerMask raycastLayerMask;
    public LayerMask enemyLayerMask;
    private BoxCollider gunTrigger; 
    private float nextTimeToFire;

    public float fireRate = 1f;
    public float range = 20f;
    public float verticalRange = 20f; 
    public float gunShotRadius = 20f;
    public float bigDamage = 2f;
    public float smallDamage = 1f;


    public int maxAmmo;
    public int ammo;
    

    public Vector3 Vector3 { get; private set; }

    void Start()
    {
        
        gunTrigger = GetComponent<BoxCollider>();
        gunTrigger.size = new Vector3(1, verticalRange, range);
        gunTrigger.center = new Vector3(0, 0, range*0.5f); 

        CanvasMan.Instance.UpdateAmmo(ammo);
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && Time.time > nextTimeToFire && ammo > 0)
            {

                Fire();
            }

    }

    void Fire()
    { 

        Collider[] enemyColliders; 
        enemyColliders = Physics.OverlapSphere(transform.position, gunShotRadius, enemyLayerMask);

        foreach (var enemyCollider in enemyColliders)
        {
            enemyCollider.GetComponent<EnemyAwareness>().isAggro = true;

        }

        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();

        foreach (var enemy in enemyMan.enemiesInTrigger)
        {
            var dir  = enemy.transform.position - transform.position;

            RaycastHit hit;
            if (Physics.Raycast(transform.position,  dir, out hit, range * 1.5f,(int)raycastLayerMask))
            {
                if (hit.transform == enemy.transform)
                {

                    float dist = Vector3.Distance(enemy.transform.position, transform.position);

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
            ammo--;
            CanvasMan.Instance.UpdateAmmo(ammo);
    }


    public void GiveAmmo(int amount, GameObject pickup)
    {
        if(ammo < maxAmmo)
        {
            ammo += amount;
            Destroy(pickup);
        }

        if(ammo > maxAmmo)
        {
            ammo = maxAmmo;
        }

        CanvasMan.Instance.UpdateAmmo(ammo);
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
