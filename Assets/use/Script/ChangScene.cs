using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangScene : MonoBehaviour
{
    public string sceneName; //移行先のシーン

    //シーン変更
    public void SceneChanger()
    {
        SceneManager.LoadScene(sceneName);
    }
}
