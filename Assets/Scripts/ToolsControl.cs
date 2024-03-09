using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsControl : MonoBehaviour
{
    CharacterController2D character;
    Rigidbody2D rgbd2d;
    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractableArea = 1.2f;

    private void Awake()
    {
        character = GetComponent<CharacterController2D>();
        rgbd2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // 检测WASD按键而不是鼠标点击
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            UseTool();
        }
    }

    private void UseTool()
    {
        // 使用角色最后的移动向量来确定工具使用的位置
        Vector2 position = rgbd2d.position + character.lastMotionVector * offsetDistance;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);
        foreach (Collider2D collider in colliders)
        {
            ToolHit hit = collider.GetComponent<ToolHit>();
            if (hit != null)
            {
                hit.Hit(); // 触发碰撞对象的Hit方法
                break; // 如果一次只处理一个对象，则保留此break
            }
        }
    }
}

