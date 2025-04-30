using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventNpc : MonoBehaviour
{
    public float Duration = 1f; // ��鸮�� �ð�
    public float Magnitude = 0.5f; // ��鸲 ����

    private bool isPlayerInRange = false; // ��ȣ�ۿ� ����
    private bool isShaking = false; // �ߺ� ��鸲 ������

    private GameObject fKeydown; // FŰ �ȳ� ui

    private void Start()
    {
        fKeydown = transform.Find("F").gameObject;

        if (fKeydown != null)
        {
            fKeydown.SetActive(false); // ó���� ��Ȱ��
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
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.F)) // �÷��̾ �����ȿ� ���� F Ű ��������
        {
            Interact(); // ȣ��
        }
    }

    private void Interact()
    {
        if (!isShaking && Camera.main != null) // ���� ī�޶� �ִ��� Ȯ��
        {
            StartCoroutine(Shake(Camera.main.transform)); // ���� ī�޶� ������
        }
    }

    IEnumerator Shake(Transform camTransform)
    {
        isShaking = true;

        Vector3 nomarCamera = camTransform.localPosition;
        float time = 0f;

        while (time <= Duration) // 0�ʺ��� ������ �ð����� ����
        {
            float x = Random.Range(-1f, 1f) * Magnitude;
            float y = Random.Range(-1f, 1f) * Magnitude;

            camTransform.localPosition = nomarCamera + new Vector3(x, y, 0f);

            time += Time.deltaTime; // ���� �ð� ����
            yield return null; // ������ ������ ��鸮�� �ϱ� ���ؼ� �־�� �Ѵٰ� ��
        }

        camTransform.localPosition = nomarCamera; // �⺻ ���ð����� ����
        isShaking = false; // ��鸲 ����
    }
}