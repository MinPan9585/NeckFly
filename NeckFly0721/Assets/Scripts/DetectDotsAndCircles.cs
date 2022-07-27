using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectDotsAndCircles : MonoBehaviour
{
    SphereCollider sphereCollider;
    CameraRay cameraRay;

    AudioSource bgAudio;
    AudioSource dotsAudio;
    AudioSource circlesAudio_s1;
    AudioSource circlesAudio_s2;
    AudioSource circlesAudio_s3;
    AudioSource circlesAudio_s4;
    AudioSource circlesAudio_f;

    // ParticleSystem circleSVFX;
    // ParticleSystem circleFVFX;

    int curIndex = 0;
    public DotsAndCirclesList dotsList;

    void Awake()
    {
        sphereCollider = gameObject.GetComponent<SphereCollider>();
        cameraRay = GameObject.Find("CameraRay").GetComponent<CameraRay>();

        bgAudio = GameObject.Find("audiobg").GetComponent<AudioSource>();
        dotsAudio = GameObject.Find("Dots_individual").GetComponent<AudioSource>();
        circlesAudio_s1 = GameObject.Find("Circle_1").GetComponent<AudioSource>();
        circlesAudio_s2 = GameObject.Find("Circle_2").GetComponent<AudioSource>();
        circlesAudio_s3 = GameObject.Find("Circle_3").GetComponent<AudioSource>();
        circlesAudio_s4 = GameObject.Find("Circle_4").GetComponent<AudioSource>();
        circlesAudio_f = GameObject.Find("Circle_F_individual").GetComponent<AudioSource>();

        //dotsList = GameObject.Find("DotsAndCircles").GetComponent<DotsAndCirclesList>();

        // circleSVFX = GameObject.Find("ImportantDot_Good_VFX").GetComponent<ParticleSystem>();
        // circleFVFX = GameObject.Find("ImportantDot_Bad_VFX").GetComponent<ParticleSystem>();
    }

    void Start()
    {
        bgAudio.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Dots" || other.tag == "Circles")
        {
            dotsList.HideAndShowDots(curIndex);

            if(curIndex<20){curIndex++;}
            
            

            if (other.tag == "Dots")
            {   
                Animator animator = other.transform.parent.GetComponent<Animator>();
                if (cameraRay.eyeFollowed)
                {
                    dotsAudio.Play();
                    animator.SetTrigger("Good");
                }
                else{
                    animator.SetTrigger("Bad");
                }
            }

            if (other.name == "Circle1")
            {
                Animator c1animator = other.transform.parent.GetComponent<Animator>();
                if (cameraRay.eyeFollowed)
                {
                    circlesAudio_s1.Play();
                    c1animator.SetTrigger("Good");
                }
                else
                {
                    circlesAudio_f.Play();
                    c1animator.SetTrigger("Bad");
                }
            }

            if (other.name == "Circle2")
            {
                Animator c2animator = other.transform.parent.GetComponent<Animator>();
                if (cameraRay.eyeFollowed)
                {
                    circlesAudio_s2.Play();
                    c2animator.SetTrigger("Good");
                }
                else
                {
                    circlesAudio_f.Play();
                    c2animator.SetTrigger("Bad");
                }
            }

            if (other.name == "Circle3")
            {
                Animator c3animator = other.transform.parent.GetComponent<Animator>();
                if (cameraRay.eyeFollowed)
                {
                    circlesAudio_s3.Play();
                    c3animator.SetTrigger("Good");
                }
                else
                {
                    circlesAudio_f.Play();
                    c3animator.SetTrigger("Bad");
                }
            }

            if (other.name == "Circle4")
            {
                Animator c4animator = other.transform.parent.GetComponent<Animator>();
                if (cameraRay.eyeFollowed)
                {
                    circlesAudio_s4.Play();
                    c4animator.SetTrigger("Good");
                }
                else
                {
                    circlesAudio_f.Play();
                    c4animator.SetTrigger("Bad");
                }
            }
        }

    }
}
