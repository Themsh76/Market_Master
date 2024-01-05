using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
    [SerializeField]
    private IntSO WoodBuildingsSO; // Wie viele Gebäude platziert wurden

    public int cost;
    void Update()
    {
        if (WoodBuildingsSO.Value > 0)
        {
            cost = 25 * (1 + WoodBuildingsSO.Value);
        }
        else
        {
            cost = 25;
        }

    }
}
