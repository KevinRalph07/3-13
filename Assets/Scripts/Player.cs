using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Attributes
    public List<Card> Hand;
    public int Score;
    public bool isTurn;

    public Player()
    {
        Hand = new List<Card>();
        int Score = 0;
        isTurn = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
