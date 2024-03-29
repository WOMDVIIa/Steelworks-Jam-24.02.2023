using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlaneSelect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] GameObject glow;
    [SerializeField] GameObject select;

    public void OnPointerEnter(PointerEventData eventData)
    {
        glow.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        glow.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ActualSelection();
    }

    public void ActualSelection()
    {
        if (GameManager.instance.playerInside)
        {
            GameManager.instance.DeselectAll();
            GameManager.instance.FillSelectedPlaneIndex(this.gameObject);
            select.SetActive(true);
        }    
    }

    public void Deselect()
    {
        select.SetActive(false);
    }
}
