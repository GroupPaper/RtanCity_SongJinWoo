using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed = 3f;

    public Rigidbody2D playerRigidbody2D;
    public Animator playerAnimation;
    SpriteRenderer[] playerSpriteRenderers; // [] = ��������Ʈ �������� �迭�� �������� ���

    private void Start()
    {
        playerSpriteRenderers = GetComponentsInChildren<SpriteRenderer>(); // �ڽ� ������Ʈ�� �ִ� ��������Ʈ �������� �������� ���
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        Jump();
    }

    void Move()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 move = new Vector2(moveX, moveY);
        playerRigidbody2D.velocity = move.normalized * speed;

        if(moveX != 0) // moveX�� ���� ������ �ִٸ�(�¿�� �̵��Ѵٸ�)
        {
            foreach(var arr in playerSpriteRenderers) // �÷��̾� ��������Ʈ �������� ������(playerSpriteRenderer)�� �ڵ� �߷�?(var arr) �Ͽ� �������� ���
            {
                arr.flipX = moveX < 0; // X�� �ø��� ���� ����
            }
        }

        bool isRun = move.magnitude > 0.01f; // magnitude�� ������ ũ��(�̵� �ӵ�, ����?)�� ����Ͽ� 0.01f���� ū�� ������ �Ǵ�
        playerAnimation.SetBool("Run", isRun); // isRun�� ���� ����, �Ķ���Ϳ� Bool���� Run�� true�Ǵ� false ���� ����
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAnimation.SetTrigger("Jump");
        }
    }
}
