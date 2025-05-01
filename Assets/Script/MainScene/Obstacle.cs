using System;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random; // Unity�� Random Ŭ������ ��������� ���

public class Obstacle : MonoBehaviour
{
    // ��ֹ��� �߾� Ȧ�� ���� ��ġ�� ������ �� �ִ� ����
    public float highPosY = 1f;  // ���� ������ �ִ� ����
    public float lowPosY = -1f;  // ���� ������ �ּ� ����

    // ũ�� ����
    public float holeSizeMin = 1f;  // �ּ� Ȧ ũ��
    public float holeSizeMax = 3f;  // �ִ� Ȧ ũ��

    // ���ʰ� �Ʒ��� ��ֹ��� Transform
    public Transform topObject;     // ���� ��ֹ� ������Ʈ
    public Transform bottomObject;  // �Ʒ��� ��ֹ� ������Ʈ

    // ��ֹ� �� ���� ����
    public float widthPadding = 4f;

    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstacleCount)
    {
        float holeSize = Random.Range(holeSizeMin, holeSizeMax);
        float halfHoleSize = holeSize / 2f;

        topObject.localPosition = new Vector3(0, halfHoleSize);
        bottomObject.localPosition = new Vector3(0, -halfHoleSize);

        float randomX = Random.Range(widthPadding * 0.8f, widthPadding * 1.2f);
        Vector3 placePosition = lastPosition + new Vector3(randomX, 0);
        placePosition.y = Random.Range(lowPosY, highPosY);

        transform.localPosition = placePosition;

        return placePosition;
    }
}