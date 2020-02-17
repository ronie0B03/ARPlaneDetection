using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToPlace : MonoBehaviour
{
    public GameObject[] spawnedObject;
    private Vector2 touchPosition;
    //2020-02-15
    private string objectName;
    private int objectID;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            Debug.Log("touched");
            return true;
        }
        touchPosition = default;
        return false;
    }
    // Update is called once per frame
    void Update()
    {
        objectName = PlayerPrefs.GetString("objectName");
        objectID = PlayerPrefs.GetInt("objectID");

        Vector2 touchPosition;
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            Debug.Log("touched");
            spawnedObject[objectID] = Instantiate(Resources.Load("dayBedSet/" + objectName, typeof(GameObject))) as GameObject;


        }
        if (Input.GetMouseButtonDown(0)) 
        {
            if (spawnedObject[objectID])
            {
                spawnedObject[objectID] = Instantiate(Resources.Load("dayBedSet/" + objectName, typeof(GameObject))) as GameObject;
            }
            else
            {
                spawnedObject[objectID].transform.position = (new Vector3(0f, 0f, 0f));
            }
            
        }

    }
}
