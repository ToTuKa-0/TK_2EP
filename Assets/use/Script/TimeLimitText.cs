using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class TimeLimitText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI DialogText; //表示する文章
    [TextArea]
    [SerializeField, Tooltip("再大三行16文字")] private string[] MessageTexts; //複数の文章を配列で設定
    [SerializeField, Tooltip("一文字ずつ表示する速さ")] public float MessageSpeed; //一文字ずつ表示する速さ
    [SerializeField, Tooltip("表示後シーン移行するまでの時間")] private float SceneChangeDelay; //シーン遷移の遅延秒数
    [SerializeField] private string NextSceneName; //切り替え先のシーン名

    private int currentMessageIndex = 0; //現在のメッセージのインデックス
    private bool isTyping = false; //現在表示中かどうか
    private bool allTextDisplayed = false; //全ての文章を表示し終えたか

    void Start()
    {
        DialogText.text = ""; //最初にテキストを空にする
        StartCoroutine(TypeDisplay(MessageTexts[currentMessageIndex])); //最初のメッセージを表示
    }

    void Update()
    {
        //左クリックが押されたときの処理
        if (Input.GetMouseButtonDown(0))
        {
            //現在表示中の文字がある場合、全文を即時表示
            if (isTyping)
            {
                StopAllCoroutines();
                DialogText.text = MessageTexts[currentMessageIndex];
                isTyping = false;
            }
            //表示中でなく、次の文章がある場合
            else if (currentMessageIndex < MessageTexts.Length - 1)
            {
                currentMessageIndex++;
                DialogText.text = ""; //テキストボックスを空に
                StartCoroutine(TypeDisplay(MessageTexts[currentMessageIndex]));
            }
            //全文表示が終わっている場合（最後の文章）
            else if (!allTextDisplayed)
            {
                allTextDisplayed = true;
            }
            //最後の文章がすでに表示され、クリックされたらシーン遷移
            else
            {
                StartCoroutine(ChangeSceneAfterDelay());
            }
        }
    }

    IEnumerator TypeDisplay(string message)
    {
        isTyping = true;

        DialogText.text = ""; //テキストボックスを空に
        foreach (char item in message.ToCharArray()) //一文字ずつ表示
        {
            DialogText.text += item;
            yield return new WaitForSeconds(MessageSpeed);
        }

        isTyping = false;
    }

    IEnumerator ChangeSceneAfterDelay()
    {
        yield return new WaitForSeconds(SceneChangeDelay); //指定時間待ってから
        SceneManager.LoadScene(NextSceneName); //シーン遷移
    }
}
