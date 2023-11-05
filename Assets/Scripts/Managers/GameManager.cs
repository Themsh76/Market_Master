using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int gold;    // Variable f�r den Goldwert
    public Text goldDisplay;    // Variable f�r die Anzeige des Goldwerts

    public int holz;    // Variable f�r den Holzwert
    public Text holzDisplay;    //Variable f�r die Anzeige des Holzwerts

    private Building buildingToPlace;   // Variable f�r das Geb�ude was plaziert werden soll
    public GameObject Grid;     // Object welches das Feld widerspiegelt
    public CustomCursor customCursor;   // Leitet eine Instanz von Customcursor ab

    public Tile[] tiles;    // Array von Feldern

    public int z�hler;      // Variable die ms z�hlt
    public int holzProSekunde = 1;     // Erwirtschafte H�lzer pro Sekunde
    public int numberOfBuildings;       // Wie viele Geb�ude platziert wurden



    private void Start()
    {    
        
        holz = PlayerPrefs.GetInt("holzwert");  // Holt sich den globalen Holzwert 
        gold = PlayerPrefs.GetInt("goldwert");  // Holt sich den globalen Goldwert 


        numberOfBuildings = 0;      // Nummer auf 0 setzen
    }





    private void Update()   
    {
        goldDisplay.text = gold.ToString(); //Updated die Anzeige jede ms 
        holzDisplay.text = holz.ToString(); //Updated die Anzeige jede ms 

        PlayerPrefs.SetInt("holzwert", holz);   // Speichert den Holzwert global und f�r immer
        PlayerPrefs.SetInt("goldwert", gold);   // Speichert den Goldwert global und f�r immer



        if (Input.GetMouseButtonDown(0) && buildingToPlace != null)     //Schaut ob die linke Maustaste gedr�ckt ist und ob ein Haus gerade platziert werden soll
        {
            Tile nearestTile = null;    // Variable die angibt welches Feld am n�chsten ist
            float shortestDistance = float.MaxValue;    // Variable, welche schaut welches Feld am n�chsten ist

            foreach (Tile tile in tiles)    // Schleife die schaut welches Feld am n�chsten ist
            {
                float distance = Vector2.Distance(tile.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition)); // Schaut wo die Maus ist und welche Tile wo ist
                if (distance < shortestDistance && distance < 50)    // Schaut ob das n�chste Feld in der Schleife n�her ist als das zuvor
                {
                    shortestDistance = distance;    // Setzt die Distanz zum jetzigen Feld als k�rzeste Distanz
                    nearestTile = tile;     // Setzt die nahste Feld als nahstes Feld
                }
            }

            



            if (shortestDistance < 50)    // Schaut, ob das nahste Feld beim Klick nicht bef�llt ist
            {

                if (nearestTile.isOccupied == false)
                {
                    Instantiate(buildingToPlace, nearestTile.transform.position, Quaternion.identity);  // Setzt das Building ohne Drehung in das Feld
                    buildingToPlace = null;     // Entfernt das Building am Cursor 
                    nearestTile.isOccupied = true;      // Setzt das Feld auf dem das Building plaziert auf bef�llt
                    Grid.SetActive(false);      // Deaktiviert das Grid
                    customCursor.gameObject.SetActive(false);   // Deaktiviert den Custom Cursor
                    Cursor.visible = true;  // Aktiviert den normalen Cursor 
                    numberOfBuildings++; 
                }               
            }  
        }
        

        if (numberOfBuildings > 0)      // Schaut ob schon etwas platziert wurde
        {
            if(z�hler == 1000)      // Wenn eine Sekunde vergangen ist geht es in die Methode
            {
                holz += holzProSekunde*numberOfBuildings;     // Erh�t den Holzwert
                z�hler = 0;     // Setzt den Z�hler auf 0
            }
            z�hler++;  
        }
    }





    public void BuyBuilding(Building building)  // Funktion, die das platzieren eines Geb�udes m�glich macht
    {

        if (gold >= building.cost)      // Schaut ob man genug Gold hat
        {
            Grid.SetActive(true);       // Aktiviert das Grid
            gold -= building.cost;      // Zieht die Kosten vom Goldwert ab
            buildingToPlace = building;     // Legt fest, dass ein Building plaziert werden soll

            customCursor.gameObject.SetActive(true);  // Aktiviert Customcursor
            customCursor.GetComponent<SpriteRenderer>().sprite = building.GetComponent<SpriteRenderer>().sprite;    // Gibt den Custom Cursor ein Building was mit dem Cursor mitgeht
            Cursor.visible = false; // Deaktiviert den normalen Cursor
         
        }
    }
}
