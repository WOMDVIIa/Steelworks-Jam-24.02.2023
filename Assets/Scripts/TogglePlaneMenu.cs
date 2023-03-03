using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePlaneMenu : MonoBehaviour
{
    [SerializeField] GameObject planeMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Toggle()
    {
        if (planeMenu.activeSelf)
        {
            planeMenu.SetActive(false);
        }
        else
        {
            planeMenu.SetActive(true);
            planeMenu.GetComponent<ShowRightPlanes>().ShowPlanes();
        }
    }
}
