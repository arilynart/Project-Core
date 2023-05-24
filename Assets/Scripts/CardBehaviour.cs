using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardBehaviour : MonoBehaviour
{
    public CardData frontSide;
    public CardData backSide;


    void OnMouseEnter()
    {
        Debug.Log("EnterTrigger");
        CardPreview.Instance.DisplayCard(this);
    }

    void OnMouseExit()
    {
        Debug.Log("ExitTrigger");
        CardPreview.Instance.EndPreview();
    }
}
