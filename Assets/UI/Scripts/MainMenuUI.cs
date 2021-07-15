using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public void OnClickonlineButton()
    {
        Debug.Log("Click Online");
    }
    public void OnClickQuitButton()
    {
        //에디터에서 실행된 상태라면 플레이를 중단
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        //빌드된 상태라면 어플리케이션을 종료
#else
        Application.Quit();
#endif
    }
}
