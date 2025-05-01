using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameController : MonoBehaviour
{
    public Animator pa;
    public Rigidbody2D prb;

    float jumpPower = 5f;
    float moveSpeed = 5f;
    float deadDelay = 0;

    bool isjump;

    public bool isDead;

    private void Update()
    {
        if (isDead)
        {

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isjump = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isDead) { return; }

        Vector3 velocity = prb.velocity;
        velocity.x = moveSpeed;

        if (isjump)
        {
            velocity.y = jumpPower;
            isjump = false;
        }

        prb.velocity = velocity;

        float angle = Mathf.Clamp((prb.velocity.y * 10), -90, 90);
        transform.
    }
}
