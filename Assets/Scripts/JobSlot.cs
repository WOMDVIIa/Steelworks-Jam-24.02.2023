using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobSlot : MonoBehaviour
{
    public GameObject employer;

    private void OnMouseOver()
    {
        if (employer != null)
        {
            employer.GetComponent<PersonStats>().OnMouseOver();
        }
    }

    private void OnMouseExit()
    {
        if (employer != null)
        {
            employer.GetComponent<PersonStats>().OnMouseExit();
        }
    }
}
