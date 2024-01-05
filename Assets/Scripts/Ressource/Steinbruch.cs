using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steinbruch : MonoBehaviour
{
    [SerializeField]
    private IntSO StoneBuildingsSO; // Wie viele Steinbrüche platziert wurden

    public int cost;
    
    void Update()
    {
        if (StoneBuildingsSO.Value > 0)
        {
            cost = 500 * (1 + StoneBuildingsSO.Value);
        }
        else
        {
            cost = 500;
        }
    }
}
