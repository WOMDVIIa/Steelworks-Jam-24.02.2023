using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TogglePlaneMenu : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject planeMenuObject;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (planeMenuObject.activeSelf)
        {
            planeMenuObject.SetActive(false);
            //GameManager.instance.planeMenuOn = false;
        }
        else
        {
            planeMenuObject.SetActive(true);
            planeMenuObject.GetComponent<ShowRightPlanes>().ShowPlanes();
            //GameManager.instance
            //GameManager.instance. planeMenuOn = true;
        }
    }
}
