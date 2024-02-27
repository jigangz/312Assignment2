using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    [SerializeField] private float speed = 2.0f; // 这里保留了速度，但是移除了加速度
    private Vector2 motionVector;
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

        // 这里我们移除了挖矿动画的触发逻辑，但是您仍然可以在这里放置其他的挖矿逻辑
        // 例如，您可以在这里增加一个标志来检测玩家是否正在挖矿
        // if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        // {
        //     // 挖矿动作的代码
        // }
    }

    private void MoveCharacter()
    {
        // 因为加速度被移除了，所以我们直接使用速度乘以方向向量来移动角色
        rigidbody2d.velocity = motionVector * speed;
    }

    // 这里我们移除了挖矿动画结束的方法，因为不再需要
}
