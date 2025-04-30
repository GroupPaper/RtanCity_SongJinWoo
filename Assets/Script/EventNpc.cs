using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventNpc : MonoBehaviour
{
    public float Duration = 1f; // 흔들리는 시간
    public float Magnitude = 0.5f; // 흔들림 강도

    private bool isPlayerInRange = false; // 상호작용 범위
    private bool isShaking = false; // 중복 흔들림 방지용

    private GameObject fKeydown; // F키 안내 ui

    private void Start()
    {
        fKeydown = transform.Find("F").gameObject;

        if (fKeydown != null)
        {
            fKeydown.SetActive(false); // 처음엔 비활성
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            isPlayerInRange = true;
            if (fKeydown != null) fKeydown.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            isPlayerInRange = false;
            if (fKeydown != null) fKeydown.SetActive(false);
        }
    }

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.F)) // 플레이어가 범위안에 들어와 F 키 눌렀을때
        {
            Interact(); // 호출
        }
    }

    private void Interact()
    {
        if (!isShaking && Camera.main != null) // 메인 카메라 있는지 확인
        {
            StartCoroutine(Shake(Camera.main.transform)); // 메인 카메라를 흔들어잇
        }
    }

    IEnumerator Shake(Transform camTransform)
    {
        isShaking = true;

        Vector3 nomarCamera = camTransform.localPosition;
        float time = 0f;

        while (time <= Duration) // 0초부터 설정한 시간까지 흔들기
        {
            float x = Random.Range(-1f, 1f) * Magnitude;
            float y = Random.Range(-1f, 1f) * Magnitude;

            camTransform.localPosition = nomarCamera + new Vector3(x, y, 0f);

            time += Time.deltaTime; // 흔드는 시간 측정
            yield return null; // 프레임 단위로 흔들리게 하기 위해서 있어야 한다고 함
        }

        camTransform.localPosition = nomarCamera; // 기본 세팅값으로 복구
        isShaking = false; // 흔들림 정지
    }
}