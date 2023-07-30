using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Deck : MonoBehaviour
{
    // Attributes
    public GameObject Card;
    public GameObject DiscardPileObject;
    private int mNumDecks;
    private int mNumJokers;
    private List<Card> mFullDeck;
    private Stack<Card> mCurDeck;
    private Stack<Card> mCurDiscardPile;

    public Dictionary<Suit, Dictionary<int, Vector2>> CardTextureCoordinates;


    // Constructor
    public Deck()
    {
        mFullDeck = new List<Card>();
        mCurDeck = new Stack<Card>();
        mCurDiscardPile = new Stack<Card>();
    }

    private void Awake()
    {
        InitCardTextureCoordDict();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector2 ConvertPixelsToUVCoordinates(int x, int y, int textureWidth, int textureHeight)
    {
        return new Vector2((float)x / textureWidth, (float)y / textureHeight);
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

    public void UpdateDiscardPileImage(Card card)
    {
        Suit suit = card.Suit;
        int value = card.Value;

        int x = (int)CardTextureCoordinates[suit][value][0];
        int y = (int)CardTextureCoordinates[suit][value][1];
        int width = 148;
        int height = 198;
        int textureWidth = 1332;
        int textureHeight = 1188;

        Vector3[] vertices = new Vector3[4];
        Vector2[] uv = new Vector2[4];
        int[] triangles = new int[6];

        vertices[0] = new Vector3(0, 1);
        vertices[1] = new Vector3(1, 1);
        vertices[2] = new Vector3(0, 0);
        vertices[3] = new Vector3(1, 0);

        //uv[0] = new Vector2(0, 1);
        //uv[1] = new Vector2(1, 1);
        //uv[2] = new Vector2(0, 0);
        //uv[3] = new Vector2(1, 0);

        uv[0] = ConvertPixelsToUVCoordinates(x, y + height, textureWidth, textureHeight);
        uv[1] = ConvertPixelsToUVCoordinates(x + width, y + height, textureWidth, textureHeight);
        uv[2] = ConvertPixelsToUVCoordinates(x, y, textureWidth, textureHeight);
        uv[3] = ConvertPixelsToUVCoordinates(x + width, y, textureWidth, textureHeight);

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;
        triangles[3] = 2;
        triangles[4] = 1;
        triangles[5] = 3;

        GameObject back = DiscardPileObject.transform.GetChild(0).gameObject;
        MeshFilter filter = back.GetComponent<MeshFilter>();
        filter.mesh.vertices = vertices;
        filter.mesh.uv = uv;
        filter.mesh.triangles = triangles;

        //DiscardPileObject.transform.localScale = new Vector3(DiscardPileObject.transform.localScale.x, 0.002f, DiscardPileObject.transform.localScale.z);
    }

    private void InitCardTextureCoordDict()
    {
        CardTextureCoordinates = new Dictionary<Suit, Dictionary<int, Vector2>>();

        Dictionary<int, Vector2> joker = new Dictionary<int, Vector2>();
        Dictionary<int, Vector2> spades = new Dictionary<int, Vector2>();
        Dictionary<int, Vector2> hearts = new Dictionary<int, Vector2>();
        Dictionary<int, Vector2> clubs = new Dictionary<int, Vector2>();
        Dictionary<int, Vector2> diamonds = new Dictionary<int, Vector2>();

        //spades[2] = new Vector2(740, 0);
        spades[1] = new Vector2(148 * 4, 198 * 0);
        spades[2] = new Vector2(148 * 5, 198 * 0);
        spades[3] = new Vector2(148 * 6, 198 * 0);
        spades[4] = new Vector2(148 * 7, 198 * 0);
        spades[5] = new Vector2(148 * 8, 198 * 5);
        spades[6] = new Vector2(148 * 8, 198 * 4);
        spades[7] = new Vector2(148 * 8, 198 * 3);
        spades[8] = new Vector2(148 * 8, 198 * 2);
        spades[9] = new Vector2(148 * 8, 198 * 1);
        spades[10] = new Vector2(148 * 0, 198 * 0);
        spades[11] = new Vector2(148 * 1, 198 * 0);
        spades[12] = new Vector2(148 * 2, 198 * 0);
        spades[13] = new Vector2(148 * 3, 198 * 0);

        hearts[1] = new Vector2(148 * 6, 198 * 2);
        hearts[2] = new Vector2(148 * 7, 198 * 2);
        hearts[3] = new Vector2(148 * 0, 198 * 1);
        hearts[4] = new Vector2(148 * 1, 198 * 1);
        hearts[5] = new Vector2(148 * 2, 198 * 1);
        hearts[6] = new Vector2(148 * 3, 198 * 1);
        hearts[7] = new Vector2(148 * 4, 198 * 1);
        hearts[8] = new Vector2(148 * 5, 198 * 1);
        hearts[9] = new Vector2(148 * 6, 198 * 1);
        hearts[10] = new Vector2(148 * 2, 198 * 2);
        hearts[11] = new Vector2(148 * 3, 198 * 2);
        hearts[12] = new Vector2(148 * 4, 198 * 2);
        hearts[13] = new Vector2(148 * 5, 198 * 2);

        clubs[1] = new Vector2(148 * 4, 198 * 5);
        clubs[2] = new Vector2(148 * 5, 198 * 5);
        clubs[3] = new Vector2(148 * 6, 198 * 5);
        clubs[4] = new Vector2(148 * 7, 198 * 5);
        clubs[5] = new Vector2(148 * 0, 198 * 4);
        clubs[6] = new Vector2(148 * 1, 198 * 4);
        clubs[7] = new Vector2(148 * 2, 198 * 4);
        clubs[8] = new Vector2(148 * 3, 198 * 4);
        clubs[9] = new Vector2(148 * 4, 198 * 4);
        clubs[10] = new Vector2(148 * 0, 198 * 5);
        clubs[11] = new Vector2(148 * 1, 198 * 5);
        clubs[12] = new Vector2(148 * 2, 198 * 5);
        clubs[13] = new Vector2(148 * 3, 198 * 5);

        diamonds[1] = new Vector2(148 * 1, 198 * 3);
        diamonds[2] = new Vector2(148 * 2, 198 * 3);
        diamonds[3] = new Vector2(148 * 3, 198 * 3);
        diamonds[4] = new Vector2(148 * 4, 198 * 3);
        diamonds[5] = new Vector2(148 * 5, 198 * 3);
        diamonds[6] = new Vector2(148 * 7, 198 * 3);
        diamonds[8] = new Vector2(148 * 0, 198 * 2);
        diamonds[9] = new Vector2(148 * 1, 198 * 2);
        diamonds[10] = new Vector2(148 * 5, 198 * 4);
        diamonds[11] = new Vector2(148 * 6, 198 * 4);
        diamonds[12] = new Vector2(148 * 7, 198 * 4);
        diamonds[13] = new Vector2(148 * 0, 198 * 3);

        joker[0] = new Vector2(148 * 7, 198 * 1);

        CardTextureCoordinates[Suit.JOKER] = joker;
        CardTextureCoordinates[Suit.SPADES] = spades;
        CardTextureCoordinates[Suit.HEARTS] = hearts;
        CardTextureCoordinates[Suit.CLUBS] = clubs;
        CardTextureCoordinates[Suit.DIAMONDS] = diamonds;


    }

    public Stack<Card> TheDeck { get { return mCurDeck; } }

    public Stack<Card> TheDiscardPile {  get { return mCurDiscardPile; } }


}
