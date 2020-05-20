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
        selectionUI.SetActive(false);
    }

    public void PlacePet(GameObject prefab)
    {
        GameObject obj = Instantiate(prefab, placement_Indicator.position, Quaternion.identity);
        pets.Add(obj);
       
        //select the object

    }

    // Update is called once per frame
    void Update()
    {

    }
}
