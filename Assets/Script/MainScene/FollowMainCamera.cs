using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMainCamera : MonoBehaviour
{
    public Transform target; // ���� ���

    public float followSpeed = 5f; // �ε巴�� ���󰡴� �ӵ�

    // ī�޶��� �̵� �Ѱ踦 ������ �� �ִ� ����
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private float offsetX;
    private float offsetY;

    private void Start()
    {
        if (target == null) return;

        offsetX = transform.position.x - target.position.x;
        offsetY = transform.position.y - target.position.y;
    }

    private void Update()
    {
        if (target == null) return;

        // ī�޶��� ��ǥ ��ġ ���
        Vector3 desiredPosition = new Vector3(target.position.x + offsetX, target.position.y + offsetY, transform.position.z);

        // ī�޶� ��ġ ����: Y�� ���/�ϴ� �Ѱ� ����
        // ��� �Ѱ�: maxY, �ϴ� �Ѱ�: minY
        desiredPosition.y = Mathf.Clamp(desiredPosition.y, minY, maxY);

        // ī�޶� ��ġ ����: X�� ��/�� �Ѱ� ����
        desiredPosition.x = Mathf.Clamp(desiredPosition.x, minX, maxX);

        // �ε巴�� ī�޶� �̵�
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * followSpeed);
    }
}