using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    
    void Update()
    {
        Vector2 mousposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);     //Gibt die 2 Dimensionale Mausposition
        transform.position = mousposition;      //Transformiert die Position in Werte
    }
}
