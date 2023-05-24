using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct CardData
{
    public Card origin;

    public string title;

    public Card.Type type;

    public string typeText;

    public Sprite art;

    public bool factionMulti;
    public bool factionM;
    public bool factionD;

    public Card.Rarity rarity;

    public int wCost;
    public int fCost;
    public int mCost;
    public int sCost;
    public int eCost;
    public int dCost;
    public int vCost;
    public int bCost;

    public int attack;
    public int defense;

    public List<Production> production;
    public List<Ability> abilities;

    public Card flipCard;

    public CardData(Card card)
    {
        origin = card;
        title = card.title;
        type = card.type;
        typeText = card.typeText;
        art = card.art;
        factionMulti = card.factionMulti;
        factionM = card.factionM;
        factionD = card.factionD;
        rarity = card.rarity;
        wCost = card.wCost;
        fCost = card.fCost;
        mCost = card.mCost;
        sCost = card.sCost;
        eCost = card.eCost;
        dCost = card.dCost;
        vCost = card.vCost;
        bCost = card.bCost;
        attack = card.attack;
        defense = card.defense;
        production = new List<Production>(card.production);
        abilities = new List<Ability>(card.abilities);

        flipCard = card.flipCard;
    }
}


[CreateAssetMenu(fileName = "New Card", menuName ="ScriptableObjects/Card", order = 1)]
public class Card : ScriptableObject
{

    public string title;

    public enum Type
    {
        CHAMPION,
        UNIT,
        SPELL
    }

    public Type type;

    public string typeText;

    public Sprite art;

    public bool factionMulti;
    public bool factionD;
    public bool factionM;

    public enum Rarity
    {
        COMMON,
        UNCOMMON,
        RARE,
        MYTHIC,
        LEGENDARY,
        IMMORTAL
    }

    public Rarity rarity;

    public int wCost;
    public int fCost;
    public int mCost;
    public int sCost;
    public int eCost;
    public int dCost;
    public int vCost;
    public int bCost;

    public int attack;
    public int defense;

    public List<Production> production;
    public List<Ability> abilities;

    public Card flipCard;
}
