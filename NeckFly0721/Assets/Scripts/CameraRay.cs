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

    ParticleSystem goodFollowFX;
    ParticleSystem normalFollowFX;

    bool animationPlayed = false;

    public bool eyeFollowed = false;

    void Awake(){
        butterfly = GameObject.Find("ButterflyPath1");
        butterflyPath = butterfly.GetComponent<DOTweenPath>();
        
        capsuleCollider = gameObject.GetComponent<CapsuleCollider>();

        goodFollowFX = GameObject.Find("Glow_Good").GetComponent<ParticleSystem>();
        normalFollowFX = GameObject.Find("Glow_Bad").GetComponent<ParticleSystem>();
    }

    void Start(){
        
    }

    private void OnTriggerEnter(Collider other) {
        //list ++
        Debug.Log("bbb");
        if(other.tag == "Butterfly")
        {
            if(!TriggerObj.Contains(other.gameObject))
            {
                TriggerObj.Add(other.gameObject);
                print("aaa");
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag == "Butterfly")
        {
            if(TriggerObj.Contains(other.gameObject))
            {
                TriggerObj.Remove(other.gameObject);
            }
        }
    }

    void Update()
    {
        if(Time.time >= 2.25f && animationPlayed == false){
            butterflyPath.DOPlay();
            animationPlayed = true;
        }

        //RaycastHit[] hits;
        //换一个重载，只检测蝴蝶身上的两个collider
        //hits = Physics.RaycastAll(transform.position, transform.forward, 100f);

        if(TriggerObj.Count>0){
            eyeFollowed = true;
            if(TriggerObj.Count == 2){
                //corresponding vfx, add score
                goodFollowFX.gameObject.SetActive(true);
                normalFollowFX.gameObject.SetActive(false);
            }
            if(TriggerObj.Count == 1){
                //corresponding vfx, add score
                goodFollowFX.gameObject.SetActive(false);
                normalFollowFX.gameObject.SetActive(true);
            }
        }
        else{
            eyeFollowed = false;
            goodFollowFX.gameObject.SetActive(false);
            normalFollowFX.gameObject.SetActive(false);
        }
    }
}
