using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Deck : MonoBehaviour
{
    // Attributes
    public GameObject Card;
    private int mNumDecks;
    private int mNumJokers;
    private List<Card> mFullDeck;
    private Stack<Card> mCurDeck;
    private Stack<Card> mCurDiscardPile;


    // Constructor
    public Deck()
    {
        mFullDeck = new List<Card>();
        mCurDeck = new Stack<Card>();
        mCurDiscardPile = new Stack<Card>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<Card> InitDeck(int numDecks, int numJokers)
    {
        mNumDecks = numDecks;
        mNumJokers = numJokers;

        // add standard 52 cards to deck mNumDecks times
        for (int d = 0; d < mNumDecks; d++)
        {
            for (int i = 0; i < 52; i++)
            {
                Suit suit = (Suit)((Mathf.Floor(i / 13) % 4) + 1);
                int value = i % 13 + 1;
                GameObject card = Instantiate(Card, new Vector3(0, 0, 0), Quaternion.identity);
                card.GetComponent<Card>().setAttribs(suit, value);
                mFullDeck.Add(card.GetComponent<Card>());
                //Debug.Log(value + suit.ToString());

            }
        }
        
        // add mNumJokers jokers to deck
        for (int j = 0; j < mNumJokers; j++)
        {
            GameObject card = Instantiate(Card, new Vector3(0, 0, 0), Quaternion.identity);
            card.GetComponent<Card>().setAttribs(Suit.JOKER, 0);
            mFullDeck.Add(card.GetComponent<Card>());
            //Debug.Log("Joker");
        }


        return mFullDeck;
    }

    public Stack<Card> Shuffle()
    {
        // dup full deck
        List<Card> tmpDeck = new List<Card>();
        for (int i = 0; i < mFullDeck.Count; i++)
        {
            tmpDeck.Add(mFullDeck[i]);
        }

        // add random card from deck to stack and remove from tmp list
        for (int i = 0; i < mFullDeck.Count; i++)
        {
            int index = Random.Range(0, tmpDeck.Count);
            mCurDeck.Push(tmpDeck[index]);
            tmpDeck.RemoveAt(index);
        }

        return mCurDeck;
    }

    public Stack<Card> CurDeck { get { return mCurDeck; } }

    public Stack<Card> DiscardPile {  get { return mCurDiscardPile; } }


}
