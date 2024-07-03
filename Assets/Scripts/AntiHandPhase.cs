using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiHandPhase : MonoBehaviour
{
    public Transform sphere;
    public Transform controller;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sphere.rotation = controller.rotation;
    }
}
