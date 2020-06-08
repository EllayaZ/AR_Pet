using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class Scene_Behavior : MonoBehaviour
{
    [SerializeField] private GameObject objectToPlace = null;
    [SerializeField] private Texture defaultTexture = null;
    private ARRaycastManager rayManager;
    private GameObject visual;
    private bool isObjectPlaced = false;

    private void Awake()
    {
        // Getting the ARRaycastManager and Place Indicator sprite (as child):
        rayManager = FindObjectOfType<ARRaycastManager>();
        visual = transform.GetChild(0).gameObject;

        // Hiding the Placement Indicator before start.
        visual.SetActive(false);

    }

    private void Update()
    {
        if (!isObjectPlaced)
        {
            Place_Indicator();
        }
        
        if (visual.activeSelf)
        {
            EnableTouchScreen();
        }
    }

    private void Place_Indicator()
    {
        // Raycasting from the center of the screen to the nearest plane:
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        rayManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

        // If the raycast hits a plane, activate the Placement Indicator:
        if (hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;

            if (!visual.activeInHierarchy)
            {
                visual.SetActive(true);
            }  
        }
    }

    /// <summary>
    /// If the screen is touched, place the object in the
    /// Placement Indicator's position.
    /// </summary>
    private void EnableTouchScreen()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            objectToPlace.SetActive(true);
            objectToPlace.transform.position = visual.transform.position;

            visual.SetActive(false);
            isObjectPlaced = true;
        }
    }

    /// <summary>
    /// Receives a float number from a UI interactive button
    /// in order to rotate the object placed.
    /// </summary>
    public void Rotate(float degrees)
    {
        if (objectToPlace.activeSelf)
        {
            objectToPlace.transform.eulerAngles += Vector3.up * degrees;
        }
    }

    /// <summary>
    /// Receives a float number from a UI interactice button
    /// to scale the object placed.
    /// </summary>
    public void Scale(float scaleRate)
    {
        if (objectToPlace.activeSelf)
        {
            objectToPlace.transform.localScale += Vector3.one * scaleRate;
        }
    }

    /// <summary>
    /// Changes the material of the object applying the new
    /// received texture.
    /// </summary>
    public void SetColor(Texture newTexture)
    {
        objectToPlace.GetComponentInChildren<Renderer>().material.mainTexture = newTexture;
    }

    /// If the object is deleted, it gets into its default values
    /// and gets disabled. Place Indicator Method restart in order
    /// to place the object again in a different position.
    /// </summary>
    public void DeleteObject()
    {
        objectToPlace.transform.rotation = new Quaternion(0.0f, 180.0f, 0.0f, 0.0f);
        objectToPlace.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        SetColor(defaultTexture);
        objectToPlace.SetActive(false);
        isObjectPlaced = false;
    }
}