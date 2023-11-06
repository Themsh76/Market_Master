using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startwerte : MonoBehaviour
{
    private int holz = 50;
    private int gold = 50;

    public Startwerte startwert;

    public void Startwertefestlegen()
    {
        PlayerPrefs.SetInt("holzwert", holz);   // Speichert den Holzwert global und für immer
        PlayerPrefs.SetInt("goldwert", gold);   // Speichert den Goldwert global und für immer
        PlayerPrefs.SetInt("numberBuildings", 0);
        PlayerPrefs.SetString("build", "");
    }
}
