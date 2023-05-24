using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardPreview : MonoBehaviour
{

    public static CardPreview Instance;

    public CardDisplay frontPreview;
    public CardDisplay backPreview;

    public RectTransform rect;
    // Start is called before the first frame update
    void Start()
    {
        if (!Instance) Instance = this;
        else if (Instance != this) Destroy(gameObject);

        gameObject.SetActive(false);

        rect = GetComponent<RectTransform>();
    }

    public void DisplayCard(CardBehaviour card)
    {
        gameObject.SetActive(true);

        if (Input.mousePosition.x < Screen.width / 2.0f)
        {
            //mouse left
            rect.anchorMin = new Vector2(1, 0);
            rect.anchorMax = new Vector2(1, 1);
            rect.anchoredPosition = new Vector2(-524f, 0);
        }
        else
        {
            //mouse right
            rect.anchorMin = new Vector2(0, 0);
            rect.anchorMax = new Vector2(0, 1);
            rect.anchoredPosition = new Vector2(0f, 0);
        }

        foreach (Transform obj in frontPreview.abilityDescriptions)
        {
            Destroy(obj.gameObject);
        }

        if (card.frontSide.art)
        {
            frontPreview.UpdateDisplay(card.frontSide);
        }

        if (card.backSide.art)
        {
            backPreview.gameObject.SetActive(true);
            backPreview.UpdateDisplay(card.backSide);
        }

        LayoutRebuilder.ForceRebuildLayoutImmediate(frontPreview.abilityTransform);
        LayoutRebuilder.ForceRebuildLayoutImmediate(frontPreview.abilityTransform.parent.GetComponent<RectTransform>());
        LayoutRebuilder.ForceRebuildLayoutImmediate(frontPreview.productionTransform);

        LayoutRebuilder.ForceRebuildLayoutImmediate(backPreview.abilityTransform);
        LayoutRebuilder.ForceRebuildLayoutImmediate(backPreview.abilityTransform.parent.GetComponent<RectTransform>());
        LayoutRebuilder.ForceRebuildLayoutImmediate(backPreview.productionTransform);

        LayoutRebuilder.ForceRebuildLayoutImmediate(frontPreview.abilityDescriptions.GetComponent<RectTransform>());
    }

    public void EndPreview()
    {
        gameObject.SetActive(false);
        backPreview.gameObject.SetActive(false);
    }
}
