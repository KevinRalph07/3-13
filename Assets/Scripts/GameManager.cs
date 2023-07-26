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
        TheDeck.GetComponent<Deck>().InitDeck(1, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
