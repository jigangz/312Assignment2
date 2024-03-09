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
        // ���WASD���������������
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            UseTool();
        }
    }

    private void UseTool()
    {
        // ʹ�ý�ɫ�����ƶ�������ȷ������ʹ�õ�λ��
        Vector2 position = rgbd2d.position + character.lastMotionVector * offsetDistance;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);
        foreach (Collider2D collider in colliders)
        {
            ToolHit hit = collider.GetComponent<ToolHit>();
            if (hit != null)
            {
                hit.Hit(); // ������ײ�����Hit����
                break; // ���һ��ֻ����һ������������break
            }
        }
    }
}

