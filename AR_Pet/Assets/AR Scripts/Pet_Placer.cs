using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Pet_Placer : MonoBehaviour
{
    public Transform placement_Indicator;
    public GameObject selectionUI;

    private List<GameObject> pets = new List<GameObject>();
    private GameObject curSelected;
    private Camera cam;


    // Access main camera
    void Start()
    {
        cam = Camera.main;
        //selectionUI.SetActive(false);
    }

    // 
    void Update()
    {
        //check if we touching UI element or if we not touching we continue with "If" statment
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began && !EventSystem.current.IsPointerOverGameObject(Input.touches[0].fingerId))
        {
            //whereever we touch on teh screen
            Ray ray = cam.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {

                if (hit.collider.gameObject != null && pets.Contains(hit.collider.gameObject))
                {
                    //if we touching the same object or a different one
                    if (curSelected != null && hit.collider.gameObject != curSelected)
                        Select(hit.collider.gameObject);
                    else if (curSelected == null)
                        Select(hit.collider.gameObject);

                }
            }
            else
                Deselect();
        }

    }

    void Select(GameObject selected)
    {
        if (curSelected != null)
            ToggleSelectionVisual(curSelected, false);

        curSelected = selected;
        ToggleSelectionVisual(curSelected, true);
        selectionUI.SetActive(true);

    }

    void Deselect()
    {
        if (curSelected != null)
            ToggleSelectionVisual(curSelected, false);

        curSelected = null;
        //selectionUI.SetActive(false);
    }

    void ToggleSelectionVisual(GameObject obj, bool toggle)
    {
        obj.transform.Find("Selected").gameObject.SetActive(toggle);

    }

    public void PlacePet(GameObject prefab)
    {
        GameObject obj = Instantiate(prefab, placement_Indicator.position, Quaternion.identity);
        pets.Add(obj);

        Select(obj);

    }

  
}
