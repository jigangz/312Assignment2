using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimKing : MonoBehaviour
{
    public GameObject player;
    public float speed1 = 5f;
    public float speed2 = 10f;
    public float wanderRadius = 1f;
    private Vector3 targetPosition;
    private Vector3 startPosition;
    private bool isWandering = true;

    public bool drawEnemyWanderRadius = true;

    public int health = 3; // 敌人的生命值

    public GameObject slimTalkCanvas; 

    void Start()
    {
        startPosition = transform.position; 

        if (player == null)
        {
            player = GameObject.Find("Player");
        }
        StartCoroutine(Wander());
    }

    void Update()
    {
        if (health > 0) // 当生命值大于0时，敌人可以移动
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            if (distanceToPlayer <= wanderRadius)
            {
                isWandering = false;
                MoveTowardsPlayer();
            }
            else if (!isWandering)
            {
                StartCoroutine(Wander());
            }
        }
        else // 当生命值归零时，停止移动并激活SlimTalk画布
        {
            StopAllCoroutines(); // 停止所有协程，包括Wander
            isWandering = false; // 确保不再移向玩家
            if (slimTalkCanvas != null)
            {
                slimTalkCanvas.SetActive(true); // 激活SlimTalk画布
            }
        }

    }
    //巡逻携程
    IEnumerator Wander()
    {
        isWandering = true;
        while (isWandering)
        {
            // Vector2 randomDirection2D = Random.insideUnitCircle.normalized * wanderRadius; // 生成2D平面上的随机方向和距离
            // Vector3 randomDirection = new Vector3(randomDirection2D.x, 0, randomDirection2D.y) + startPosition; // 转换为3D并以初始位置为基础

            // 生成随机方向和距离，现在包括Y轴
            Vector3 randomDirection = Random.insideUnitSphere * wanderRadius;
            randomDirection += startPosition;
            randomDirection.y = startPosition.y + randomDirection.y;


            targetPosition = randomDirection;

            while (Vector3.Distance(transform.position, targetPosition) > 0.2f && isWandering)
            {
                Vector3 moveDirection = (targetPosition - transform.position).normalized;
                transform.position += moveDirection * speed1 * Time.deltaTime;
                yield return null;
            }
            yield return new WaitForSeconds(1f);
        }
    }

    //向player攻击
    void MoveTowardsPlayer()
    {
        Vector3 moveDirection = (player.transform.position - transform.position).normalized;
        transform.position += moveDirection * speed2 * Time.deltaTime;
    }

    //画出攻击范围
    private void OnDrawGizmos()
    {
        if (drawEnemyWanderRadius)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(startPosition, wanderRadius);
        }
    }

    // 碰撞检测
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            Debug.Log("Enemy has collided with the player!");

            // 扣血逻辑
            GameObject inGameUI = GameObject.Find("Player Stat Bar");
            if (inGameUI != null)
            {

                HealthManager healthManager = inGameUI.GetComponent<HealthManager>();
                if (healthManager != null)
                {
                    healthManager.ReduceHP(5); 
                }
                else
                {
                    Debug.LogError("HealthManager script not found on InGameUI object.");
                }
            }
            else
            {
                Debug.LogError("InGameUI object not found in the scene.");
            }
        }
    }
}
