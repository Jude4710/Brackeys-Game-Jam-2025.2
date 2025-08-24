using NUnit.Framework.Constraints;
using System;
using Unity.VisualScripting;
using UnityEngine;

public class controllerScript : MonoBehaviour
{
    [SerializeField]
    GameObject nextObject;

    Camera cam = Camera.main;
    float camWidth;
    float camHeight;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camWidth = 2 * cam.orthographicSize;
        camHeight = camWidth * cam.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;

            if (withinBounds(mousePos)){
                Vector3 normalisedMousePos;
                normalisedMousePos.x = mousePos.x/Screen.width;
                normalisedMousePos.y = mousePos.y/Screen.height;
                normalisedMousePos.z = 0;

                Instantiate(nextObject, new Vector3(normalisedMousePos.x * camHeight - camHeight/2, normalisedMousePos.y * camWidth - camWidth/2, 0), Quaternion.identity);
            }
        }
    }

    Boolean withinBounds(Vector3 postion)
    {
        if (postion.x < Screen.width || postion.x > 0 || postion.y < Screen.height || postion.y > 0)
        {
            return true;
        }
        return false;
    }
}
