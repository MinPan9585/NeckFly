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

    ParticleSystem circleSVFX;
    ParticleSystem circleFVFX;

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

        circleSVFX = GameObject.Find("ImportantDot_Good_VFX").GetComponent<ParticleSystem>();
        circleFVFX = GameObject.Find("ImportantDot_Bad_VFX").GetComponent<ParticleSystem>();
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
                if (cameraRay.eyeFollowed)
                {
                    dotsAudio.Play();
                }
            }

            if (other.name == "Circle1")
            {
                if (cameraRay.eyeFollowed)
                {
                    circlesAudio_s1.Play();
                    circleSVFX.Play();
                }
                else
                {
                    circlesAudio_f.Play();
                    circleFVFX.Play();
                }
            }

            if (other.name == "Circle2")
            {
                if (cameraRay.eyeFollowed)
                {
                    circlesAudio_s2.Play();
                    circleSVFX.Play();
                }
                else
                {
                    circlesAudio_f.Play();
                    circleFVFX.Play();
                }
            }

            if (other.name == "Circle3")
            {
                if (cameraRay.eyeFollowed)
                {
                    circlesAudio_s3.Play();
                    circleSVFX.Play();
                }
                else
                {
                    circlesAudio_f.Play();
                    circleFVFX.Play();
                }
            }

            if (other.name == "Circle4")
            {
                if (cameraRay.eyeFollowed)
                {
                    circlesAudio_s4.Play();
                    circleSVFX.Play();
                }
                else
                {
                    circlesAudio_f.Play();
                    circleFVFX.Play();
                }
            }
        }

    }
}
