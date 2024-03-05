using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject player; // ��Ҷ���ͨ���༭��ָ��
    public float attackRange = 1f; // ��������
    private Animator animator; // �������
    public Vector2 lastAttackDirection; // ��һ�ι�������
    public float attackSize=1.0f; // ��Ҷ���ͨ���༭��ָ��

    void Start()
    {
        animator = player.GetComponent<Animator>();
    }

    void Update()
    {
        CheckInputAndUpdateDirection();
    }

    void CheckInputAndUpdateDirection()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.Play("AttackRight");
            lastAttackDirection = Vector2.right;
            CreateAttackCollider(Vector2.right);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            animator.Play("AttackLeft");
            lastAttackDirection = Vector2.left;
            CreateAttackCollider(Vector2.left);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            animator.Play("AttackUp");
            lastAttackDirection = Vector2.up;
            CreateAttackCollider(Vector2.up);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            animator.Play("AttackDown");
            lastAttackDirection = Vector2.down;
            CreateAttackCollider(Vector2.down);
        }
    }

    void CreateAttackCollider(Vector2 direction)
    {
        Vector2 spawnPosition = (Vector2)player.transform.position + direction * attackRange;
        GameObject attackCollider = new GameObject("AttackCollider");
        attackCollider.transform.position = spawnPosition;
        BoxCollider2D collider = attackCollider.AddComponent<BoxCollider2D>();
        collider.size = new Vector2(attackSize, attackSize);
        collider.isTrigger = true;

        // attackCollider.AddComponent<AttackCollider>();
        AttackCollider attackScript = attackCollider.AddComponent<AttackCollider>();
        attackScript.knockbackForce = direction * attackScript.knockbackForce.magnitude; // ���û���������ʹ�С

        Destroy(attackCollider, 0.5f);
    }

    void OnDrawGizmos()
    {
        // ��������һ�ι�������ʱ����
        if (lastAttackDirection != Vector2.zero)
        {
            Gizmos.color = Color.red; // ����Gizmos��ɫΪ��ɫ
            Vector2 spawnPosition = (Vector2)player.transform.position + lastAttackDirection * attackRange;
            // ����һ��1x1������������ʾ������ײ����
            Gizmos.DrawWireCube(spawnPosition, new Vector3(attackSize, attackSize, 0));
        }
    }
}
