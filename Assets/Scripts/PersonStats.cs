using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PersonStats : MonoBehaviour
{
    [SerializeField] protected GameObject statsDisplay;
    [SerializeField] protected TextMeshProUGUI[] statsText;

    protected float[] skillSet;

    protected void OnMouseOver()
    {
        if (!GameManager.instance.planeMenuOn)
        {
            DisplayStats(skillSet);
        }
    }

    protected void OnMouseExit()
    {
        HideStats();
    }

    protected void DisplayStats(float[] skills)
    {
        statsDisplay.SetActive(true);
        statsText[0].text = "Writing: " + System.Math.Round(skills[0], 1);
        statsText[1].text = "Drawing: " + System.Math.Round(skills[1], 1);
        statsText[2].text = "Maths: " + System.Math.Round(skills[2], 1);
    }

    protected void HideStats()
    {
        statsDisplay.SetActive(false);
    }
}
