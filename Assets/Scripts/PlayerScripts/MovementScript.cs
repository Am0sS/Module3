using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{

    // VARIABLES
    private int moveSpeed;
    private int runSpeed;
    private GameObject player;
    private Animator animator;
    Rigidbody2D rb;
    private Vector2 movement;

    private void Start()
    {
        moveSpeed = 5;
        runSpeed = 8;
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // MOVEMENT
        movement = Vector2.ClampMagnitude(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")),1f);        
        transform.position += new Vector3(movement.x, movement.y, 0f) * Time.deltaTime * moveSpeed;

        // RUNNING ANIMATION
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            animator.SetBool("isRunning", true);
        else
            animator.SetBool("isRunning", false);

        // CHARACTER FLIP
        if (Input.GetKey(KeyCode.A))
            transform.localScale = new Vector3(-1,1,1);
        else if (Input.GetKey(KeyCode.D))
            transform.localScale = new Vector3(1,1,1);

        // RUNNING
        if (Input.GetKey(KeyCode.LeftShift))
            {
            moveSpeed = runSpeed;
            }
        else
            {  
            moveSpeed = 5;
            }
    }
}