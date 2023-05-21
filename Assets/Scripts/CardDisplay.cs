using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public TextMeshProUGUI titleTxt;
    public TextMeshProUGUI typeTxt;

    public Image frameImg;
    public Image artImg;

    public Image factionImg;
    public Image rarityImg;

    public Image attachCostBg;
    public Image emptyCostBg;

    public TextMeshProUGUI attachCostTxt;
    public TextMeshProUGUI emptyCostTxt;

    public Image attackBg;
    public Image defenseBg;

    public TextMeshProUGUI attackTxt;
    public TextMeshProUGUI defenseTxt;

    public Sprite common;
    public Sprite uncommon;
    public Sprite rare;
    public Sprite mythic;
    public Sprite legendary;
    public Sprite immortal;

    public Sprite paladinIcon;

    public Sprite paladinUnitBg;
    public Sprite paladinSpellBg;

    public List<Image> abilityImages = new List<Image>();
    public RectTransform abilityTransform;

    public RectTransform abilityDescriptions;

    public GameObject abilityTitlePrefab;
    public GameObject abilityTextPrefab;

    public Card defaultCard;
    public CardData displayingCard;

    private void Start()
    {
        foreach (Image abilityImg in abilityImages)
        {
            abilityImg.gameObject.SetActive(false);

        }
        abilityTransform = abilityImages[0].transform.parent.GetComponent<RectTransform>();

        ShowDefaultCard();
    }

    public void ShowDefaultCard()
    {
        if (defaultCard)
        {
            UpdateDisplay(new CardData(defaultCard));
        }
    }

    public void UpdateDisplay(CardData card)
    {
        displayingCard = card;

        titleTxt.text = card.title;
        typeTxt.text = card.typeText;

        switch (card.faction)
        {
            case Card.Faction.PALADINS:
                factionImg.sprite = paladinIcon;

                switch (card.type)
                {
                    case Card.Type.UNIT:
                        frameImg.sprite = paladinUnitBg;
                    break;
                    case Card.Type.SPELL:
                        frameImg.sprite = paladinSpellBg;
                    break;
                }
            break;
        }

        switch (card.rarity)
        {
            case Card.Rarity.COMMON:
                rarityImg.sprite = common;
                break;
            case Card.Rarity.UNCOMMON:
                rarityImg.sprite = uncommon;
                break;
            case Card.Rarity.RARE:
                rarityImg.sprite = rare;
                break;
            case Card.Rarity.MYTHIC:
                rarityImg.sprite = mythic;
                break;
            case Card.Rarity.LEGENDARY:
                rarityImg.sprite = legendary;
                break;
            case Card.Rarity.IMMORTAL:
                rarityImg.sprite = immortal;
                break;
        }

        artImg.sprite = card.art;

        attachCostTxt.text = card.attachCost.ToString();

        if (card.emptyCost > 0)
        {
            emptyCostBg.gameObject.SetActive(true);
            emptyCostTxt.text = card.emptyCost.ToString();
        }
        else
        {
            emptyCostBg.gameObject.SetActive(false);
        }

        if (card.attack > 0)
        {
            attackBg.gameObject.SetActive(true);
            attackTxt.text = card.attack.ToString();
        }
        else
        {
            attackBg.gameObject.SetActive(false);
        }

        if (card.defense > 0)
        {
            defenseBg.gameObject.SetActive(true);
            defenseTxt.text = card.defense.ToString();
        }
        else
        {
            defenseBg.gameObject.SetActive(false);
        }

        foreach (Transform obj in abilityDescriptions)
        {
            Destroy(obj.gameObject);
        }

        int i = 0;
        foreach (Image abilityImg in abilityImages)
        {
            if (i < card.abilities.Count)
            {
                Ability ability = card.abilities[i];

                abilityImg.gameObject.SetActive(true);

                abilityImg.sprite = ability.art;

                var _title = Instantiate(abilityTitlePrefab, abilityDescriptions);
                var _description = Instantiate(abilityTextPrefab, abilityDescriptions);

                _title.GetComponentInChildren<TextMeshProUGUI>().text = ability.title;
                _title.GetComponentInChildren<Image>().sprite = ability.art;
                _description.GetComponent<TextMeshProUGUI>().text = ability.description;
            }
            else
            {
                abilityImg.gameObject.SetActive(false);
            }

            i++;
        }

        LayoutRebuilder.ForceRebuildLayoutImmediate(abilityTransform);
    }
}
