using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    [SerializeField] private float speed = 2.0f;
    private Vector2 motionVector;
    public Vector2 lastMotionVector;
    Animator animator;
    public bool moving;

    public AudioSource walkingSound; // 走路声音源

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        HandleInput();
    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }

    private void HandleInput()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        motionVector = new Vector2(horizontal, vertical);
        bool wasMoving = moving; // 记录之前的移动状态
        moving = motionVector.sqrMagnitude > 0;

        animator.SetFloat("horizontal", horizontal);
        animator.SetFloat("vertical", vertical);
        animator.SetBool("moving", moving);

        if (moving)
        {
            lastMotionVector = motionVector.normalized;
            animator.SetFloat("lastHorizontal", lastMotionVector.x);
            animator.SetFloat("lastVertical", lastMotionVector.y);
        }

        // 当玩家开始移动时播放走路声音
        if (moving && !wasMoving)
        {
            walkingSound.Play();
        }
        // 当玩家停止移动时停止播放声音
        else if (!moving && wasMoving)
        {
            walkingSound.Stop();
        }
    }

    private void MoveCharacter()
    {
        rigidbody2d.velocity = motionVector * speed;
    }
}
