using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RedButton : MonoBehaviour
{
    private bool isPlayerInRange = false;

    // 상호작용 자식 오브젝트 (Up)
    private GameObject upSprite;
    private GameObject fKeydown;

    public GameObject maincamera;
    public GameObject minicamera;

    public GameObject player;
    public GameObject miniplayer;

    public Rigidbody2D prb;

    private void Start()
    {
        // 자식 중 이름이 Up 인 오브젝트 찾기
        upSprite = transform.Find("Up").gameObject;
        fKeydown = transform.Find("F").gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collider) // is trigger가 체크된 콜라이더에 범위안으로
    {
        if (collider.CompareTag("Player")) // 오브젝트 태그가 Player면 활성
        {
            isPlayerInRange = true;
            fKeydown.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collider) // is trigger가 체크된 콜라이더에 범위밖으로
    {
        if (collider.CompareTag("Player")) // 오브젝트 태그 Player가 벗어나면 비활성
        {
            isPlayerInRange = false;
            fKeydown.SetActive(false);
        }
    }

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.F)) // 범위안에 들어온 플레이어가 F를 누르면 실행
        {
            Interact();
        }
    }

    void Interact()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (upSprite != null)
        {
            upSprite.SetActive(false); // Up 오브젝트 비활성
            StartCoroutine(ButtonDelay(1)); // false 후, n초 뒤에 true로 자동 활성

            // 뉴머레이터 같은 변수는 스타트 코룬틴으로 호출해야 작동한다고 함
        }
        if (player != null)
        {
            player.SetActive(false);
            maincamera.SetActive(false);

            miniplayer.SetActive(true);
            minicamera.SetActive(true);
            MiniGameManager.Instance.GameMenu();
        }

        // 여기에 회피하는 미니게임을 추가하는게 좋을듯?
    }

    IEnumerator ButtonDelay(int delay) // 딜레이 후 해당 스프라이트 true로 바꾸는 변수
    {
        yield return new WaitForSeconds(delay);
        upSprite.SetActive(true);
    }
}