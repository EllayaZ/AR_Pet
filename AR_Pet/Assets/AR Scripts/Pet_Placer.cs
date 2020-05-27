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
        if (curSelected != null && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Moved)
            MoveSelected();

    }

    void MoveSelected()
    {
        Vector3 curPos = cam.ScreenToViewportPoint(Input.touches[0].position);
        Vector3 lastPos = cam.ScreenToViewportPoint(Input.touches[0].position - Input.touches[0].deltaPosition);

        Vector3 touchDir = curPos - lastPos;

        //object needs to be moved horizontaly on X, Z axes. Conversion needs to be applied; Camera needs to be adjusted;

        Vector3 camRight = cam.transform.right;
        camRight.y = 0;
        //Normalize function take Vector3 and all inputs anbd normalize it to 1
        camRight.Normalize();

        Vector3 camForward = cam.transform.forward;
        camForward.y = 0;
        camForward.Normalize();

        //moving selected object relatively to the direction we facing the camera
        curSelected.transform.position += (camRight * touchDir.x + camForward * touchDir.y);

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

    public void ScaleSelected(float rate)
    {
        //scale in size selected object
        curSelected.transform.localScale += Vector3.one * rate;
    }

    public void RotateSelected(float rate)
    {
        //rotate selected object
        curSelected.transform.eulerAngles += Vector3.up * rate;
    }

    //MUST CHANGE THE SCRIPT!!!!
    public void SetColor (Texture newTexture)
    {
        curSelected.GetComponentInChildren<Renderer>().material.mainTexture = newTexture;
        /*
        SkinnedMeshRenderer[] meshRenderers = curSelected.GetComponentsInChildren<SkinnedMeshRenderer>();

        foreach (SkinnedMeshRenderer mr in meshRenderers)
        {
            mr.material.color = buttonImage.color;
        }
        */

    }

    public void DeleteSelected()
    {
        pets.Remove(curSelected);
        Destroy(curSelected);
        Deselect();

    }


}
