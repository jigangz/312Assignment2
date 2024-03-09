using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    public float detectionRadius = 5f; // ��ⷶΧ�İ뾶

    void Update()
    {
        DetectEnemies();
    }

    void DetectEnemies()
    {
        // ����Ϸ������Χ��ָ���뾶�ڲ���������ײ��
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius);

        bool enemyFound = false;
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Enemy")) // ����Ƿ��д���Enemy��ǩ����ײ��
            {
                enemyFound = true;
                break; // �ҵ�һ�����˺��ֹͣ����
            }
        }

        if (!enemyFound)
        {
            // ���û���ҵ����ˣ����������Ϸ����
            Destroy(gameObject);
        }
    }

    void OnDrawGizmosSelected()
    {
        // ����Ϸ���屻ѡ��ʱ���ڱ༭���л��Ƽ�ⷶΧ
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
