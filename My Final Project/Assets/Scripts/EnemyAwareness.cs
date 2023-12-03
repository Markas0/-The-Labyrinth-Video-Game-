using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAwareness : MonoBehaviour
{
    public float awarenessRadius = 8f;
    public bool isAggro;

    private Transform playersTransform;


    private void Start()
    {
        playersTransform = FindObjectOfType<PlayerMove>().transform;

    }

    private void Update()
    {
        var dist = Vector3.Distance(a:transform.position, b:playersTransform.position);

        if(dist < awarenessRadius)
        {

            isAggro = true;
        }

        if(isAggro)
        {
        

        }
    } 
}
