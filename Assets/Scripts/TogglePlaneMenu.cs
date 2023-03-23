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
            GameManager.instance.HideConditionalPlanse();
            planeMenuObject.SetActive(false);
        }
        else
        {
            planeMenuObject.SetActive(true);
            GameManager.instance.ShowRightPlanesInMenu();
        }
    }
}
