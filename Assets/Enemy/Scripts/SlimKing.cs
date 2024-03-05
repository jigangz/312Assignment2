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

    public int health = 3; // ���˵�����ֵ

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
        if (health > 0) // ������ֵ����0ʱ�����˿����ƶ�
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
        else // ������ֵ����ʱ��ֹͣ�ƶ�������SlimTalk����
        {
            StopAllCoroutines(); // ֹͣ����Э�̣�����Wander
            isWandering = false; // ȷ�������������
            if (slimTalkCanvas != null)
            {
                slimTalkCanvas.SetActive(true); // ����SlimTalk����
            }
        }

    }
    //Ѳ��Я��
    IEnumerator Wander()
    {
        isWandering = true;
        while (isWandering)
        {
            // Vector2 randomDirection2D = Random.insideUnitCircle.normalized * wanderRadius; // ����2Dƽ���ϵ��������;���
            // Vector3 randomDirection = new Vector3(randomDirection2D.x, 0, randomDirection2D.y) + startPosition; // ת��Ϊ3D���Գ�ʼλ��Ϊ����

            // �����������;��룬���ڰ���Y��
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

    //��player����
    void MoveTowardsPlayer()
    {
        Vector3 moveDirection = (player.transform.position - transform.position).normalized;
        transform.position += moveDirection * speed2 * Time.deltaTime;
    }

    //����������Χ
    private void OnDrawGizmos()
    {
        if (drawEnemyWanderRadius)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(startPosition, wanderRadius);
        }
    }

    // ��ײ���
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            Debug.Log("Enemy has collided with the player!");

            // ��Ѫ�߼�
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
