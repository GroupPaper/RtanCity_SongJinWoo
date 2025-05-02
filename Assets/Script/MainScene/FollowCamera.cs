using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// FollowCamera Ŭ������ ī�޶� ������ Ÿ��(Transform)�� ���󰡵��� ����� ����� �Ѵ�.
public class FollowCamera : MonoBehaviour
{
    // ���� ���(��: �÷��̾� ĳ����)�� �����ϴ� public ����
    public Transform target;

    // Ÿ�ٰ� ī�޶� ������ X�� �Ÿ� ������ (�ʱ� ��ġ ���� ����)
    float offsetX;

    // Start�� ������ ���۵� �� �� ���� ȣ��ȴ�
    private void Start()
    {
        // ���� ���� ����� �������� �ʾҴٸ�, �Լ� ����
        if (target == null)
        {
            return;
        }

        // ī�޶�� Ÿ�� ������ �ʱ� X�� �Ÿ� ���̸� ����Ͽ� ����
        offsetX = transform.position.x - target.position.x;
    }

    // Update�� �� �����Ӹ��� ȣ��ȴ�
    private void Update()
    {
        // ���� ����� ������ �ƹ��͵� ���� ����
        if (target == null)
        {
            return;
        }

        // ���� ī�޶� ��ġ�� ������
        Vector3 pos = transform.position;

        // ī�޶��� X ��ġ�� Ÿ�� ��ġ + �ʱ� ���������� ���� (Y�� Z�� �״�� ��)
        pos.x = target.position.x + offsetX;

        // ���� ��ġ�� ī�޶� �̵�
        transform.position = pos;
    }
}