using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using UnityEngine.SocialPlatforms;
using UnityEngine.SceneManagement;

public class Gameloop : MonoBehaviour
{
    public GameObject startUI;
    public GameObject endUI;
    public GameObject startBtn;
    public GameObject endBtn;
    public GameObject PointsText;
    public GameObject PointsImg;
    public GameObject UIButterfly;
    public CameraRay camera_Ray;
    private float points;
    public DOTweenPath butterflyAnim;
    public DOTweenPath butterflyPath;
    bool animationPlayed = false;
    float gameStartTime = 0f;
    bool gameStarted = false;
    bool gameEnd = false;
    float gameEndTime=0f;
    Tween t;

    void Awake(){
        t = butterflyAnim.GetTween();
    }

    void Start()
    {
        Time.timeScale = 5f;
        //初始化
        endUI.SetActive(false);
        startUI.SetActive(true);

        //点击开始界面按钮
        startBtn.GetComponent<Button>().onClick.AddListener(() =>
        {
            startUI.SetActive(false);
            //开始蝴蝶运动
            UIButterfly.SetActive(false);
            butterflyAnim.gameObject.SetActive(true);
            butterflyPath.gameObject.SetActive(true);
            butterflyPath.DOPlay();
            gameStartTime = Time.time;
            gameEndTime = gameStartTime + 117.9f;
            gameStarted = true;
        });

        // t.OnComplete(() =>
        //     EnterEndPhase(CameraRay.smallColliderTime,
        //     CameraRay.bigColliderTime, CameraRay.totalTime));

        //点击结束界面按钮
        endBtn.GetComponent<Button>().onClick.AddListener(() =>
        {
            SceneManager.LoadScene("SceneAnimationPath");
            //结束蝴蝶运动
            // butterflyAnim.gameObject.SetActive(false);
            // butterflyPath.gameObject.SetActive(false);
            // //重新显示开始界面
            // endUI.SetActive(false);
            // startUI.SetActive(true);
        });
    }



    //蝴蝶结束进入结算阶段
    void EnterEndPhase(float smallColliderTime, float bigColliderTime, float totalTime)
    {
        //Debug.Log("small"+smallColliderTime);
        //Debug.Log("big"+bigColliderTime);
        //Debug.Log("total"+totalTime);
        butterflyAnim.gameObject.SetActive(false);
        butterflyPath.gameObject.SetActive(false);
        //展示结算动画
        startUI.SetActive(false);
        endUI.SetActive(true);
        endBtn.SetActive(false);
        points = 0.9f * smallColliderTime / totalTime + 0.6f * bigColliderTime / totalTime;
        StartCoroutine(CalAnimation(points));
    }

    public IEnumerator CalAnimation(float _points)
    {
        float pp = 0f;
        int pp_int = 0;
        Debug.Log("points:"+_points);
        while (pp < _points)
        {
            pp += Time.deltaTime * 1.5f / _points * 0.1f;
            pp_int = (int) (pp*100);
            PointsImg.GetComponent<Image>().fillAmount = pp;
            PointsText.GetComponent<Text>().text = pp_int.ToString()+"%";
            Debug.Log("pp:"+pp);
            yield return null;
        }
        endBtn.SetActive(true);
    }

    void Update()
    {
        if (Time.time - gameStartTime >= 2.25f
        && gameStarted && !animationPlayed)
        {
            butterflyAnim.DOPlay();
            
            animationPlayed = true;
        }

        if(gameEndTime> 0 && Time.time>gameEndTime && !gameEnd)
        {
            EnterEndPhase(CameraRay.smallColliderTime,
                CameraRay.bigColliderTime, 115f);
            gameStarted = false;
            animationPlayed = false;
            gameEnd = true;
        }
    }
}
