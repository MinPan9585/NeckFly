using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using UnityEngine.SocialPlatforms;

public class Gameloop : MonoBehaviour
{
    public GameObject startUI;
    public GameObject endUI;
    public GameObject startBtn;
    public GameObject endBtn;
    public GameObject PointsText;
    public GameObject PointsImg;
    private float points;
    void Start()
    {
        //初始化
        endUI.SetActive(false);
        startUI.SetActive(true);
        
        //点击开始界面按钮
        startBtn.GetComponent<Button>().onClick.AddListener(() =>
        {
            startUI.SetActive(false);
            //开始蝴蝶运动
            
        });
        
        //点击结束界面按钮
        endBtn.GetComponent<Button>().onClick.AddListener(() =>
        {
            //结束蝴蝶运动
            
            //重新显示开始界面
            endUI.SetActive(false);
            startUI.SetActive(true);
        });
    }

    //蝴蝶结束进入结算阶段
    void EnterEndPhase(float smallColliderTime, float bigColliderTime, float totalTime)
    {
        //展示结算动画
        endUI.SetActive(true);
        endBtn.SetActive(false);
        points = smallColliderTime / totalTime * 0.9f + bigColliderTime / totalTime * 0.6f;
        float tt = 1.5f / points;
        StartCoroutine(CalAnimation(tt));
    }

    public IEnumerator CalAnimation(float _points)
    {
        float pp = 0f;
        while (pp < _points)
        {
            pp += Time.deltaTime * 1.5f/_points * 0.01f;
            PointsImg.GetComponent<Image>().fillAmount = pp;
            PointsText.GetComponent<TextMeshPro>().text = string.Format("0:0.#", pp * 100) + "%";
            yield return null;
        }
        endBtn.SetActive(true);
    }
    
    void Update()
    {
        
    }
}
