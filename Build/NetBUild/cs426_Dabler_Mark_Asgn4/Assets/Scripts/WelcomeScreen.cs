using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


public class WelcomeScreen : NetworkBehaviour
{
    public static WelcomeScreen singleton;

    public GameObject LobbyManagerObj;
    public GameObject WelcomeScreenObj;
    public GameObject LobbyScreenObj;
    public GameObject CountdownScreenObj;

    public InputField usernameInput;
    public Button enterLobbyButton;

    public Text player1;
    public Text player2;

    public Button player1Rdy;
    public Button player2Rdy;

    /* 
     * Need to rewrite this so that I am using the player object so I can 
     * update the number of ready players just like I had to change for name
     * displays 
     */
    public int MAX_PLAYERS = 2;
    public bool ready = false;

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
        enterLobbyButton.onClick.AddListener(EnterLobby);
        player1Rdy.onClick.AddListener(RoundStart);
        player2Rdy.onClick.AddListener(RoundStart);
        WelcomeScreenObj.SetActive(true);
        LobbyScreenObj.SetActive(false);
        CountdownScreenObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void RoundStart()
    {
        // get the correct player, set their ready state
        // in lobbymanager update() keep checking to see if two are ready
        //   and keep updating the number just like you are for the other thing
        PlayerControl p = GameManager.singleton.getPlayerByID();
        p.setReady(true);
        //GameManager.singleton.SetReady(p, true);
        Debug.Log("Ready Players (roundstart): " + GameManager.singleton.numReadyPlayers());
    }

    public void StartCountdown()
    {
        Debug.Log("Ready Players (startcountdown): " + GameManager.singleton.numReadyPlayers());
        CountdownScreenObj.SetActive(true);
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
        }
        WelcomeScreenObj.SetActive(false);
        LobbyScreenObj.SetActive(true);
    }


}
