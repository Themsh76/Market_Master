using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Wichtig sonst geht UI nicht
using TMPro;

public class Money : MonoBehaviour
{
    private int money = 5;
    public Text moneyText;

    
    void Start()    // Start is called before the first frame update
    {

    }

    void Update()   // Update is called once per frame
    {
        moneyText.text = "Money: " + money;

        if (Input.GetKeyUp(KeyCode.Space))
        {
            money++;
        }
    }
}
