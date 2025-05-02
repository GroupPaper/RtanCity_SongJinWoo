using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMainCamera : MonoBehaviour
{
    public Transform target; // 따라갈 대상

    public float followSpeed = 5f; // 부드럽게 따라가는 속도

    // 카메라의 이동 한계를 설정할 수 있는 변수
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

        // 카메라의 목표 위치 계산
        Vector3 desiredPosition = new Vector3(target.position.x + offsetX, target.position.y + offsetY, transform.position.z);

        // 카메라 위치 제한: Y축 상단/하단 한계 조정
        // 상단 한계: maxY, 하단 한계: minY
        desiredPosition.y = Mathf.Clamp(desiredPosition.y, minY, maxY);

        // 카메라 위치 제한: X축 좌/우 한계 조정
        desiredPosition.x = Mathf.Clamp(desiredPosition.x, minX, maxX);

        // 부드럽게 카메라 이동
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * followSpeed);
    }
}