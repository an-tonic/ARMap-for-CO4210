using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class SwitchUI : MonoBehaviour
{
    public GameObject mapContainer; 
    public GameObject arSession;
    public GameObject panelWithButtons;
    public RectTransform mapsContentRectTransform;
    public float zoomSpeed = 5f;
    public float minZoom = 10f;
    public float maxZoom = 20f;

    private bool mapVisible = true;

    public void ToggleMapCamera()
    {

        mapVisible = !mapVisible;
        mapContainer.SetActive(mapVisible);
        arSession.SetActive(!mapVisible);
        panelWithButtons.SetActive(mapVisible);
    }

    public void ZoomIn()
    {
        float newScale = Mathf.Clamp(mapsContentRectTransform.localScale.x + zoomSpeed, minZoom, maxZoom);

        // Apply the new scale
        mapsContentRectTransform.localScale = new Vector3(newScale, newScale, 1f);

    }
    public void ZoomOut()
    {
        float newScale = Mathf.Clamp(mapsContentRectTransform.localScale.x - zoomSpeed, minZoom, maxZoom);

        // Apply the new scale
        mapsContentRectTransform.localScale = new Vector3(newScale, newScale, 1f);
    }

    public void SetFloorDown()
    {
        int childCount = mapsContentRectTransform.childCount;

        // Loop through all child transforms of the GameObject in reverse order
        for (int i = 0; i < childCount-1; i++)
        {
            
            Transform child = mapsContentRectTransform.GetChild(i);
            if (child != null && child.gameObject.activeSelf)
            {
                Transform nextChild = mapsContentRectTransform.GetChild(i + 1);
                child.gameObject.SetActive(false);
                nextChild.gameObject.SetActive(true);
                return;
            }
        }
    }
    public void SetFloorUp()
    {
    

        // Get the number of children
        int childCount = mapsContentRectTransform.childCount;

        // Loop through all child transforms of the GameObject in reverse order
        for (int i = childCount - 1; i >= 1; i--)
        {
            Transform child = mapsContentRectTransform.GetChild(i);
            if (child != null && child.gameObject.activeSelf)
            {
                Transform nextChild = mapsContentRectTransform.GetChild(i - 1);
                child.gameObject.SetActive(false);
                nextChild.gameObject.SetActive(true);
                return;
            }
        }
    }



}
