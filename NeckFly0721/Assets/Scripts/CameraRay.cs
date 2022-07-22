using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraRay : MonoBehaviour
{
    GameObject butterfly;
    DOTweenPath butterflyPath;

    CapsuleCollider capsuleCollider;
    public List<GameObject> TriggerObj = new List<GameObject>();


    public bool eyeFollowed = false;

    void Awake(){
        butterfly = GameObject.Find("ButterflyPath1");
        butterflyPath = butterfly.GetComponent<DOTweenPath>();
        
        capsuleCollider = gameObject.GetComponent<CapsuleCollider>();
    }

    void Start(){
        butterflyPath.DOPlay();
    }

    private void OnTriggerEnter(Collider other) {
        //list ++
        if(other.tag == "Butterfly")
        {
            if(!TriggerObj.Contains(other.gameObject))
            {
                TriggerObj.Add(other.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        //list --
        if(other.tag == "Butterfly")
        {
            if(!TriggerObj.Contains(other.gameObject))
            {
                TriggerObj.Remove(other.gameObject);
            }
        }
    }

    void Update()
    {
        //RaycastHit[] hits;
        //换一个重载，只检测蝴蝶身上的两个collider
        //hits = Physics.RaycastAll(transform.position, transform.forward, 100f);

        if(TriggerObj.Count>0){
            
            eyeFollowed = true;

            //success, toggle on animation and vfx
            if(TriggerObj.Count == 2){
                //corresponding vfx, add score
            }
            if(TriggerObj.Count == 1){
                //corresponding vfx, add score
            }
        }
        
        else{
            //fail, toggle anim and vfx
            eyeFollowed = false;

        }
    }
}
