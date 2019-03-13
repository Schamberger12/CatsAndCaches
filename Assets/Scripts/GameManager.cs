using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameManager : NetworkBehaviour
{
    public static GameManager singleton;
    private List<PlayerControl> players = new List<PlayerControl>();
    private int numPlayers = 0;

    // create one lobby? or keep the two different ones?
    //   if keeping two, then how to get player names to update on both? need to run an update lobby function in lobby manager that sends
    //      info to server then server to clients constantly...might work
    //   if one, how to consolodate assets and player control?
    // create function that gives back all players then assign player names accordingly in lobbymanager
    // add character string for each player so you know which cat they chose...for now just do cat1, cat2, cat3 and need to put this
    //   functionality in the UI
    // from there, lobby manager will take in player control for each correcsponding player so when that player chooses something, it
    //   shows up on their screen and is sent to server and back to all clients...do this using playerbyID function
    // update text in middle from countdown...start with Players Ready 0/2 and once 2/2 you do countdown

    void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void addPlayer(PlayerControl p)
    {
        players.Add(p);
        Debug.Log("size of players: " + players.Count);
    }

    public int getNumPlayers()
    {
        return numPlayers;
    }

    public void incNumPlayers()
    {
        numPlayers = numPlayers + 1;
    }

    public PlayerControl getPlayerByID()
    {
        foreach (PlayerControl p in players)
        {
            if (p.isLocalPlayer)
            {
                return p;
            }
        }

        return null;
    }
}
