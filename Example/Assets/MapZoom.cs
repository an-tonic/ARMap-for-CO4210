using UnityEngine;

using UnityEngine.UI;

public class MapZoom : MonoBehaviour
{
    private bool _isDragging;
    private float _currentScale;
    public float minScale, maxScale;
    private float _temp;
    private float _scalingRate = 2;

    private void Start()
    {
        Debug.Log("sm");
        _currentScale = transform.localScale.x;
    }

    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    Debug.Log("Touch supported" + Input.touchSupported);
    //    Debug.Log("Touch num" + Input.touchCount);
    //    if (Input.touchCount == 1)
    //    {
    //        Debug.Log("sm2");
    //        _isDragging = true;

    //    }
    //}


    //public void OnPointerUp(PointerEventData eventData)
    //{
    //    Debug.Log("sm3");
    //    _isDragging = false;
    //}


    private void Update()
    {
        if(Input.touchCount > 0)
        {
            Debug.Log(Input.touchCount);
        }
        
        if (_isDragging)
        {
            if (Input.touchCount == 2)
            {
                transform.localScale = new Vector2(_currentScale, _currentScale);
                float distance = Vector3.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);
                if (_temp > distance)
                {
                    if (_currentScale < minScale)
                        return;
                    _currentScale -= (Time.deltaTime) * _scalingRate;
                }

                else if (_temp < distance)
                {
                    if (_currentScale >= maxScale)
                        return;
                    _currentScale += (Time.deltaTime) * _scalingRate;
                }

                _temp = distance;
            }


        }

    }

}