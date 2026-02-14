using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlue : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float detectionRange = 5f ;
     private Transform player;
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= detectionRange)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;

        }
    }
}
