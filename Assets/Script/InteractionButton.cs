using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionButton : MonoBehaviour
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

    private void OnTriggerEnter2D(Collider2D other) // is trigger�� üũ�� �ݶ��̴��� ����������
    {
        if (other.CompareTag("Player")) // ������Ʈ �±װ� Player�� Ȱ��
        {
            isPlayerInRange = true;
            fKeydown.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) // is trigger�� üũ�� �ݶ��̴��� ����������
    {
        if (other.CompareTag("Player")) // ������Ʈ �±� Player�� ����� ��Ȱ��
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
        if (upSprite != null)
        {
            upSprite.SetActive(false); // Up ������Ʈ ��Ȱ��
            StartCoroutine(ButtonDelay(1)); // false ��, n�� �ڿ� true�� �ڵ� Ȱ��
            // ���ӷ����� ���� ������ ��ŸƮ �ڷ�ƾ���� ȣ���ؾ� �۵��Ѵٰ� ��
        }

        // �̴ϰ��� ����� ��� �߰�����?
    }

    IEnumerator ButtonDelay(int delay) // ������ �� �ش� ��������Ʈ true�� �ٲٴ� ����
    {
        yield return new WaitForSeconds(delay);
        upSprite.SetActive(true);
    }
}