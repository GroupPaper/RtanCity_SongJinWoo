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
                //���� �����, �⺻ �������� �ٲ�� ��� �߰�����
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
        // ���ǿ��� �����ϴ� ������� �ϸ� ȸ���� ȮȮ ���Ƽ�, �ε巴�� ȸ���ϴ� ����� ã�� �� ������ ������ ������ �ð���ŭ ���� ��ȯ�ϴ� ����� ã��
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
