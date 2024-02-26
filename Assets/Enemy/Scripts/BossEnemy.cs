using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    public GameObject boss;
    public GameObject fireball1;
    public GameObject fireball2;
    private Vector3 startPosition;
    private float moveTime;
    public float moveHeight;
    public float moveWidth;
    public float moveSpeed=1.0f;
    public float moveHeightY = 2.0f; // Y���ϵ��ƶ��߶�
    private Rect moveArea;

    void Start()
    {
        startPosition = boss.transform.position;
        // �����ƶ��������ĵ���Boss����ʼλ��
        moveArea = new Rect(startPosition.x - moveWidth/2, startPosition.y - moveHeight/2, moveWidth, moveHeight);
        StartCoroutine(BossRoutine());
    }

    IEnumerator BossRoutine()
    {
        while (true)
        {
            // ��������ƶ�ʱ��
            moveTime = Random.Range(5f, 10f);
            StartCoroutine(MoveRandomly(moveTime));

            // �ȴ��ƶ�����
            yield return new WaitForSeconds(moveTime);

            // ֹͣ�ƶ���׼���������
            StopCoroutine(MoveRandomly(moveTime));

            // ���������������
            if (Random.value < 0.5f)
            {
                // ��������3��6��fireball1
                StartCoroutine(LaunchFireballs());
            }
            else
            {
                // ����1��fireball2
                Instantiate(fireball2, boss.transform.position, Quaternion.identity);
            }

            // �ȴ�һ��ʱ����ٴν����ƶ��͹���ѭ��
            yield return new WaitForSeconds(2f);
        }
    }

    IEnumerator LaunchFireballs()
    {
        int fireballCount = Random.Range(3, 7); // ����3��6������
        for (int i = 0; i < fireballCount; i++)
        {
            Instantiate(fireball1, boss.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.5f); // ÿ������֮��ļ��ʱ��
        }
    }

    IEnumerator MoveRandomly(float duration)
    {
        float timer = 0;
        while (timer < duration)
        {
            // �ڶ���ľ������������ѡ��һ��Ŀ��λ��
          //  Vector3 targetPosition = new Vector3(
          //      Random.Range(moveArea.xMin, moveArea.xMax),
           //     startPosition.y,
           //     Random.Range(moveArea.yMin, moveArea.yMax)
           // );

            Vector3 targetPosition = new Vector3(
              Random.Range(moveArea.xMin, moveArea.xMax),
              Random.Range(startPosition.y - moveHeightY / 2, startPosition.y + moveHeightY / 2), // Y�������ѡ��
              Random.Range(moveArea.yMin, moveArea.yMax) // ע�⣺ԭʼ����������������Z���
          );
            // ÿ֡��Ŀ��λ���ƶ�ֱ���ﵽ�µ�Ŀ��λ�û�ʱ�����
            while (boss.transform.position != targetPosition && timer < duration)
            {
                boss.transform.position = Vector3.MoveTowards(boss.transform.position, targetPosition, moveSpeed * Time.deltaTime);
                timer += Time.deltaTime;
                yield return null;
            }

            // ���ѡ���Ƿ������ı䷽��
            if (Random.value > 0.5f)
            {
                yield return null; // �����ƶ�
            }
            else
            {
                yield return new WaitForSeconds(1f); // ��ͣ�ƶ�
            }
        }
    }


    // �����ƶ�����
    void OnDrawGizmos()
    {
      
        if (startPosition != Vector3.zero)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(new Vector3(startPosition.x, startPosition.y, 0), new Vector3(moveWidth, moveHeight, 0));
        }
    }
}
