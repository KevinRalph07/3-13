using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Attributes
    public GameObject TheDeck;
    public GameObject Player;
    public GameObject UI_Card;
    public GameObject Grid;
    public Sprite[] CardSpriteSheet;
    public List<GameObject> players;
    private int hand;
    private int curPlayer;


    // Start is called before the first frame update
    void Start()
    {
        players.Add(Instantiate(Player, new Vector3(0, 0, 0), Quaternion.identity));
        players.Add(Instantiate(Player, new Vector3(0,0,0), Quaternion.identity));
        Deck deck = TheDeck.GetComponent<Deck>();
        deck.InitDeck(1, 2);
        deck.Shuffle();
        hand = 3;
        Deal(hand);
        curPlayer = 0;
        updateUI();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Deal(int hand)
    {
        Deck deck = TheDeck.GetComponent<Deck>();
        for (int i = 0;  i < hand; i++) 
        {
            foreach (GameObject player in players) 
            {
                player.GetComponent<Player>().Hand.Add(deck.TheDeck.Pop());
            }
        }

        UpdateDiscardPile(deck.TheDeck.Pop());
        
    }

    private void UpdateDiscardPile(Card card)
    {
        Deck deck = TheDeck.GetComponent<Deck>();
        deck.TheDiscardPile.Push(card);
        deck.UpdateDiscardPileImage(card);

    }

    private void updateUI()
    {
        for (int i = 0; i < hand; i++)
        {
            Suit suit = players[curPlayer].GetComponent<Player>().Hand[i].Suit;
            int value = players[curPlayer].GetComponent<Player>().Hand[i].Value;

            GameObject ui_card = Instantiate(UI_Card, new Vector3(0, 0, 0), Quaternion.identity);
            ui_card.transform.SetParent(Grid.transform.GetChild(i).transform, true);
            ui_card.transform.localScale = new Vector3(0.6f, 0.64f, 1.0f);
            if (suit == Suit.JOKER)
            {
                ui_card.GetComponent<Image>().sprite = CardSpriteSheet[0];
            }
            else
            {
                ui_card.GetComponent<Image>().sprite = CardSpriteSheet[((int)suit - 1) * 13 + value];
            }

        }
    }

    private int GetNextPlayer()
    {
        return curPlayer++ % players.Count;
    }
}
