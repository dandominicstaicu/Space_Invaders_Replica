using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDetection : MonoBehaviour
{
    void Update()
    {
        //If there are no child (which are the cubes) then change the scene
        if (transform.childCount < 1)
        {
            Application.LoadLevel("WinScene");
        }
    }
}
