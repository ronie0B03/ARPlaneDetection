using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
using UnityEngine.EventSystems;
[RequireComponent(typeof(ARRaycastManager))]
public class ARTapToPlace : MonoBehaviour
{
    public GameObject gameObjectToInstantiate;

    public GameObject[] spawnedObject;
    private ARRaycastManager _arRaycastManager;
    private Vector2 touchPosition;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    //2020-02-15
    private string objectName;
    private int objectID;

    public Text uiText;
    private void Awake()
    {
        _arRaycastManager = GetComponent<ARRaycastManager>();
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount>0) {
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                Debug.Log("UI is touched");
                //so when the user touched the UI(buttons) call your UI methods
                uiText.text = "UI is touched";
            }
            else
            {
                Debug.Log("Main Screen");
                uiText.text = "Main Screen";

                touchPosition = Input.GetTouch(0).position;
                return true;
            }
            
        }
        touchPosition = default;
        return false;
    }
    // Update is called once per frame
    void Update()
    {
        objectName = PlayerPrefs.GetString("objectName");
        objectID = PlayerPrefs.GetInt("objectID");
        
        //Debug.Log("OBJ NAME: "+ objectName);
        //Debug.Log("OBJ ID: " + objectID);
        Debug.Log(PlayerPrefs.GetInt("spawned" + objectName));
        
        if (!TryGetTouchPosition(out Vector2 touchPosition))
        {
            return;
        }
        if(_arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;

            if (PlayerPrefs.GetInt("spawned"+objectName)==0) 
            {
                PlayerPrefs.SetInt("spawned"+objectName,1);
                spawnedObject[objectID] = Instantiate(Resources.Load("dayBedSet/" + objectName, typeof(GameObject)), hitPose.position, hitPose.rotation) as GameObject;
            }
            else
            {
                spawnedObject[objectID].transform.position = hitPose.position;
            }

            if (!spawnedObject[objectID])
            {
                
            }
            else
            {
                
            }

        }
    }
}
