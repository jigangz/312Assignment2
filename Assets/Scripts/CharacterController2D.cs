using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    [SerializeField] private float speed = 2.0f; // ���ﱣ�����ٶȣ������Ƴ��˼��ٶ�
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

        // ���������Ƴ����ڿ󶯻��Ĵ����߼�����������Ȼ��������������������ڿ��߼�
        // ���磬����������������һ����־���������Ƿ������ڿ�
        // if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        // {
        //     // �ڿ����Ĵ���
        // }
    }

    private void MoveCharacter()
    {
        // ��Ϊ���ٶȱ��Ƴ��ˣ���������ֱ��ʹ���ٶȳ��Է����������ƶ���ɫ
        rigidbody2d.velocity = motionVector * speed;
    }

    // ���������Ƴ����ڿ󶯻������ķ�������Ϊ������Ҫ
}
