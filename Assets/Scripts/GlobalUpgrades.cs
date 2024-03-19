using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GlobalUpgrades : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI SpeedUpgradeDisplay;   // Variable f�r die Anzeige der SpeedUpgrade Level 
    [SerializeField] TextMeshProUGUI MultiplicatorUpgradeDisplay;   // Variable f�r die Anzeige der MultiplicatorUpgrade Level

    [SerializeField]
    private IntSO GlobalMultiplicatorAmount;  // Scriptable Object f�r den globalen Multiplicator

    [SerializeField]
    private IntSO GlobalSpeedAmount;

    [SerializeField]
    private IntSO StoneMsSO;    // Nach wie vielen MS ein Stein erwirtschaftet wird

    [SerializeField]
    private IntSO WoodMsSO; // Nach wie vielen MS ein Holz erwirtschaftet wird

    [SerializeField]
    private IntSO GoldSO; // Scriptable Object f�r den Goldwert

    void Start()
    {
        MultiplicatorUpgradeDisplay.text = GlobalMultiplicatorAmount.Value.ToString();
      
        SpeedUpgradeDisplay.text = GlobalSpeedAmount.Value.ToString();
    }

    
    void Update()
    {
        
    }

    public void UpgradeSpeed()
    {
        if(StoneMsSO.Value > 1000 && WoodMsSO.Value > 100) 
        {

            GoldSO.Value -= GlobalMultiplicatorAmount.Value * 100;
            WoodMsSO.Value -= 100;      // Noch Anpassungsf�hig
            StoneMsSO.Value -= 1000;    // Noch Anpassungsf�hig

            GlobalSpeedAmount.Value++;
            SpeedUpgradeDisplay.text = GlobalSpeedAmount.Value.ToString(); // Updated die Anzeige jede ms 


        }
 
    } 

    public void MultiplicatorUpgrade() 
    {
        if(GoldSO.Value > 100 * GlobalMultiplicatorAmount.Value)
        {
            GoldSO.Value -= GlobalMultiplicatorAmount.Value * 100;

            GlobalMultiplicatorAmount.Value++;
            MultiplicatorUpgradeDisplay.text = GlobalMultiplicatorAmount.Value.ToString();
        }      

    }

}
