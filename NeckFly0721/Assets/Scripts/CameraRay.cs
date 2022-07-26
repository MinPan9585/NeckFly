using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraRay : MonoBehaviour
{
    public DOTweenPath butterflyPath;

    CapsuleCollider capsuleCollider;
    public List<GameObject> TriggerObj = new List<GameObject>();

    ParticleSystem goodFollowFX;
    ParticleSystem normalFollowFX;
    public bool eyeFollowed = false;

    public static float smallColliderTime;
    public static float bigColliderTime;
    public static float totalTime;

    public Animator eyeFollowButterfly;

    void Awake()
    {
        capsuleCollider = gameObject.GetComponent<CapsuleCollider>();

        //goodFollowFX = GameObject.Find("Glow_Good").GetComponent<ParticleSystem>();
        //normalFollowFX = GameObject.Find("Glow_Bad").GetComponent<ParticleSystem>();
    }

    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        //list ++
        //Debug.Log("bbb");
        if (other.tag == "Butterfly")
        {
            if (!TriggerObj.Contains(other.gameObject))
            {
                TriggerObj.Add(other.gameObject);
                //print("aaa");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Butterfly")
        {
            if (TriggerObj.Contains(other.gameObject))
            {
                TriggerObj.Remove(other.gameObject);
            }
        }
    }

    void Update()
    {
        if (TriggerObj.Count > 0)
        {
            eyeFollowed = true;
            if (TriggerObj.Count == 2)
            {
                //corresponding vfx, add score
                //goodFollowFX.gameObject.SetActive(true);
                //normalFollowFX.gameObject.SetActive(false);
                eyeFollowButterfly.SetInteger("LayerTriggers", 2);
                smallColliderTime += Time.deltaTime;

                //Debug.Log("a");
            }
            if (TriggerObj.Count == 1)
            {
                //corresponding vfx, add score
                //goodFollowFX.gameObject.SetActive(false);
                //normalFollowFX.gameObject.SetActive(true);
                bigColliderTime += Time.deltaTime;
                eyeFollowButterfly.SetInteger("LayerTriggers", 1);
                //Debug.Log("b");
            }
        }
        else
        {
            eyeFollowed = false;
            //goodFollowFX.gameObject.SetActive(false);
            //normalFollowFX.gameObject.SetActive(false);
            eyeFollowButterfly.SetInteger("LayerTriggers", 0);
            //Debug.Log("c");
        }
    }
}
