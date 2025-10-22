using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class NormalText : MonoBehaviour
{
    [SerializeField] private Canvas HideCanvas; //�\���A��\���L�����o�X
    [SerializeField] private TextMeshProUGUI DialogText; //�\�����镶��
    [SerializeField] private GameObject TriggerObject; //�N���b�N���ꂽ�甽������I�u�W�F�N�g

    [TextArea]
    [SerializeField, Tooltip("�đ�O�s16����")] private string[] MessageTexts; //�����̕��͂�z��Őݒ�
    [SerializeField, Tooltip("�ꕶ�����\�����鑬��")] public float MessageSpeed = 0.05f; //�ꕶ�����\�����鑬��

    private int currentMessageIndex = 0; //���݂̃��b�Z�[�W�̃C���f�b�N�X
    private bool isTyping = false; //���ݕ\�������ǂ���
    private bool allTextDisplayed = false; //�S�Ă̕��͂�\�����I������
    private bool isMassageActive = false; //���b�Z�[�W���\������Ă邩�ǂ���

    void Start()
    {
        DialogText.text = ""; //�ŏ��Ƀe�L�X�g����ɂ���

        if (HideCanvas != null)
        {
            HideCanvas.enabled = false; //�N�����͔�\��
        }
    }

    void Update()
    {
        //���b�Z�[�W����\�����N���b�N���ꂽ���̏���
        if (!isMassageActive && Input.GetMouseButtonDown(0))
        {
            //�N���b�N���ꂽ�I�u�W�F�N�g���擾
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == TriggerObject)
            {
                isMassageActive = true; // ���b�Z�[�W�\���t���OON
                currentMessageIndex = 0; //�ŏ��̃��b�Z�[�W����
                allTextDisplayed = false; //�������t���O���Z�b�g
                DialogText.text = ""; //�e�L�X�g������

                if (HideCanvas != null)
                    HideCanvas.enabled = true; //�L�����o�X�\��


                StartCoroutine(TypeDisplay(MessageTexts[currentMessageIndex])); //�ŏ��̃��b�Z�[�W��\��
            }
                return; //���̓��͂��������Ȃ�
        }
            //���N���b�N�������ꂽ�Ƃ��̏���
            if (Input.GetMouseButtonDown(0) && isMassageActive)
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

                //�S�ĕ\��������̏���
                if (HideCanvas != null)
                    HideCanvas.enabled = false; //�L�����o�X�̔�\��
                

                isMassageActive = false; //�\���I��

                }
            }
    }

    //�ꕶ�����\��
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
}
