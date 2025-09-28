using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Fade : MonoBehaviour
{
    public GameObject FadePanel; //フェードパネルの取得
    Image fadealpha; //フェードパネルのイメージ取得変数
    private float alpha; //パネルのalpha値取得変数
    private bool fadein; //フェードインのフラグ変数
    private bool fadeout; //フェードアウトのフラグ変数
    public string SceneName; //シーンの移動先変数

    private void Start()
    {
        fadealpha = FadePanel.GetComponent<Image>(); //パネルのイメージ取得
        alpha = fadealpha.color.a; //パネルのalpha値取得
        fadein = true; //シーン読み込み時にフェードイン
    }

    //フェードイン、アウトの動作条件
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

    //フェードイン処理
    void FadeIn()
    {
        alpha -= 0.01f; //alpha値変更速度
        fadealpha.color = new Color(0, 0, 0, alpha); //alpha値変更
        
        //パネルのalpha値参照の条件
        if (alpha <= 0)
        {
            fadein = false;
            FadePanel.SetActive(false);
        }
    }

    //フェードアウト処理
    void FadeOut()
    {
        alpha += 0.01f; //alpha値変更速度
        fadealpha.color = new Color(0, 0, 0, alpha); //alpha値変更

        //パネルのalpha値参照の条件
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
