using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlInGame : MonoBehaviour
{
    [HideInInspector]
    public Player player;
    public string playerName;
    public Color playerColor;

    public int cardIndexSelected = 0;

    public GameObject playerManager;
    bool x_isAxisInUse = false;

    public GameObject ui;

    public static bool PauseIsOn = false;
    public GameObject pauseMenuUI;
    public string sceneName;


    private void Start()
    {

        player = GetComponent<Player>();
        if (!player)
        {

            Debug.LogError("No Player script attached");
        }
        if (!playerManager)
        {
            Debug.LogError("No player Manager available");
        }
        playerName = this.name;

       
    }

    void Update()
    {

        if(!PauseIsOn)
        {

            if (Input.GetAxisRaw(playerName + "Horizontal") != 1 && Input.GetAxisRaw(playerName + "Horizontal") != -1)
            {
                x_isAxisInUse = false;
            }


            if (Input.GetAxisRaw(playerName + "Horizontal") != 0 && player.cards.Count > 0)
            {
                if (Input.GetAxisRaw(playerName + "Horizontal") == 1 && cardIndexSelected < player.cards.Count - 1 && x_isAxisInUse == false)
                {

                    x_isAxisInUse = true;
                    DelightUI(cardIndexSelected);
                    cardIndexSelected++;
                    HighlightUI(cardIndexSelected);

                }
                else if (Input.GetAxisRaw(playerName + "Horizontal") == 1 && cardIndexSelected == player.cards.Count - 1 && x_isAxisInUse == false)
                {
                    x_isAxisInUse = true;
                    DelightUI(cardIndexSelected);
                    cardIndexSelected = 0;
                    HighlightUI(cardIndexSelected);
                }
                else if (Input.GetAxis(playerName + "Horizontal") == -1 && cardIndexSelected != 0 && x_isAxisInUse == false)
                {
                    x_isAxisInUse = true;
                    DelightUI(cardIndexSelected);
                    cardIndexSelected--;
                    HighlightUI(cardIndexSelected);
                }
                else if (Input.GetAxis(playerName + "Horizontal") == -1 && cardIndexSelected == 0 && x_isAxisInUse == false)
                {
                    x_isAxisInUse = true;
                    DelightUI(cardIndexSelected);
                    cardIndexSelected = player.cards.Count - 1;
                    HighlightUI(cardIndexSelected);
                }
            }


            if (Input.GetButtonDown(player.name + "Select"))
            {
                player.PlayCard(cardIndexSelected, playerManager.GetComponent<PlayerOrderManager>().players[2]);
                cardIndexSelected = 0;
                Debug.Log("A" + " P : " + playerManager.GetComponent<PlayerOrderManager>().players[2].name);


            }
            if (Input.GetButtonDown(player.name + "Cancel"))
            {
                player.PlayCard(cardIndexSelected, playerManager.GetComponent<PlayerOrderManager>().players[3]);
                cardIndexSelected = 0;
                Debug.Log("B" + " P : " + playerManager.GetComponent<PlayerOrderManager>().players[3].name);
            

            }
            if (Input.GetButtonDown(player.name + "X"))
            {

                player.PlayCard(cardIndexSelected, playerManager.GetComponent<PlayerOrderManager>().players[0]);
                cardIndexSelected = 0;
                Debug.Log("X" + " P : " + playerManager.GetComponent<PlayerOrderManager>().players[0].name);
            
               // anim.SetInteger(selection, 0);

            }
            if (Input.GetButtonDown(player.name + "Y"))
            {
                player.PlayCard(cardIndexSelected, playerManager.GetComponent<PlayerOrderManager>().players[1]);
                cardIndexSelected = 0;
                Debug.Log("Y" + " P : " + playerManager.GetComponent<PlayerOrderManager>().players[1].name);
            


            }
        }

        if (Input.GetButtonDown(player.name + "Start"))
        {

            Pause();
        }
        else if (PauseIsOn == true)
        {
            if (Input.GetButtonDown(player.name + "Select"))
            {
                Resume();

            }
            else if (Input.GetButtonDown(player.name + "Y"))
            {

                QuitGame();

            }
            else if (Input.GetButtonDown(player.name + "Cancel"))
            {

                LoadMenu();

            }
        }


    }


    public void HighlightUI(int id)
    {
        if (!player)
        {
            player = GetComponent<Player>();
        }
        Card carte = player.cards[id];
        Transform tmp = ui.transform.Find(carte.nameCard);
        if (tmp)
            tmp.GetComponent<CardsExposer>().GetSurbrillance().SetActive(true);
            //tmp.GetComponent<RawImage>().color = Color.yellow;

    }

    public void DelightUI(int id)
    {
        Card carte = player.cards[id];
        Transform tmp = ui.transform.Find(carte.nameCard);
        if (tmp)
            tmp.GetComponent<CardsExposer>().GetSurbrillance().SetActive(false);
            //tmp.GetComponent<RawImage>().color = Color.white;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        PauseIsOn = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        PauseIsOn = true;
    }

    public void LoadMenu()
    {
        PauseIsOn = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);

    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}