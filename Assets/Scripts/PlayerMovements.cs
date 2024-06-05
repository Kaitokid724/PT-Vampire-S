using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public Rigidbody2D theRigidbody;

    public float moveSpeed;

    public Animator animator;

    public float pickupRange = 1.5f;

    bool facingRigth = true;

    private void Awake()
    {
        theRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 moveInput = new Vector3(0f, 0f, 0f);

        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        theRigidbody.velocity = moveInput * moveSpeed;

        if(moveInput != Vector3.zero) 
        {
            animator.SetBool("Move", true);
        }
        else
        {
            animator.SetBool("Move", false);
        }

        if (moveInput.x > 0 && !facingRigth)
        {
            Flip();
        }

        if (moveInput.x < 0 && facingRigth)
        {
            Flip();
        }
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRigth = !facingRigth;
    }
}
