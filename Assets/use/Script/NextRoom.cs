using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextRoom : MonoBehaviour
{
    [SerializeField] private string NextSceneName; //�ڍs��V�[����������

    void Update()
    {
        //���N���b�N���ꂽ���̏���
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //�N���b�N�n�_���X�N���[�����烏�[���h���W��
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero); //�N���b�N�n�_�Ƀ��C(����)���΂��N���b�N���ꂽ���m�F

            //���ɃN���b�N���ꂽ���̊m�F����
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                // �N���b�N���ꂽ�I�u�W�F�N�g�����̃X�N���v�g�����I�u�W�F�N�g�Ȃ�
                LoadTargetScene();
            }
        }
    }

    private void LoadTargetScene()
    {
        //�V�[���ǂݍ��ݏ���
        if (!string.IsNullOrEmpty(NextSceneName))
        {
            SceneManager.LoadScene(NextSceneName);
        }
        else
        {
            Debug.LogWarning("Scene name is not set.");
        }
    }
}
