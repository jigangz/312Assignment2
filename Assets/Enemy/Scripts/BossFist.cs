using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossFist : MonoBehaviour
{
    public GameObject player; // 玩家对象，通过编辑器指定
    public Vector2 patrolAreaSize = new Vector2(10f, 5f); // 巡逻区域大小
    public float speedWonder = 2f; // 巡逻速度
    public float speedMove = 4f; // 移动到玩家上方的速度
    public float speedAttack = 6f; // 攻击速度
    public bool isAttacking = false;
    private Vector2 patrolAreaCenter; // 巡逻区域中心
    private Vector2 originalPosition;

    public bool fistAttack = false;

    void Start()
    {
        patrolAreaCenter = transform.position; // 初始化巡逻区域中心为当前位置
        originalPosition = transform.position; // 保存初始位置
        StartCoroutine(PatrolAndAttackRoutine());
    }

    IEnumerator PatrolAndAttackRoutine()
    {
        while (!isAttacking)
        {
            // 随机巡逻
            Vector2 randomPosition = new Vector2(
                Random.Range(patrolAreaCenter.x - patrolAreaSize.x / 2, patrolAreaCenter.x + patrolAreaSize.x / 2),
                Random.Range(patrolAreaCenter.y - patrolAreaSize.y / 2, patrolAreaCenter.y + patrolAreaSize.y / 2)
            );

            while (Vector2.Distance(transform.position, randomPosition) > 0.1f)
            {
                transform.position = Vector2.MoveTowards(transform.position, randomPosition, speedWonder * Time.deltaTime);
                yield return null;
            }

            // 随机等待一段时间
            yield return new WaitForSeconds(Random.Range(5f, 10f));

            // 移动到玩家上方
            isAttacking = true;
            Vector2 playerPosition = new Vector2(player.transform.position.x, transform.position.y);
            while (Vector2.Distance(transform.position, playerPosition) > 0.1f)
            {
                transform.position = Vector2.MoveTowards(transform.position, playerPosition, speedMove * Time.deltaTime);
                fistAttack = false;
                yield return null;
            }

            // 停留2秒
            yield return new WaitForSeconds(2f);

            // 攻击（砸下）
            Vector2 attackPosition = new Vector2(transform.position.x, player.transform.position.y + 1f); // 假设玩家头顶上方1单位为攻击目标位置
            while (Vector2.Distance(transform.position, attackPosition) > 0.1f)
            {
                transform.position = Vector2.MoveTowards(transform.position, attackPosition, speedAttack * Time.deltaTime);
                fistAttack = true;
                yield return null;
            }

            // 返回原始位置或巡逻状态
            while (Vector2.Distance(transform.position, originalPosition) > 0.1f)
            {
                transform.position = Vector2.MoveTowards(transform.position, originalPosition, speedWonder * Time.deltaTime);
                fistAttack = false;
                yield return null;
            }

            isAttacking = false; // 攻击结束，返回巡逻状态
        }
    }

    void OnDrawGizmos()
    {
        // 绘制巡逻区域
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(patrolAreaCenter, new Vector3(patrolAreaSize.x, patrolAreaSize.y, 1));
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (fistAttack)
        {
            // 检查是否触碰到了玩家
            if (other.gameObject.CompareTag("Player"))
            {
                Debug.Log("fisted!");
                // 这里可以添加对玩家的影响，比如减少生命值等
                //Destroy(gameObject); 
            }
        }
    }
}
