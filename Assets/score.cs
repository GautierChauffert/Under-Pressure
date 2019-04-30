using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public List<Image> images = new List<Image>();
    public PlayerOrderManager playerOrderManager;
    public GameObject panel;

    public void SetLeaderBoard()
    {
        List<Player> plb = playerOrderManager.getPlayerLeaderBoard();
        for (int i = 0; i < plb.Count; i++)
        {
            images[i].sprite = plb[i].playerIcon;
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Player1Select") || Input.GetButtonDown("Player2Select")|| Input.GetButtonDown("Player3Select")|| Input.GetButtonDown("Player4Select"))
        {
            LoadMenu();
        }
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("00_Menu");
    }
}
