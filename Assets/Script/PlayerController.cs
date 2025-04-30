using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed = 3f;

    public Rigidbody2D playerRigidbody2D;
    public Animator playerAnimation;
    SpriteRenderer[] playerSpriteRenderers; // [] = 스프라이트 렌더러를 배열로 가져오는 기능

    private void Start()
    {
        playerSpriteRenderers = GetComponentsInChildren<SpriteRenderer>(); // 자식 오브젝트에 있는 스프라이트 렌더러를 가져오는 기능
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

        if(moveX != 0) // moveX의 값에 변동이 있다면(좌우로 이동한다면)
        {
            foreach(var arr in playerSpriteRenderers) // 플레이어 스프라이트 렌더러에 변수들(playerSpriteRenderer)을 자동 추론?(var arr) 하여 가져오는 기능
            {
                arr.flipX = moveX < 0; // X축 플립을 할지 말지
            }
        }

        bool isRun = move.magnitude > 0.01f; // magnitude가 벡터의 크기(이동 속도, 방향?)를 계산하여 0.01f보다 큰지 작은지 판단
        playerAnimation.SetBool("Run", isRun); // isRun의 값을 통해, 파라미터에 Bool값인 Run을 true또는 false 할지 말지
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAnimation.SetTrigger("Jump");
        }
    }
}
