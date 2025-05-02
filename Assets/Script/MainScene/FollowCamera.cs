using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// FollowCamera 클래스는 카메라가 지정된 타겟(Transform)을 따라가도록 만드는 기능을 한다.
public class FollowCamera : MonoBehaviour
{
    // 따라갈 대상(예: 플레이어 캐릭터)을 지정하는 public 변수
    public Transform target;

    // 타겟과 카메라 사이의 X축 거리 오프셋 (초기 위치 차이 저장)
    float offsetX;

    // Start는 게임이 시작될 때 한 번만 호출된다
    private void Start()
    {
        // 만약 따라갈 대상이 설정되지 않았다면, 함수 종료
        if (target == null)
        {
            return;
        }

        // 카메라와 타겟 사이의 초기 X축 거리 차이를 계산하여 저장
        offsetX = transform.position.x - target.position.x;
    }

    // Update는 매 프레임마다 호출된다
    private void Update()
    {
        // 따라갈 대상이 없으면 아무것도 하지 않음
        if (target == null)
        {
            return;
        }

        // 현재 카메라 위치를 가져옴
        Vector3 pos = transform.position;

        // 카메라의 X 위치를 타겟 위치 + 초기 오프셋으로 설정 (Y와 Z는 그대로 둠)
        pos.x = target.position.x + offsetX;

        // 계산된 위치로 카메라 이동
        transform.position = pos;
    }
}