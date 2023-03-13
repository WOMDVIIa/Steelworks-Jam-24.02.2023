using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeActivePlaneSprite : MonoBehaviour
{
    [SerializeField] Sprite[] activePlanesSprites;
    [SerializeField] GameObject orderIcon;

    Image thisImage;
    Color fireColor = new Color(0.8f, 0.35f, 0.35f);

    // Start is called before the first frame update
    void Start()
    {
        thisImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSprite(int index)
    {
        if (index == 0)
        {
            thisImage.color = fireColor;
        }
        else
        {
            thisImage.color = Color.white;
        }

        orderIcon.SetActive(true);
        if (index < 5)
        {
            thisImage.sprite = activePlanesSprites[index];
            orderIcon.SetActive(false);
        }
        else if (index < 10) // <5;9>
        {
            thisImage.sprite = activePlanesSprites[1];
        }
        else if (index < 15) // <10;14>
        {
            thisImage.sprite = activePlanesSprites[2];
        }
        else // <15;19>
        {
            thisImage.sprite = activePlanesSprites[3];
        }
    }
}
