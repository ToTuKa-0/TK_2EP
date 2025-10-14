using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangScene : MonoBehaviour
{
    public string sceneName; //移行先のシーン
    public float delayTime = 0.0f; //実行の遅延

    //シーン変更
    public void SceneChanger()
    {
        StartCoroutine(DelayedSceneChange());
    }

    //シーン変更を一定時間遅らせるコルーチン
    private IEnumerator DelayedSceneChange()
    {
        yield return new WaitForSeconds(delayTime); //指定時間待機
        SceneManager.LoadScene(sceneName); //指定シーンに切り替え
    }
}
