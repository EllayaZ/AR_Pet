using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    private Placement_Indicator placement_Indicator;


    // Get Placement Indicator component
    void Start()
    {
        placement_Indicator = FindObjectOfType<Placement_Indicator>();
    }

    // Touch Input
    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            GameObject obj = Instantiate(objectToSpawn, placement_Indicator.transform.position, placement_Indicator.transform.rotation);


        }
    }
}
