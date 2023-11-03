using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionManager : MonoBehaviour
{


    public int width;   //Variable für die Breite des Screens
    public int height;  //Variable für die Höhe des Screens


    public void SetWidth(int newWidth)  //Setzt welche die Breite das Screens haben soll
    {
        width = newWidth;
    }

    public void Setheight(int newheight)    //Setzt welche die Höhe das Screens haben soll
    {
        height = newheight;
    }

    public void SetRes()
    {
        Screen.SetResolution(width, height, false); //Passt den Screen auf die festgelegten Werte an      
    }

    public void SetFull() //Passt den Screen auf Fullscreen an
    { 
        Screen.SetResolution(1280, 720, true);
        Screen.fullScreen = true;
    }
}

