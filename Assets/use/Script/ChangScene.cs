using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangScene : MonoBehaviour
{
    public string sceneName; //�ڍs��̃V�[��

    //�V�[���ύX
    public void SceneChanger()
    {
        SceneManager.LoadScene(sceneName);
    }
}
