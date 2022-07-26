using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotsAndCirclesList : MonoBehaviour
{
    public List<GameObject> dotsList = new List<GameObject> ();
    //int index = 0;
    
    void Start()
    {
        dotsList[0].SetActive(true);
    }

    public void HideAndShowDots(int curIndex)
    {
        Destroy(dotsList[curIndex], 2f);
        if(curIndex<20){
            dotsList[curIndex+1].SetActive(true);
        }
    }
}
