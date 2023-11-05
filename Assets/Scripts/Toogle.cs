using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ToogleActivationOnSceneChange : MonoBehaviour
{
    public Toggle toggleToActivate;    // F�r GameManager zum Ausw�hlen von dem Toogle 
    

    
    public void OnSceneLoaded()     
    {
        toggleToActivate.isOn = true; // Aktiviert den Toggle.
    }
}

