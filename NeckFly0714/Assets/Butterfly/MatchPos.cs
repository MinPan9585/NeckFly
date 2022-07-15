using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchPos : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Joint;
    public Vector3 Offset;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Joint.transform.position + Offset;

    }
}
