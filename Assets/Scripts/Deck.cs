using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    // Attributes
    private int mNumDecks;
    private int mNumJokers;
    private List<Card> mFullDeck;
    private Stack<Card> mCurDeck;
    private Stack<Card> mCurDiscardPile;

    // Constructor
    public Deck(int numDecks, int numJokers)
    {
        mNumDecks = numDecks;
        mNumJokers = numJokers;
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

    public List<Card> InitDeck ()
    {
        // add standard 52 cards to deck mNumDecks times
        for (int d = 0; d < mNumDecks; d++)
        {
            for (int i = 0; i < 52; i++)
            {
                Suit suit = (Suit)((Mathf.Floor(i / 13) % 4) + 1);
                int value = i % 13 + 1;
                mFullDeck.Add(new Card(suit, value));
            }
        }
        
        // add mNumJokers jokers to deck
        for (int j = 0; j < mNumJokers; j++)
        {
            mFullDeck.Add(new Card(Suit.JOKER, 0));
        }


        return mFullDeck;
    }

    public Stack<Card> Shuffle()
    {

        return mCurDeck;
    }

    public Stack<Card> CurDeck { get { return mCurDeck; } }

    public Stack<Card> DiscardPile {  get { return mCurDiscardPile; } }


}
