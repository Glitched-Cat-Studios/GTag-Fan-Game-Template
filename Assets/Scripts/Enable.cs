using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enable : MonoBehaviour
{
    public GameObject objectToEnable;
    public string HandTag = "HandTag";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(HandTag))
        {
            objectToEnable.SetActive(true);
        }
    }


}