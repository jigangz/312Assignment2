using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossFist : MonoBehaviour
{
    public GameObject player; // ��Ҷ���ͨ���༭��ָ��
    public Vector2 patrolAreaSize = new Vector2(10f, 5f); // Ѳ�������С
    public float speedWonder = 2f; // Ѳ���ٶ�
    public float speedMove = 4f; // �ƶ�������Ϸ����ٶ�
    public float speedAttack = 6f; // �����ٶ�
    public bool isAttacking = false;
    private Vector2 patrolAreaCenter; // Ѳ����������
    private Vector2 originalPosition;

    public bool fistAttack = false;

    void Start()
    {
        patrolAreaCenter = transform.position; // ��ʼ��Ѳ����������Ϊ��ǰλ��
        originalPosition = transform.position; // �����ʼλ��
        StartCoroutine(PatrolAndAttackRoutine());
    }

    IEnumerator PatrolAndAttackRoutine()
    {
        while (!isAttacking)
        {
            // ���Ѳ��
            Vector2 randomPosition = new Vector2(
                Random.Range(patrolAreaCenter.x - patrolAreaSize.x / 2, patrolAreaCenter.x + patrolAreaSize.x / 2),
                Random.Range(patrolAreaCenter.y - patrolAreaSize.y / 2, patrolAreaCenter.y + patrolAreaSize.y / 2)
            );

            while (Vector2.Distance(transform.position, randomPosition) > 0.1f)
            {
                transform.position = Vector2.MoveTowards(transform.position, randomPosition, speedWonder * Time.deltaTime);
                yield return null;
            }

            // ����ȴ�һ��ʱ��
            yield return new WaitForSeconds(Random.Range(5f, 10f));

            // �ƶ�������Ϸ�
            isAttacking = true;
            Vector2 playerPosition = new Vector2(player.transform.position.x, transform.position.y);
            while (Vector2.Distance(transform.position, playerPosition) > 0.1f)
            {
                transform.position = Vector2.MoveTowards(transform.position, playerPosition, speedMove * Time.deltaTime);
                fistAttack = false;
                yield return null;
            }

            // ͣ��2��
            yield return new WaitForSeconds(2f);

            // ���������£�
            Vector2 attackPosition = new Vector2(transform.position.x, player.transform.position.y + 1f); // �������ͷ���Ϸ�1��λΪ����Ŀ��λ��
            while (Vector2.Distance(transform.position, attackPosition) > 0.1f)
            {
                transform.position = Vector2.MoveTowards(transform.position, attackPosition, speedAttack * Time.deltaTime);
                fistAttack = true;
                yield return null;
            }

            // ����ԭʼλ�û�Ѳ��״̬
            while (Vector2.Distance(transform.position, originalPosition) > 0.1f)
            {
                transform.position = Vector2.MoveTowards(transform.position, originalPosition, speedWonder * Time.deltaTime);
                fistAttack = false;
                yield return null;
            }

            isAttacking = false; // ��������������Ѳ��״̬
        }
    }

    void OnDrawGizmos()
    {
        // ����Ѳ������
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(patrolAreaCenter, new Vector3(patrolAreaSize.x, patrolAreaSize.y, 1));
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (fistAttack)
        {
            // ����Ƿ����������
            if (other.gameObject.CompareTag("Player"))
            {
                Debug.Log("fisted!");
                // ���������Ӷ���ҵ�Ӱ�죬�����������ֵ��
                //Destroy(gameObject); 
            }
        }
    }
}
