using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    public float detectionRadius = 5f; // 检测范围的半径

    void Update()
    {
        DetectEnemies();
    }

    void DetectEnemies()
    {
        // 在游戏物体周围的指定半径内查找所有碰撞体
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius);

        bool enemyFound = false;
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Enemy")) // 检查是否有带有Enemy标签的碰撞体
            {
                enemyFound = true;
                break; // 找到一个敌人后就停止搜索
            }
        }

        if (!enemyFound)
        {
            // 如果没有找到敌人，销毁这个游戏物体
            Destroy(gameObject);
        }
    }

    void OnDrawGizmosSelected()
    {
        // 当游戏物体被选中时，在编辑器中绘制检测范围
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
