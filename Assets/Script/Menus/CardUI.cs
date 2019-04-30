using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    public void GetCardSprite(Sprite cardSprite)
    {
        if (cardSprite)
            gameObject.GetComponent<RawImage>().texture = cardSprite.texture;
    }

    public void GetBuffSprite(Sprite buffIcon)
    {
        if (buffIcon)
            gameObject.GetComponent<RawImage>().texture = buffIcon.texture;
    }

}
