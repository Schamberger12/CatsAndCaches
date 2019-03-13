using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class LobbyManager : NetworkBehaviour
{
    public GameObject WelcomeScreen;
    public GameObject LobbyScreen;
    public GameObject CountdownScreen;

    public InputField usernameInput;
    public Button enterLobbyButton;

    public Text player1;
    public Text player2;
    [SyncVar] private string player1String = "test";
    [SyncVar] private string player2String = "test";

    // Start is called before the first frame update
    void Start()
    {
        enterLobbyButton.onClick.AddListener(EnterLobby);
        WelcomeScreen.SetActive(true);
        LobbyScreen.SetActive(false);
        CountdownScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isServer)
        {
            // then send all info from server to clients
            RpcUpdateLobbyNames();
        }
        else
        {
            CmdUpdateLobbyNames(player2String);
        }
    }

    [Command]
    void CmdUpdateLobbyNames(string p)
    {
        RpcUpdateSecondPlayerName(p);
        RpcUpdateLobbyNames();
    }

    [ClientRpc]
    void RpcUpdateSecondPlayerName(string p)
    {
        player2String = p;
    }

    [ClientRpc]
    void RpcUpdateLobbyNames()
    {
        player1.text = player1String;
        player2.text = player2String;
    }

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
                player1String = p.getUsername();
            }
            else if (p.getID() == 2)
            {
                player2String = p.getUsername();
            }
        }
    }
}