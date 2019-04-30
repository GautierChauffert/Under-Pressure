using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvincibleRaceUIManager : MonoBehaviour
{
    [SerializeField]
    PlayerOrderManager playerOrderManager;

    [SerializeField]
    Race circuit;

    [SerializeField]
    GameObject joueur1InvincibleImage;

    [SerializeField]
    GameObject joueur2InvincibleImage;

    [SerializeField]
    GameObject joueur3InvincibleImage;

    [SerializeField]
    GameObject joueur4InvincibleImage;

    bool runOnce = false;
    List<Player> players = new List<Player>();

    // Start is called before the first frame update
    void Start()
    {
        joueur1InvincibleImage.SetActive(false);
        joueur2InvincibleImage.SetActive(false);
        joueur3InvincibleImage.SetActive(false);
        joueur4InvincibleImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!runOnce)
        {
            players = playerOrderManager.players;
            runOnce = true;
        }
        for (int i=0; i < players.Count; i++)
        {
            bool untouchableTemp = players[i].untouchable;
            int NumberPlayerTemp = players[i].playerName;

            if (NumberPlayerTemp == 1)
            {
                if(untouchableTemp!= joueur1InvincibleImage.activeSelf)
                {
                    joueur1InvincibleImage.SetActive(untouchableTemp);
                }
                
            }else if (NumberPlayerTemp == 2)
            {
                if (untouchableTemp != joueur2InvincibleImage.activeSelf)
                {
                    joueur2InvincibleImage.SetActive(untouchableTemp);
                }
            }
            else if (NumberPlayerTemp == 3)
            {
                if (untouchableTemp != joueur3InvincibleImage.activeSelf)
                {
                    joueur3InvincibleImage.SetActive(untouchableTemp);
                }
            }
            else if (NumberPlayerTemp == 4)
            {
                if (untouchableTemp != joueur4InvincibleImage.activeSelf)
                {
                    joueur4InvincibleImage.SetActive(untouchableTemp);
                }
            }
        }
        
        
    }
}
