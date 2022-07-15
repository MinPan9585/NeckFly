using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraRay : MonoBehaviour
{
    GameObject butterfly;
    DOTweenPath butterflyPath;

    void Awake(){
        butterfly = GameObject.Find("ButterflyPath1");
        butterflyPath = butterfly.GetComponent<DOTweenPath>();
    }

    void Update()
    {
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.forward, 100f);

        if(hits.Length>0){
            butterflyPath.DOPlay();


            //success, toggle on animation and vfx
            if(hits.Length == 3){
                //corresponding vfx, add score
            }
            else if(hits.Length == 2){
                //corresponding vfx, add score
            }
            else if(hits.Length == 1){
                //corresponding vfx, add score
            }
        }
        
        else{
            //fail, toggle off anim and vfx
            butterflyPath.DOTogglePause();
        }
    }
}
