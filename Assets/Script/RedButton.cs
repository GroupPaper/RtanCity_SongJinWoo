using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButton : MonoBehaviour
{
    private bool isPlayerInRange = false;

    // ��ȣ�ۿ� �ڽ� ������Ʈ (Up)
    private GameObject upSprite;
    private GameObject fKeydown;

    private void Start()
    {
        // �ڽ� �� �̸��� Up �� ������Ʈ ã��
        upSprite = transform.Find("Up").gameObject;
        fKeydown = transform.Find("F").gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collider) // is trigger�� üũ�� �ݶ��̴��� ����������
    {
        if (collider.CompareTag("Player")) // ������Ʈ �±װ� Player�� Ȱ��
        {
            isPlayerInRange = true;
            fKeydown.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collider) // is trigger�� üũ�� �ݶ��̴��� ����������
    {
        if (collider.CompareTag("Player")) // ������Ʈ �±� Player�� ����� ��Ȱ��
        {
            isPlayerInRange = false;
            fKeydown.SetActive(false);
        }
    }

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.F)) // �����ȿ� ���� �÷��̾ F�� ������ ����
        {
            Interact();
        }
    }

    void Interact()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (upSprite != null)
        {
            upSprite.SetActive(false); // Up ������Ʈ ��Ȱ��
            StartCoroutine(ButtonDelay(1)); // false ��, n�� �ڿ� true�� �ڵ� Ȱ��
            
            // ���ӷ����� ���� ������ ��ŸƮ �ڷ�ƾ���� ȣ���ؾ� �۵��Ѵٰ� ��
        }
        if (player != null)
        {
            player.transform.position = new Vector3(0f, 0f, player.transform.position.z);  // �÷��̾� �ش� ������ �̵�
            // Vector2�� x,y ���� 0���� �ص� ������, z���� ����ϴ� ī�޶���� ������ ���� �� �־� ���ִ°� ���ٰ� ��.
        }

        // ���⿡ ȸ���ϴ� �̴ϰ����� �߰��ϴ°� ������?
    }

    IEnumerator ButtonDelay(int delay) // ������ �� �ش� ��������Ʈ true�� �ٲٴ� ����
    {
        yield return new WaitForSeconds(delay);
        upSprite.SetActive(true);
    }
}