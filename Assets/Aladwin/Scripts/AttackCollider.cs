using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    public Vector2 knockbackForce = new Vector2(1.0f, 0); // �������������Ը�����Ҫ����

    private void OnTriggerEnter2D(Collider2D collision)
    {
   

        if (collision.gameObject.CompareTag("Enemy"))
        {
           
            // ���˵���
            Rigidbody2D enemyRb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (enemyRb != null)
            {
                enemyRb.AddForce(knockbackForce, ForceMode2D.Impulse);
            }

            // 3���ݻٵ���
            Destroy(collision.gameObject, 3f);
        }
    }
}
