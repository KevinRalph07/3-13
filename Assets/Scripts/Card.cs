using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Suits
public enum Suit
{
    JOKER,
    SPADES,
    HEARTS,
    CLUBS,
    DIAMONDS
}

// Values
// 0 = Joker
// 1 = Ace
// 2-20 = 2-10
// 11,12,13 = J,Q,K

public class Card : MonoBehaviour
{
    // Attributes
    private Suit mSuit;
    private int mValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Setters
    public void setAttribs(Suit suit, int value)
    {
        mSuit = suit;
        mValue = value;
    }

    // Getters
    public Suit Suit { get { return mSuit; } }
    public int Value { get { return mValue; } }
}
