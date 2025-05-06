using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    public Button exitButton;

    public void Start()
    {
        exitButton.onClick.AddListener(Exit);
    }

    public void Exit()
    {
#if UNITY_EDITOR // �����Ϳ����� ����Ǵ� ����
        UnityEditor.EditorApplication.isPlaying = false;

#else // ������ �ƴϸ�(�����?)
        Application.Quit();


#endif // �̰ɷ� ������ ���� �ϼ��� �ų���
    }
}