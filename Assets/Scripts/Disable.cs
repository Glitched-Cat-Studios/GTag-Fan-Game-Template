using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable : MonoBehaviour
{
    public GameObject objectToDisable;
    public string HandTag = "HandTag";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(HandTag))
        {
            objectToDisable.SetActive(false);
        }
    }
}