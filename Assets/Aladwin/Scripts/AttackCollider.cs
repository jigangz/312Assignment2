using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    public Vector2 knockbackForce = new Vector2(0.8f, 0); // 击退力量，可以根据需要调整

    private void OnTriggerEnter2D(Collider2D collision)
    {
   

        if (collision.gameObject.CompareTag("Enemy"))
        {
           
            // 击退敌人
            Rigidbody2D enemyRb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (enemyRb != null)
            {
                enemyRb.AddForce(knockbackForce, ForceMode2D.Impulse);
            }

            // 3秒后摧毁敌人
            //Destroy(collision.gameObject, 3f);

            // 减少敌人的血量
            BaseEnemy enemy = collision.gameObject.GetComponent<BaseEnemy>();
            if (enemy != null)
            {
                enemy.health -= 1; 
            }
            // 减少史莱姆王的血量
            SlimKing Slim = collision.gameObject.GetComponent<SlimKing>();
            if (Slim != null)
            {
                Slim.health -= 1;
            }


        }

        if (collision.gameObject.CompareTag("bossHead"))
        {
            Debug.Log("hit boss!");
            // 减少敌人的血量
          
                BossHealth healthManager = collision.gameObject.GetComponent<BossHealth>();
             
                    healthManager.ReduceHP(2);
               

            


        }

    }
}
