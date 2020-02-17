using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject mainSelection, daybedSelection, diningSelection, gardenSelection, livingSelection;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("objectID",-1);
        mainSelection.SetActive(true);
        daybedSelection.SetActive(false);
        diningSelection.SetActive(false);
        gardenSelection.SetActive(false);
        livingSelection.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HideAll() {
        mainSelection.SetActive(false);
        daybedSelection.SetActive(false);
        diningSelection.SetActive(false); 
        gardenSelection.SetActive(false);
        livingSelection.SetActive(false);
    }

    public void Selection()
    {
        HideAll();
        mainSelection.SetActive(true);
    }

    public void Dining()
    {
        HideAll();
        diningSelection.SetActive(true);
    }
    public void Garden()
    {
        HideAll();
        gardenSelection.SetActive(true);
    }
    public void DayBed()
    {
        HideAll();
        daybedSelection.SetActive(true);
    }
    public void Living()
    {
        HideAll();
        livingSelection.SetActive(true);
    }
}
