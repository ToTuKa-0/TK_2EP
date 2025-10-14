using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangScene : MonoBehaviour
{
    public string sceneName; //�ڍs��̃V�[��
    public float delayTime = 0.0f; //���s�̒x��

    //�V�[���ύX
    public void SceneChanger()
    {
        StartCoroutine(DelayedSceneChange());
    }

    //�V�[���ύX����莞�Ԓx�点��R���[�`��
    private IEnumerator DelayedSceneChange()
    {
        yield return new WaitForSeconds(delayTime); //�w�莞�ԑҋ@
        SceneManager.LoadScene(sceneName); //�w��V�[���ɐ؂�ւ�
    }
}
