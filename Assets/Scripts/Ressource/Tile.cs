using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool isOccupied; // Variable um  zu checken, ob ein Feld schon ein Haus hat

    public Color greenColor;    // Variable für Farben
    public Color redColor;      // Variable für Farben

    private SpriteRenderer rend;    // Variable, die Felder verändern kann


    private void Start()    //Holt sich den Renderer
    {
        rend = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(isOccupied == true)  // Schaut ob Feld schon besetzt ist
        {
            rend.color = redColor;  // Setzt die Color des Feldes auf Rot wenn schon ein Haus darauf ist
        }
        else
        {
            rend.color = greenColor;    // Wenn das Feld nicht besetzt ist, dann setzt er die Farbe auf grün
        }
        
    }
}
