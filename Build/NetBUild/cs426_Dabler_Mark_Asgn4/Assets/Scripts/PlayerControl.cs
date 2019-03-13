using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerControl : NetworkBehaviour
{
    private string username;
    private int id;
    private bool ready = false;
    
    // Start is called before the first frame update
    void Start()
    {
        GameManager.singleton.addPlayer(this);
        GameManager.singleton.incNumPlayers();
        id = GameManager.singleton.getNumPlayers();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setUsername(string s)
    {
        username = s;
    }

    public string getUsername()
    {
        return username;
    }

    public int getID()
    {
        return id;
    }

    public bool getReady()
    {
        return ready;
    }

    public void setReady(bool val)
    {
        ready = val;
    }
}
