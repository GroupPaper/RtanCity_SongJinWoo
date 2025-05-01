using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameController : MonoBehaviour
{
    public Animator pa;
    public Rigidbody2D prb;

    public float jumpPower = 6f;
    public float moveSpeed = 3f;
    float deadDelay = 0;

    bool isjump = false;

    public bool isDead;

    private void Update()
    {
        if (isDead)
        {
            if(deadDelay <= 0)
            {
                //게임 재시작, 기본 공간으로 바뀌는 기능 추가예정
            }
            else
            {
                deadDelay -= Time.deltaTime;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space)|Input.GetMouseButtonDown(0))
            {
                isjump = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isDead)
        {
            return;
        }

        Vector3 velocity = prb.velocity;
        velocity.x = moveSpeed;

        if (isjump)
        {
            velocity.y = jumpPower;
            isjump = false;
        }

        prb.velocity = velocity;

        float angle = Mathf.Clamp((prb.velocity.y * 10f), -90f, 90f);
        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.fixedDeltaTime * 5f);
        // 강의에서 제공하는 방법으로 하면 회전이 확확 돌아서, 부드럽게 회전하는 방법을 찾던 중 정해진 값으로 정해진 시간만큼 값을 변환하는 방법을 찾음
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead)
        {
            return;
        }

        isDead = true;
        deadDelay = 1f;

        pa.SetTrigger("Dead");
    }
}
