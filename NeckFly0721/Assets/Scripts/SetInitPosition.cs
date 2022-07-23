using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetInitPosition : MonoBehaviour
{
    GameObject rig;
    Vector3 offset = new Vector3 (0, 0, 0.8f);

    void Awake()
    {
        rig = GameObject.Find("NRCameraRig");
        //transform.position = rig.transform.position + offset;
    }

    private void Start() {
        transform.position = rig.transform.position + offset;
    }
}
