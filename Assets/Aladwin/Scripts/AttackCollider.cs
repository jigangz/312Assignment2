using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    public Vector2 knockbackForce = new Vector2(1.0f, 0); // 击退力量，可以根据需要调整

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
            Destroy(collision.gameObject, 3f);
        }
    }
}
