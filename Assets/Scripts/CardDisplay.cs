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

    public Image rarityImg;

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

    public TextMeshProUGUI costTxt;

    public Sprite multiChampionBg;
    public Sprite multiUnitBg;
    public Sprite multiSpellBg;

    public Sprite factionMChampionBg;
    public Sprite factionMUnitBg;
    public Sprite factionMSpellBg;

    public Sprite factionDChampionBg;
    public Sprite factionDUnitBg;
    public Sprite factionDSpellBg;

    public List<Image> productionImages = new List<Image>();
    public RectTransform productionTransform;
    public List<Image> abilityImages = new List<Image>();
    public RectTransform abilityTransform;

    public RectTransform abilityDescriptions;

    public GameObject abilityTitlePrefab;
    public GameObject abilityTextPrefab;
    public GameObject abilityCardPrefab;

    public Card defaultCard;
    public CardData displayingCard;

    public CardDisplay backPreview;

    private void Awake()
    {
/*        foreach (Image abilityImg in abilityImages)
        {
            abilityImg.gameObject.SetActive(false);

        }*/
        abilityTransform = abilityImages[0].transform.parent.GetComponent<RectTransform>();

/*        foreach (Image productionImg in productionImages)
        {
            productionImg.gameObject.SetActive(false);

        }*/
        productionTransform = productionImages[0].transform.parent.GetComponent<RectTransform>();

    }

    public void UpdateDisplay(CardData card)
    {
        displayingCard = card;

        titleTxt.text = card.title;
        typeTxt.text = card.typeText;

        costTxt.text = CostToString(card);

        if (costTxt.text == "") costTxt.transform.parent.gameObject.SetActive(false);
        else costTxt.transform.parent.gameObject.SetActive(true);

        if (card.factionMulti)
        {
            switch (card.type)
            {
                case Card.Type.CHAMPION:
                    frameImg.sprite = multiChampionBg;
                    break;
                case Card.Type.UNIT:
                    frameImg.sprite = multiUnitBg;
                    break;
                case Card.Type.SPELL:
                    frameImg.sprite = multiSpellBg;
                    break;
            }
        }

        if (card.factionD)
        { 
            switch (card.type)
            {
                case Card.Type.CHAMPION:
                    frameImg.sprite = factionDChampionBg;
                    break;
                case Card.Type.UNIT:
                    frameImg.sprite = factionDUnitBg;
                    break;
                case Card.Type.SPELL:
                    frameImg.sprite = factionDSpellBg;
                    break;
            }
        }

        if (card.factionM)
        {
            switch (card.type)
            {
                case Card.Type.CHAMPION:
                    frameImg.sprite = factionMChampionBg;
                    break;
                case Card.Type.UNIT:
                    frameImg.sprite = factionMUnitBg;
                    break;
                case Card.Type.SPELL:
                    frameImg.sprite = factionMSpellBg;
                    break;
            }
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

        var _card = Instantiate(abilityCardPrefab, abilityDescriptions);

        _card.GetComponentInChildren<TextMeshProUGUI>().text = card.title;
        _card.GetComponentInChildren<Image>().sprite = card.art;

        int i = 0;
        foreach (Image productionImage in productionImages)
        {
            if (i < card.production.Count)
            {
                Production ability = card.production[i];

                productionImage.gameObject.SetActive(true);

                productionImage.sprite = ability.art;

                var _title = Instantiate(abilityTitlePrefab, abilityDescriptions);
                var _description = Instantiate(abilityTextPrefab, abilityDescriptions);

                _title.GetComponentInChildren<TextMeshProUGUI>().text = ability.title;
                _title.GetComponentInChildren<Image>().sprite = ability.art;
                _description.GetComponent<TextMeshProUGUI>().text = ability.description;
            }
            else
            {
                productionImage.gameObject.SetActive(false);
            }

            i++;
        }
        
        i = 0;
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

        
    }

    public string CostToString(CardData card)
    {
        string _text = "";

        for (int i = 0; i < card.wCost; i++)
        {
            _text += "<sprite name=iconW>";
        }
        for (int i = 0; i < card.fCost; i++)
        {
            _text += "<sprite name=iconF>";
        }
        for (int i = 0; i < card.mCost; i++)
        {
            _text += "<sprite name=iconM>";
        }
        for (int i = 0; i < card.sCost; i++)
        {
            _text += "<sprite name=iconS>";
        }
        for (int i = 0; i < card.eCost; i++)
        {
            _text += "<sprite name=iconE>";
        }
        for (int i = 0; i < card.dCost; i++)
        {
            _text += "<sprite name=iconD>";
        }
        for (int i = 0; i < card.vCost; i++)
        {
            _text += "<sprite name=iconV>";
        }
        if (card.bCost > 0)
        {
            _text += $"<sprite name=icon{card.bCost}>";
        }

        return _text;
    }
}
