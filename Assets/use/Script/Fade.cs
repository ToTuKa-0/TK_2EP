using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Fade : MonoBehaviour
{
    public GameObject FadePanel; //�t�F�[�h�p�l���̎擾
    Image fadealpha; //�t�F�[�h�p�l���̃C���[�W�擾�ϐ�
    private float alpha; //�p�l����alpha�l�擾�ϐ�
    private bool fadein; //�t�F�[�h�C���̃t���O�ϐ�
    private bool fadeout; //�t�F�[�h�A�E�g�̃t���O�ϐ�
    public string SceneName; //�V�[���̈ړ���ϐ�

    private void Start()
    {
        fadealpha = FadePanel.GetComponent<Image>(); //�p�l���̃C���[�W�擾
        alpha = fadealpha.color.a; //�p�l����alpha�l�擾
        fadein = true; //�V�[���ǂݍ��ݎ��Ƀt�F�[�h�C��
    }

    //�t�F�[�h�C���A�A�E�g�̓������
    void Update()
    {
        if (fadein == true)
        {
            FadeIn();
        }
        else if (fadeout == true)
        {
            FadeOut();
        }
    }

    //�t�F�[�h�C������
    void FadeIn()
    {
        alpha -= 0.01f; //alpha�l�ύX���x
        fadealpha.color = new Color(0, 0, 0, alpha); //alpha�l�ύX
        
        //�p�l����alpha�l�Q�Ƃ̏���
        if (alpha <= 0)
        {
            fadein = false;
            FadePanel.SetActive(false);
        }
    }

    //�t�F�[�h�A�E�g����
    void FadeOut()
    {
        alpha += 0.01f; //alpha�l�ύX���x
        fadealpha.color = new Color(0, 0, 0, alpha); //alpha�l�ύX

        //�p�l����alpha�l�Q�Ƃ̏���
        if (alpha >= 1)
        {
            fadeout = false;
            SceneManager.LoadScene(SceneName);
        }
    }

    public void SceneMove()
    {
        fadeout = true;
        FadePanel.SetActive(true);
    }
}
