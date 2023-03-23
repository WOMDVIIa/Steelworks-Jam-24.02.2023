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
    Color hireColor = new Color(0.35f, 0.8f, 0.35f);

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
        if (index < activePlanesSprites.Length)
        {
            thisImage.sprite = activePlanesSprites[index];
            orderIcon.SetActive(false);
        }
        else if (index < 20) // <10;14>
        {
            thisImage.sprite = activePlanesSprites[2];
        }
        else if (index < 30) // <20;24>
        {
            thisImage.sprite = activePlanesSprites[3];
        }
        else // <30;34>
        {
            thisImage.sprite = activePlanesSprites[4];
        }
    }

    public void ChaneToHireSprite()
    {
        thisImage.sprite = activePlanesSprites[0];
        thisImage.color = hireColor;
        orderIcon.SetActive(false);
    }
}
