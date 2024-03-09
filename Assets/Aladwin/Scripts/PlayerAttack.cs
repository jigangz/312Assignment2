using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject player; // 玩家对象，通过编辑器指定
    public float attackRange = 1f; // 攻击距离
    private Animator animator; // 动画组件
    public Vector2 lastAttackDirection; // 上一次攻击方向
    public float attackSize=1.0f; // 玩家对象，通过编辑器指定

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
        attackScript.knockbackForce = direction * attackScript.knockbackForce.magnitude; // 设置击退力方向和大小

        Destroy(attackCollider, 0.5f);
    }

    void OnDrawGizmos()
    {
        // 仅在有上一次攻击方向时绘制
        if (lastAttackDirection != Vector2.zero)
        {
            Gizmos.color = Color.red; // 设置Gizmos颜色为红色
            Vector2 spawnPosition = (Vector2)player.transform.position + lastAttackDirection * attackRange;
            // 绘制一个1x1的立方体来表示攻击碰撞区域
            Gizmos.DrawWireCube(spawnPosition, new Vector3(attackSize, attackSize, 0));
        }
    }
}
