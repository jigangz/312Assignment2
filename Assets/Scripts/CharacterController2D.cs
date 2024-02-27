using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    [SerializeField] private float speed = 2.0f;
    [SerializeField] private float acceleration = 1.0f; // ���ٶ�
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
        // ��ӡ��ǰisMining��ֵ
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
            // ȷ����ɫ��ȫֹͣ
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

            // ���ɿ���
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                TriggerMiningAnimation();
            }
        }
    }

    private void MoveCharacter()
    {
        // ʹ�ò�ֵƽ���ƶ�
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
        // �����¼�������������
        Debug.Log("EndMiningAnimation called - Setting isMining to false");
        isMining = false;
        // ��������Ҫִ�еĴ���
    }

}
