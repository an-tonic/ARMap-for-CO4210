using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class SwitchUI : MonoBehaviour
{
    public GameObject mapImage; // Reference to the UI Image GameObject displaying the map
    public GameObject arSession; // Reference to the GameObject containing the ARSession and ARTrackedImageManager

    private bool mapVisible = true;

    public void ToggleMapCamera()
    {

        mapVisible = !mapVisible;
        mapImage.SetActive(mapVisible);
        arSession.SetActive(!mapVisible);
    }
}
