using System;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random; // Unity의 Random 클래스를 명시적으로 사용

public class Obstacle : MonoBehaviour
{
    // 장애물의 중앙 홀의 수직 위치가 생성될 수 있는 범위
    public float highPosY = 1f;  // 생성 가능한 최대 높이
    public float lowPosY = -1f;  // 생성 가능한 최소 높이

    // 크기 범위
    public float holeSizeMin = 1f;  // 최소 홀 크기
    public float holeSizeMax = 3f;  // 최대 홀 크기

    // 위쪽과 아래쪽 장애물의 Transform
    public Transform topObject;     // 위쪽 장애물 오브젝트
    public Transform bottomObject;  // 아래쪽 장애물 오브젝트

    // 장애물 간 수평 간격
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