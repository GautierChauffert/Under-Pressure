using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolCards : MonoBehaviour {

    [Space]
    [Header("Liste des cartes d'origines servant a setter le deck")]
    [SerializeField]
    public List<Card> baseCards;

    [Space]
    [Header("Liste des cartes")]
    [SerializeField]
    public List<Card> cards;

    [Header("liste des nombres de cartes par rareté")]
    [SerializeField]
    public List<RuleRarity> rarityRule;

    [Space]
    [Header("Liste des cartes par ordre de spawn NE PAS REMPLIR: initialisé au début du niveau")]
    public List<Card> availableCards = new List<Card>();


    public Dictionary<Card, int> CardsActive = new Dictionary<Card, int>();


    [Space]
    [Header("Script de distribution des Cartes")]
    [SerializeField]
    public SpawnCards SpawnerEnemy;
    

    private void Update()
    {

    }

    private void OnDisable()
    {

    }




    /// <summary>
    /// initialise the normal list
    /// </summary>
    public void Init()
    {
        InitDeck();
        availableCards.Clear();
        int i = 0;
        foreach (var card in cards)
        {
            i++;
            DisposeCard(card);
        }
        Shuffle<Card>(availableCards);

    }


    /// <summary>
    /// return the  size of the available card list
    /// </summary>
    /// <returns></returns>
    public int GetSizeAvCards()
    {
        return availableCards.Count;
    }



    /// <summary>
    /// gat an avatar from the normal list
    /// </summary>
    /// <returns></returns>
    public Card GetCard()
    {
        if (availableCards == null)
        {
            Init();
        }
        var tmp = availableCards[0];
        availableCards.RemoveAt(0);
        try
        {
            CardsActive.Add(tmp, 0);
        }
        catch (ArgumentException e)
        {
            Debug.LogError("Error on geting a card : \n" + e.ToString());
        }
        return tmp;
    }

   

    /// <summary>
    ///  add the card to the available list
    /// </summary>
    /// <param name="av"></param>
    public void AddCard(Card av)
    {
        availableCards.Add(av);
    }



    /// <summary>
    /// dispose the Card selected from the Active card list
    /// </summary>
    /// <param name="avatar"></param>
    public void DisposeCard(Card card)
    {
        CardsActive.Remove(card);
        availableCards.Add(card);
    }
    public void Shuffle<T>(List<T> ts)
    {
        int count = ts.Count;
        int last = count - 1;
        for (var i = 0; i < last; ++i)
        {
            int r = UnityEngine.Random.Range(i, count);
            var tmp = ts[i];
            ts[i] = ts[r];
            ts[r] = tmp;
        }
    }

    private void InitDeck()
    {
      
        for (int i = 0; i < baseCards.Count; i++)
        {
            int numberSpawn=0;
            for(int j=0;j<rarityRule.Count; j++)
            {
                if (rarityRule[j].rarity == baseCards[i].rarety)
                {
                    numberSpawn = rarityRule[j].numberEachTypeCard;
                    break;
                }
            }

            for (int k = 0; k < numberSpawn;k++)
            {
                Card c = Instantiate<Card>(baseCards[i]);
                cards.Add(c);
            }
        }
    }

}
