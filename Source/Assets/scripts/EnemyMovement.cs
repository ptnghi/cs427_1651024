using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public CharacterController controller;

    private Vector2 spawnPosition;
    public float moveSpeed = 40f;

    private int moveDirection = -1;

    [SerializeField]
    private Animator animator;
    

    private float distanceFromSpawn = 0;
    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = transform.position;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        distanceFromSpawn += Vector2.Distance(transform.position, spawnPosition);
        if (distanceFromSpawn > 30f) {
            moveDirection *= -1;
            distanceFromSpawn = -distanceFromSpawn;
        }

        animator.SetFloat("speed", 10f);
        controller.Move(moveDirection * moveSpeed * Time.fixedDeltaTime, false, false); 
    }
}
