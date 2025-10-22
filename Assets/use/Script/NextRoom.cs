using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextRoom : MonoBehaviour
{
    [SerializeField] private string NextSceneName; //移行先シーン名を入れる

    void Update()
    {
        //左クリックされた時の条件
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //クリック地点をスクリーンからワールド座標に
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero); //クリック地点にレイ(光線)を飛ばしクリックされたか確認

            //何にクリックされたかの確認条件
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                // クリックされたオブジェクトがこのスクリプトを持つオブジェクトなら
                LoadTargetScene();
            }
        }
    }

    private void LoadTargetScene()
    {
        //シーン読み込み処理
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
