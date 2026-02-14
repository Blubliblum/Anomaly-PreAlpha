using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyYellow : MonoBehaviour
{
    private CharacterController controller;
    private Transform player;
    private float verticalVelocity;
    public float jumpForce = 1.8f;
    public float gravity = -9.8f;
    public float moveSpeed = 3f;
    public float detectionRange = 10f;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
         Vector3 move = Vector3.zero;
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
     if (controller.isGrounded)
{
    if (verticalVelocity < 0)
        verticalVelocity = -2f;

    if (distanceToPlayer <= detectionRange)
    {
        verticalVelocity = jumpForce;
    }
}
                
        
            if (!controller.isGrounded)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            move = direction * moveSpeed;
        }
 verticalVelocity += gravity * Time.deltaTime;

 move.y = verticalVelocity;
  controller.Move(move * Time.deltaTime);
  
        
        
    }
}
