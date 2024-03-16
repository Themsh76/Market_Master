using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credit : MonoBehaviour
{
    public GameObject escape;
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            escape.SetActive(false);
        }
    }
}
