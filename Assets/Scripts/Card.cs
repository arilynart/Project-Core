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

    public Card.Faction faction;

    public Card.Rarity rarity;

    public int attachCost;
    public int emptyCost;

    public int attack;
    public int defense;

    public List<Ability> abilities;

    public CardData(Card card)
    {
        origin = card;
        title = card.title;
        type = card.type;
        typeText = card.typeText;
        art = card.art;
        faction = card.faction;
        rarity = card.rarity;
        attachCost = card.attachCost;
        emptyCost = card.emptyCost;
        attack = card.attack;
        defense = card.defense;
        abilities = new List<Ability>(card.abilities);
    }
}

[CreateAssetMenu(fileName = "New Card", menuName ="ScriptableObjects/Card", order = 1)]
public class Card : ScriptableObject
{

    public string title;

    public enum Type
    {
        UNIT,
        SPELL,
    }

    public Type type;

    public string typeText;

    public Sprite art;

    public enum Faction
    {
        PALADINS
    }

    public Faction faction;

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

    public int attachCost;
    public int emptyCost;

    public int attack;
    public int defense;

    public List<Ability> abilities;
}
