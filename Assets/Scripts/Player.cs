using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Card> originalDeck = new List<Card>();

    public Card originalChampion;
    public CardBehaviour champion;

    public List<CardBehaviour> deck = new List<CardBehaviour>();
    public List<CardBehaviour> hand = new List<CardBehaviour>();
    public List<CardBehaviour> scrap = new List<CardBehaviour>();
    public List<CardBehaviour> discard = new List<CardBehaviour>();

    private void Start()
    {

        BuildChampion();

        BuildDeck();

        deck = ShuffleDeck(deck);

    }

    public void BuildChampion()
    {
        champion = GetComponent<CardBehaviour>();

        if (originalChampion)
        {
            champion.frontSide = new CardData(originalChampion);
            champion.backSide = new CardData(originalChampion.flipCard);

            GetComponent<SpriteRenderer>().sprite = champion.frontSide.art;
        }
    }

    public void BuildDeck()
    {
        foreach (CardBehaviour oldCard in deck)
        {
            Destroy(gameObject);
        }

        deck.Clear();

        foreach (Card card in originalDeck)
        {
            var _obj = new GameObject();
            _obj.transform.SetParent(transform);
            var _component = _obj.AddComponent<CardBehaviour>();

            _component.frontSide = new CardData(card);
            if (card.flipCard)
            {
                _component.backSide = new CardData(card.flipCard);
            }

            deck.Add(_component);
        }
    }

    public List<CardBehaviour> ShuffleDeck(List<CardBehaviour> list)
    {
        int initialCount = list.Count;
        List<CardBehaviour> shuffledList = new List<CardBehaviour>();
        for (int i = 0; i < initialCount; i++)
        {
            int roll = Random.Range(0, list.Count - 1);

            CardBehaviour card = list[roll];

            shuffledList.Add(card);

            list.RemoveAt(roll);
        }

        return shuffledList;
    }
}