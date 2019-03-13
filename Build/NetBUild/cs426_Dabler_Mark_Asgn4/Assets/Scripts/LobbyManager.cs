using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class LobbyManager : NetworkBehaviour
{
    [SyncVar(hook = "p1Update")] private string player1String;
    [SyncVar(hook = "p2Update")] private string player2String;
    [SyncVar] private bool player1Ready;
    [SyncVar] private bool player2Ready;
    [SyncVar] private bool countdownStart = false;

    private int readyPlayers = 0;

    public int getReadyPlayers()
    {
        return readyPlayers;
    }

    public void incReadyPlayers(int i)
    {
        readyPlayers = readyPlayers + i;
    }

    //[SyncVar] private string player1String;
    //[SyncVar] private string player2String;
    //private string player1String;
    //private string player2String;

    [Command]
    void CmdUpdateP1(string s)
    {
        player1String = s;
        RpcUpdateP1(s);
    }

    [Command]
    void CmdUpdateP2(string s)
    {
        player2String = s;
        RpcUpdateP2(s);
    }

    [ClientRpc]
    void RpcUpdateP1(string s)
    {
        WelcomeScreen.singleton.player1.text = s;
    }

    [ClientRpc]
    void RpcUpdateP2(string s)
    {
        WelcomeScreen.singleton.player2.text = s;
    }

    /*
    public override void OnStartClient()
    {
        p1Update(player1String);
        p2Update(player2String);
    }
    */

    // Start is called before the first frame update
    void Start()
    {

    }

    void p1Update(string s)
    {
        player1String = s;
    }

    void p2Update(string s)
    {
        player2String = s;
    }

    void p1Ready(bool b)
    {
        player1Ready = b;
    }

    void p2Ready(bool b)
    {
        player1Ready = b;
    }

    [Command]
    void CmdSetp1(string s)
    {
        player1String = s;
    }
    
    [Command]
    void CmdSetp2(string s)
    {
        player2String = s;
    }

    // Update is called once per frame
    void Update()
    {
        getNames();
        if (isServer)
        {
            // then send all info from server to clients
            RpcUpdateP1(player1String);
            RpcUpdateP2(player2String);
            RpcUpdateP1Rdy(player1Ready);
            RpcUpdateP2Rdy(player2Ready);
        }
        else
        {
            //CmdUpdateP1(player1String);
            //CmdUpdateP2(player2String);
            //CmdUpdateP1Rdy(player1Ready);
            //CmdUpdateP2Rdy(player2Ready);
        }
    }
    
    [Command]
    void CmdUpdateP1Rdy(bool b)
    {
        player1Ready = b;
        RpcUpdateP1Rdy(b);
    }

    [Command]
    void CmdUpdateP2Rdy(bool b)
    {
        player2Ready = b;
        RpcUpdateP2Rdy(b);
    }

    [ClientRpc]
    void RpcUpdateP1Rdy(bool b)
    {
        player1Ready = b;
        if (player1Ready && player2Ready && !countdownStart)
        {
            WelcomeScreen.singleton.StartCountdown();
            countdownStart = true;
        }
    }

    [ClientRpc]
    void RpcUpdateP2Rdy(bool b)
    {
        player1Ready = b;
        if (player1Ready && player2Ready && !countdownStart)
        {
            WelcomeScreen.singleton.StartCountdown();
            countdownStart = true;
        }
    }
    
    [Command]
    void CmdSetp1Rdy(bool b)
    {
        player1Ready = b;
    }

    [Command]
    void CmdSetp2Rdy(bool b)
    {
        player1Ready = b;
    }

    void getReadyStatus()
    {
        PlayerControl p = GameManager.singleton.getPlayerByID();

        if (p.getID() == 1)
        {
            player1Ready = p.getReady();
            //CmdSetp1Rdy(player1Ready);
        }
        else if (p.getID() == 2)
        {
            player2Ready = p.getReady();
            //CmdSetp2Rdy(player2Ready);
        }
    }

    void getNames()
    {
        PlayerControl p = GameManager.singleton.getPlayerByID();

        if (p.getID() == 1 && p.isLocalPlayer)
        {
            player1String = p.getUsername();
            CmdSetp1(player1String);
        }
        else if (p.getID() == 2 && p.isLocalPlayer)
        {
            player2String = p.getUsername();
            CmdSetp2(player2String);
        }
    }

    [Command]
    void CmdUpdateLobbyNames(string p)
    {
        RpcUpdateSecondPlayerName(p);
        RpcUpdateLobbyNames();
    }

    void RpcUpdateSecondPlayerName(string p)
    {
        player2String = p;
    }

    void RpcUpdateLobbyNames()
    {
        //player1.text = player1String;
        //player2.text = player2String;
    }

    void UpdateLobbyNames(string s)
    {
       /* if (isServer)
        {
            player1.text = player1String;
            if (s != "test")
            {
                player2String = s;
            }
            player2.text = player2String;
        }
        else
        {
            CmdUpdateLobbyName(player2String);
        } */
    }

    [Command]
    void CmdUpdateLobbyName(string s)
    {
        UpdateLobbyNames(s);
    }

    /*
    void EnterLobby()
    {
        if (usernameInput.text != null)
        {
            PlayerControl p = GameManager.singleton.getPlayerByID();
            if (p != null)
            {
                p.setUsername(usernameInput.text);
            }
            else
            {
                Debug.Log("Enter Lobby Error, null");
            }

            WelcomeScreen.SetActive(false);
            LobbyScreen.SetActive(true);
                
            if (p.getID() == 1) 
            {
                //player1String = p.getUsername();
                //player1.text = p.getUsername();
                player1String = p.getUsername();

                CmdSetp1(player1String);
            }
            else if (p.getID() == 2)
            {
                Debug.Log("Username: " + p.getUsername());
                Debug.Log("p2 before: " + player2String);
                player2String = p.getUsername();
                LobbyManagerObj.GetComponent<NetworkIdentity>().AssignClientAuthority(this.GetComponent<NetworkIdentity>().connectionToClient);

                CmdSetp2(player2String);
                //player2String = p.getUsername();
                Debug.Log("Localplayer?" + isLocalPlayer);
                Debug.Log("What about hasauthority? " + hasAuthority, this);
                //CmdUpdateP2(p.getUsername());
                Debug.Log("p2 after: " + player2String);
                // CmdUpdateLobbyNames(p.getUsername());


                //player2.text = p.getUsername();
            }

            // p1Update(player1String);
            // p2Update(player2String);
        }
    }
    */
}