using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;

    private Vector3 moveDirection;
    private Vector3 velocity;

    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;

    [SerializeField] private float jumpHeight;


    private CharacterController controller;
    private Animator anim;

    private void Start() 
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    private void Update() 
    {
        Move();

        if(Input.GetKeyDown(KeyCode.Mouse0)) {
            Attack();
        }
    }

    private void Move()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);
        
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float moveZ = Input.GetAxis("Vertical");

        moveDirection = new Vector3(0, 0, moveZ);
        moveDirection = transform.TransformDirection(moveDirection);

        if (isGrounded)
        {
            if(moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift)) 
            {
                Walk();
            }
            else if(moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift)) 
            {
                Run();
            }
            else if (moveDirection == Vector3.zero) 
            {
                Idle();
            }

            moveDirection *= moveSpeed;

            if (Input.GetKey(KeyCode.Space))
            {
                Jump();
            }
        }
        
        controller.Move(moveDirection * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void Idle()
    {
        anim.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
    }

    private void Walk()
    {
        moveSpeed = walkSpeed;
        anim.SetFloat("Speed", 0.22f, 0.1f, Time.deltaTime);
    }

    private void Run()
    {
        moveSpeed = runSpeed;
        anim.SetFloat("Speed", 0.44f, 0.1f, Time.deltaTime);
    }

    private void Jump() 
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        anim.SetFloat("Speed", 0.66f, 0.1f, Time.deltaTime);
    }

    private void Attack() {
        anim.SetTrigger("Attack");
    }
}
