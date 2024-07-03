using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableList : MonoBehaviour
{
    public List<GameObject> objectsToEnable;
    public string HandTag = "HandTag";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(HandTag))
        {
            foreach (GameObject obj in objectsToEnable)
            {
                obj.SetActive(true);
            }
        }
    }
}

//This Script is made by Glitched Cat Studios!
//You may distribute this script but LEAVE THIS WATERMARK IN THE SCRIPT!!!
//Thanks, The Glitched Cat Studios Team.