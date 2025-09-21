using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    //ゲーム終了処理
    public void EndGame()
    {
#if UNITY_EDITOR //条件付きコンパイル
        UnityEditor.EditorApplication.isPlaying = false; //ゲーム強制終了
#else
    Application.Quit(); //アプリの終了
#endif
    }
}