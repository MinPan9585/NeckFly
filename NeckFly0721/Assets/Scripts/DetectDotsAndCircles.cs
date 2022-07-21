using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectDotsAndCircles : MonoBehaviour
{
    SphereCollider sphereCollider;

    void Awake()
    {
        sphereCollider = gameObject.GetComponent<SphereCollider>();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "DotsAndCircles"){
            //if(eyeFollowed){
            //    play particle
            //}
        }
    }
}
