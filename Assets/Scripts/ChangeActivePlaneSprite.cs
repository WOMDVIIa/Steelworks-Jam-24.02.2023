using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeActivePlaneSprite : MonoBehaviour
{
    [SerializeField] Sprite[] activePlanesSprites;

    Image thisImage;

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
        if (index < 2)
        {
            thisImage.sprite = activePlanesSprites[0];
        }
        else
        {
            thisImage.sprite = activePlanesSprites[1];
        }
    }
}
