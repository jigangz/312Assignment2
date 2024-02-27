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
        //移动
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        // 检查是否飞行了足够的距离
        if (Vector2.Distance(startPosition, transform.position) >= maxDistance)
        {
            //Destroy(gameObject); 
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        // 检查是否触碰到了玩家
        if (other.gameObject.CompareTag("Player")) 
        {
            Debug.Log("Fireball has collided with the player!");
            // 这里可以添加对玩家的影响，比如减少生命值等
            //Destroy(gameObject); 
            GameObject inGameUI = GameObject.Find("InGameUI");
            if (inGameUI != null)
            {
                HealthManager healthManager = inGameUI.GetComponent<HealthManager>();
                if (healthManager != null)
                {
                    healthManager.ReduceHP(5); // 假设每次碰撞减少10点HP
                }
                else
                {
                    Debug.LogError("HealthManager script not found on InGameUI object.");
                }
            }
        }
    }


}
