using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Attributes
    public GameObject TheDeck;
    public GameObject Player;
    public List<GameObject> players;


    // Start is called before the first frame update
    void Start()
    {
        players.Add(Instantiate(Player, new Vector3(0, 0, 0), Quaternion.identity));
        players.Add(Instantiate(Player, new Vector3(0,0,0), Quaternion.identity));
        Deck deck = TheDeck.GetComponent<Deck>();
        deck.InitDeck(1, 2);
        deck.Shuffle();
        int hand = 3;
        Deal(hand);
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

        deck.TheDiscardPile.Push(deck.TheDeck.Pop());
    }
}
