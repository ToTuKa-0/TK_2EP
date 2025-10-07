using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class TimeLimitText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI DialogText; //�\�����镶��
    [TextArea]
    [SerializeField, Tooltip("�đ�O�s16����")] private string[] MessageTexts; //�����̕��͂�z��Őݒ�
    [SerializeField, Tooltip("�ꕶ�����\�����鑬��")] public float MessageSpeed; //�ꕶ�����\�����鑬��
    [SerializeField, Tooltip("�\����V�[���ڍs����܂ł̎���")] private float SceneChangeDelay; //�V�[���J�ڂ̒x���b��
    [SerializeField] private string NextSceneName; //�؂�ւ���̃V�[����

    private int currentMessageIndex = 0; //���݂̃��b�Z�[�W�̃C���f�b�N�X
    private bool isTyping = false; //���ݕ\�������ǂ���
    private bool allTextDisplayed = false; //�S�Ă̕��͂�\�����I������

    void Start()
    {
        DialogText.text = ""; //�ŏ��Ƀe�L�X�g����ɂ���
        StartCoroutine(TypeDisplay(MessageTexts[currentMessageIndex])); //�ŏ��̃��b�Z�[�W��\��
    }

    void Update()
    {
        //���N���b�N�������ꂽ�Ƃ��̏���
        if (Input.GetMouseButtonDown(0))
        {
            //���ݕ\�����̕���������ꍇ�A�S���𑦎��\��
            if (isTyping)
            {
                StopAllCoroutines();
                DialogText.text = MessageTexts[currentMessageIndex];
                isTyping = false;
            }
            //�\�����łȂ��A���̕��͂�����ꍇ
            else if (currentMessageIndex < MessageTexts.Length - 1)
            {
                currentMessageIndex++;
                DialogText.text = ""; //�e�L�X�g�{�b�N�X�����
                StartCoroutine(TypeDisplay(MessageTexts[currentMessageIndex]));
            }
            //�S���\�����I����Ă���ꍇ�i�Ō�̕��́j
            else if (!allTextDisplayed)
            {
                allTextDisplayed = true;
            }
            //�Ō�̕��͂����łɕ\������A�N���b�N���ꂽ��V�[���J��
            else
            {
                StartCoroutine(ChangeSceneAfterDelay());
            }
        }
    }

    IEnumerator TypeDisplay(string message)
    {
        isTyping = true;

        DialogText.text = ""; //�e�L�X�g�{�b�N�X�����
        foreach (char item in message.ToCharArray()) //�ꕶ�����\��
        {
            DialogText.text += item;
            yield return new WaitForSeconds(MessageSpeed);
        }

        isTyping = false;
    }

    IEnumerator ChangeSceneAfterDelay()
    {
        yield return new WaitForSeconds(SceneChangeDelay); //�w�莞�ԑ҂��Ă���
        SceneManager.LoadScene(NextSceneName); //�V�[���J��
    }
}
