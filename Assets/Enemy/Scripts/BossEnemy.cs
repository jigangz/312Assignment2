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
    public float moveHeightY = 2.0f; // Y轴上的移动高度
    private Rect moveArea;

    void Start()
    {
        startPosition = boss.transform.position;
        // 定义移动区域，中心点是Boss的起始位置
        moveArea = new Rect(startPosition.x - moveWidth/2, startPosition.y - moveHeight/2, moveWidth, moveHeight);
        StartCoroutine(BossRoutine());
    }

    IEnumerator BossRoutine()
    {
        while (true)
        {
            // 随机决定移动时间
            moveTime = Random.Range(5f, 10f);
            StartCoroutine(MoveRandomly(moveTime));

            // 等待移动结束
            yield return new WaitForSeconds(moveTime);

            // 停止移动，准备发射火球
            StopCoroutine(MoveRandomly(moveTime));

            // 随机决定攻击类型
            if (Random.value < 0.5f)
            {
                // 连续发射3到6个fireball1
                StartCoroutine(LaunchFireballs());
            }
            else
            {
                // 发射1个fireball2
                Instantiate(fireball2, boss.transform.position, Quaternion.identity);
            }

            // 等待一段时间后再次进入移动和攻击循环
            yield return new WaitForSeconds(2f);
        }
    }

    IEnumerator LaunchFireballs()
    {
        int fireballCount = Random.Range(3, 7); // 生成3到6个火球
        for (int i = 0; i < fireballCount; i++)
        {
            Instantiate(fireball1, boss.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.5f); // 每个火球之间的间隔时间
        }
    }

    IEnumerator MoveRandomly(float duration)
    {
        float timer = 0;
        while (timer < duration)
        {
            // 在定义的矩形区域内随机选择一个目标位置
          //  Vector3 targetPosition = new Vector3(
          //      Random.Range(moveArea.xMin, moveArea.xMax),
           //     startPosition.y,
           //     Random.Range(moveArea.yMin, moveArea.yMax)
           // );

            Vector3 targetPosition = new Vector3(
              Random.Range(moveArea.xMin, moveArea.xMax),
              Random.Range(startPosition.y - moveHeightY / 2, startPosition.y + moveHeightY / 2), // Y轴上随机选择
              Random.Range(moveArea.yMin, moveArea.yMax) // 注意：原始代码中这里是用作Z轴的
          );
            // 每帧向目标位置移动直到达到新的目标位置或时间结束
            while (boss.transform.position != targetPosition && timer < duration)
            {
                boss.transform.position = Vector3.MoveTowards(boss.transform.position, targetPosition, moveSpeed * Time.deltaTime);
                timer += Time.deltaTime;
                yield return null;
            }

            // 随机选择是否立即改变方向
            if (Random.value > 0.5f)
            {
                yield return null; // 继续移动
            }
            else
            {
                yield return new WaitForSeconds(1f); // 暂停移动
            }
        }
    }


    // 绘制移动区域
    void OnDrawGizmos()
    {
      
        if (startPosition != Vector3.zero)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(new Vector3(startPosition.x, startPosition.y, 0), new Vector3(moveWidth, moveHeight, 0));
        }
    }
}
