using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    [SerializeField] private float speed = 2.0f;
    [SerializeField] private float acceleration = 1.0f; // 加速度
    private Vector2 motionVector;
    public Vector2 lastMotionVector;
    Animator animator;
    public bool moving;
    public bool isMining = false;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        HandleInput();
        // 打印当前isMining的值
        Debug.Log($"Update - isMining: {isMining}");
    }

    private void FixedUpdate()
    {
        if (!isMining)
        {
            MoveCharacter();
        }
        else
        {
            // 确保角色完全停止
            rigidbody2d.velocity = Vector2.zero;
        }
    }

    private void HandleInput()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        motionVector = new Vector2(horizontal, vertical);
        moving = motionVector.sqrMagnitude > 0;

        if (!isMining)
        {
            animator.SetFloat("horizontal", horizontal);
            animator.SetFloat("vertical", vertical);
            animator.SetBool("moving", moving);

            if (moving)
            {
                lastMotionVector = motionVector.normalized;
                animator.SetFloat("lastHorizontal", lastMotionVector.x);
                animator.SetFloat("lastVertical", lastMotionVector.y);
            }

            // 检查采矿动作
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                TriggerMiningAnimation();
            }
        }
    }

    private void MoveCharacter()
    {
        // 使用插值平滑移动
        rigidbody2d.velocity = Vector2.Lerp(rigidbody2d.velocity, motionVector * speed, acceleration * Time.fixedDeltaTime);
    }

    private void TriggerMiningAnimation()
    {
        Debug.Log("TriggerMiningAnimation called - Setting isMining to true");
        animator.SetTrigger("startMining");
        isMining = true;
        rigidbody2d.velocity = Vector2.zero;
    }

    public void EndMiningAnimation()
    {
        // 动画事件会调用这个方法
        Debug.Log("EndMiningAnimation called - Setting isMining to false");
        isMining = false;
        // 其他你需要执行的代码
    }

}
