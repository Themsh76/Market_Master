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

    public int gold;    // Variable für den Goldwert
    public Text goldDisplay;    // Variable für die Anzeige des Goldwerts

    public int holz;    // Variable für den Holzwert
    public Text holzDisplay;    //Variable für die Anzeige des Holzwerts

    private Building buildingToPlace;   // Variable für das Gebäude was plaziert werden soll
    public GameObject Grid;     // Object welches das Feld widerspiegelt
    public CustomCursor customCursor;   // Leitet eine Instanz von Customcursor ab

    public Tile[] tiles;    // Array von Feldern

    public int zähler;      // Variable die ms zählt
    public int holzProSekunde = 1;     // Erwirtschafte Hölzer pro Sekunde
    public int numberOfBuildings;       // Wie viele Gebäude platziert wurden



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

        PlayerPrefs.SetInt("holzwert", holz);   // Speichert den Holzwert global und für immer
        PlayerPrefs.SetInt("goldwert", gold);   // Speichert den Goldwert global und für immer



        if (Input.GetMouseButtonDown(0) && buildingToPlace != null)     //Schaut ob die linke Maustaste gedrückt ist und ob ein Haus gerade platziert werden soll
        {
            Tile nearestTile = null;    // Variable die angibt welches Feld am nächsten ist
            float shortestDistance = float.MaxValue;    // Variable, welche schaut welches Feld am nächsten ist

            foreach (Tile tile in tiles)    // Schleife die schaut welches Feld am nächsten ist
            {
                float distance = Vector2.Distance(tile.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition)); // Schaut wo die Maus ist und welche Tile wo ist
                if (distance < shortestDistance && distance < 50)    // Schaut ob das nächste Feld in der Schleife näher ist als das zuvor
                {
                    shortestDistance = distance;    // Setzt die Distanz zum jetzigen Feld als kürzeste Distanz
                    nearestTile = tile;     // Setzt die nahste Feld als nahstes Feld
                }
            }

            



            if (shortestDistance < 50)    // Schaut, ob das nahste Feld beim Klick nicht befüllt ist
            {

                if (nearestTile.isOccupied == false)
                {
                    Instantiate(buildingToPlace, nearestTile.transform.position, Quaternion.identity);  // Setzt das Building ohne Drehung in das Feld
                    buildingToPlace = null;     // Entfernt das Building am Cursor 
                    nearestTile.isOccupied = true;      // Setzt das Feld auf dem das Building plaziert auf befüllt
                    Grid.SetActive(false);      // Deaktiviert das Grid
                    customCursor.gameObject.SetActive(false);   // Deaktiviert den Custom Cursor
                    Cursor.visible = true;  // Aktiviert den normalen Cursor 
                    numberOfBuildings++; 
                }               
            }  
        }
        

        if (numberOfBuildings > 0)      // Schaut ob schon etwas platziert wurde
        {
            if(zähler == 1000)      // Wenn eine Sekunde vergangen ist geht es in die Methode
            {
                holz += holzProSekunde*numberOfBuildings;     // Erhöt den Holzwert
                zähler = 0;     // Setzt den Zähler auf 0
            }
            zähler++;  
        }
    }





    public void BuyBuilding(Building building)  // Funktion, die das platzieren eines Gebäudes möglich macht
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
