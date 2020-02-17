using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeSetter : MonoBehaviour
{
    // Start is called before the first frame update
    public string objectName;
    public int objectID;
    void Start()
    {
        PlayerPrefs.SetInt("spawned" + objectName, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetObjectName()
    {
        PlayerPrefs.SetString("objectName", objectName);
        PlayerPrefs.SetInt("objectID", objectID);
    }
}
