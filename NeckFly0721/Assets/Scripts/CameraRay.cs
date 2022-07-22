using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraRay : MonoBehaviour
{
    GameObject butterfly;
    DOTweenPath butterflyPath;

    public bool eyeFollowed = false;

    void Awake(){
        butterfly = GameObject.Find("ButterflyPath1");
        butterflyPath = butterfly.GetComponent<DOTweenPath>();
        
    }

    void Start(){
        butterflyPath.DOPlay();
    }

    void Update()
    {
        RaycastHit[] hits;
        //换一个重载，只检测蝴蝶身上的两个collider
        hits = Physics.RaycastAll(transform.position, transform.forward, 100f);

        if(hits.Length>0){
            
            eyeFollowed = true;

            //success, toggle on animation and vfx
            if(hits.Length == 2){
                //corresponding vfx, add score
            }
            if(hits.Length == 1){
                //corresponding vfx, add score
            }
        }
        
        else{
            //fail, toggle anim and vfx
            eyeFollowed = false;

        }
    }

    
}
