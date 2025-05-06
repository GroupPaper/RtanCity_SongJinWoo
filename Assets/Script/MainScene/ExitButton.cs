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
#if UNITY_EDITOR // 에디터에서만 실행되는 조건
        UnityEditor.EditorApplication.isPlaying = false;

#else // 에디터 아니면(빌드시?)
        Application.Quit();


#endif // 이걸로 끝나야 문법 완성이 돼나봄
    }
}