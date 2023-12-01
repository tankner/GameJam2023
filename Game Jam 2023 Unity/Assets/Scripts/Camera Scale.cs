using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScaler : MonoBehaviour
{
    public float baseOrthographicSize = 5.0f;  // Adjust this based on your design preference

    void Start()
    {
        ResizeCamera();
    }

    void ResizeCamera()
    {
        Camera mainCamera = Camera.main;

        float screenRatio = (float)Screen.width / Screen.height;
        float targetRatio = 1920f / 1080f;  // Adjust this based on your design preference
        float scaleFactor = screenRatio / targetRatio;

        mainCamera.orthographicSize = baseOrthographicSize * scaleFactor;
    }
}

