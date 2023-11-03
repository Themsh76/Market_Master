using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool isOccupied; // Variable um  zu checken, ob ein Feld schon ein Haus hat

    public Color greenColor;    // Variable f�r Farben
    public Color redColor;      // Variable f�r Farben

    private SpriteRenderer rend;    // Variable, die Felder ver�ndern kann


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
            rend.color = greenColor;    // Wenn das Feld nicht besetzt ist, dann setzt er die Farbe auf gr�n
        }
        
    }
}
