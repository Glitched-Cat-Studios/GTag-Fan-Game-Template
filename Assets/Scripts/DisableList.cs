using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableList : MonoBehaviour
{
    public List<GameObject> objectsToDisable;
    public string HandTag = "HandTag";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(HandTag))
        {
            foreach (GameObject obj in objectsToDisable)
            {
                obj.SetActive(false);
            }
        }
    }
}

//This Script is made by Glitched Cat Studios!
//You may distribute this script but LEAVE THIS WATERMARK IN THE SCRIPT!!!
//Thanks, The Glitched Cat Studios Team.