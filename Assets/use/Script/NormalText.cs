using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class NormalText : MonoBehaviour
{
    [SerializeField] private Canvas HideCanvas; //表示、非表示キャンバス
    [SerializeField] private TextMeshProUGUI DialogText; //表示する文章
    [SerializeField] private GameObject TriggerObject; //クリックされたら反応するオブジェクト

    [TextArea]
    [SerializeField, Tooltip("再大三行16文字")] private string[] MessageTexts; //複数の文章を配列で設定
    [SerializeField, Tooltip("一文字ずつ表示する速さ")] public float MessageSpeed = 0.05f; //一文字ずつ表示する速さ

    private int currentMessageIndex = 0; //現在のメッセージのインデックス
    private bool isTyping = false; //現在表示中かどうか
    private bool allTextDisplayed = false; //全ての文章を表示し終えたか
    private bool isMassageActive = false; //メッセージが表示されてるかどうか

    void Start()
    {
        DialogText.text = ""; //最初にテキストを空にする

        if (HideCanvas != null)
        {
            HideCanvas.enabled = false; //起動時は非表示
        }
    }

    void Update()
    {
        //メッセージが非表示かつクリックされた時の条件
        if (!isMassageActive && Input.GetMouseButtonDown(0))
        {
            //クリックされたオブジェクトを取得
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == TriggerObject)
            {
                isMassageActive = true; // メッセージ表示フラグON
                currentMessageIndex = 0; //最初のメッセージから
                allTextDisplayed = false; //完了時フラグリセット
                DialogText.text = ""; //テキスト初期化

                if (HideCanvas != null)
                    HideCanvas.enabled = true; //キャンバス表示


                StartCoroutine(TypeDisplay(MessageTexts[currentMessageIndex])); //最初のメッセージを表示
            }
                return; //他の入力を処理しない
        }
            //左クリックが押されたときの処理
            if (Input.GetMouseButtonDown(0) && isMassageActive)
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

                //全て表示した後の処理
                if (HideCanvas != null)
                    HideCanvas.enabled = false; //キャンバスの非表示
                

                isMassageActive = false; //表示終了

                }
            }
    }

    //一文字ずつ表示
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
}
