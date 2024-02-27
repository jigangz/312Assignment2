using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    [SerializeField] float speed = 2.0f;
    Vector2 motionVector;
    public Vector2 lastMotionVector;
    Animator animator;
    public bool moving;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        motionVector = new Vector2(horizontal, vertical);
        moving = horizontal != 0 || vertical != 0;

        animator.SetFloat("horizontal", horizontal);
        animator.SetFloat("vertical", vertical);
        animator.SetBool("moving", moving);

        if (moving)
        {
            lastMotionVector = motionVector.normalized;
            animator.SetFloat("lastHorizontal", lastMotionVector.x);
            animator.SetFloat("lastVertical", lastMotionVector.y);
        }

        // Check for mining action
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            TriggerMiningAnimation();
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rigidbody2d.velocity = motionVector * speed;
    }

    private void TriggerMiningAnimation()
    {
        // Trigger the mining animation
        animator.SetTrigger("isMining");
    }
}
