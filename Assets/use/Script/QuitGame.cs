using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    //�Q�[���I������
    public void EndGame()
    {
#if UNITY_EDITOR //�����t���R���p�C��
        UnityEditor.EditorApplication.isPlaying = false; //�Q�[�������I��
#else
    Application.Quit(); //�A�v���̏I��
#endif
    }
}