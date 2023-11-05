using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ToogleActivationOnSceneChange : MonoBehaviour
{
    public Toggle toggleToActivate;    // Für GameManager zum Auswählen von dem Toogle 
    

    
    public void OnSceneLoaded()     
    {
        toggleToActivate.isOn = true; // Aktiviert den Toggle.
    }
}

