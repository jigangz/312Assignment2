using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 2f; 
    private Vector2 startPosition;
    public float maxDistance = 10f; 

    void Start()
    {
        startPosition = transform.position; 
    }

    void Update()
    {
        //�ƶ�
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        // ����Ƿ�������㹻�ľ���
        if (Vector2.Distance(startPosition, transform.position) >= maxDistance)
        {
            //Destroy(gameObject); 
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        // ����Ƿ����������
        if (other.gameObject.CompareTag("Player")) 
        {
            Debug.Log("Fireball has collided with the player!");
            // ���������Ӷ���ҵ�Ӱ�죬�����������ֵ��
            //Destroy(gameObject); 
            GameObject inGameUI = GameObject.Find("InGameUI");
            if (inGameUI != null)
            {
                HealthManager healthManager = inGameUI.GetComponent<HealthManager>();
                if (healthManager != null)
                {
                    healthManager.ReduceHP(5); // ����ÿ����ײ����10��HP
                }
                else
                {
                    Debug.LogError("HealthManager script not found on InGameUI object.");
                }
            }
        }
    }


}
