using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerOrderManager : MonoBehaviour
{
    public List<Player> players;
    private List<Player> playersLeaderBoard = new List<Player>();

    public List<Slider> sliders = new List<Slider>();
    public Dictionary<Player, Slider> racers = new Dictionary<Player, Slider>();

    public Race raceData;
    public float timer;

    public GameObject displayPref;
    public GameObject LeaderBoardUI;

    public ListSoundEffect audioProducer;

    private bool stopRace = false;

    // Start is called before the first frame update
    void Start()
    {
        SortPlayer();
        for (int i = 0; i < players.Count; i++)
        {

            playersLeaderBoard.Add(players[i]);

        }

        foreach (var s in sliders)
        {
            s.maxValue = raceData.RaceDistance;
        }

        timer = raceData.RaceTime;

        if (sliders.Count == players.Count)
        {
            for (int i = 0; i < players.Count; i++)
            {

                racers.Add(players[i], sliders[i]);
            }
        } else
        {
            Debug.LogError("Error");
        }

        LeaderBoardUI.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (!stopRace)
        {
            SortPlayerLeaderBoard();                
            SortPlayer();
            UpdateTime();
            UpdateRace();
            if (EndGame())
            {
                audioProducer.PlayVictory();
                LeaderBoardUI.SetActive(true);
                LeaderBoardUI.GetComponent<score>().SetLeaderBoard();
                stopRace = true;
            }
        }
    }

    public void UpdateTime()
    {
        timer -= Time.deltaTime;
        
    }
    private void UpdateRace()
    {
        foreach (KeyValuePair<Player, Slider> entry in racers)
        {
            entry.Value.value = Mathf.Floor(entry.Key.getDistance());
        }
    }

    public bool EndGame()
    {
        if (timer >= 0)
        {
            return (playersLeaderBoard[0].getDistance() >= raceData.RaceDistance) ? true : false;
        } else
        {
            return true;
        }
    }

    public void DisplayResult()
    {
        LeaderBoardUI.transform.parent.gameObject.SetActive(true);
        for (int i = 0; i < playersLeaderBoard.Count; i++)
        {
            GameObject temp = Instantiate(displayPref);
            temp.GetComponent<Text>().text = playersLeaderBoard[i].name + ": " + playersLeaderBoard[i].getDistance() + "  n°" + (i+1);
            temp.transform.SetParent(LeaderBoardUI.transform);

        }
        stopRace = true;
    }

    private void SortPlayerLeaderBoard()
    {

        playersLeaderBoard.Sort(delegate (Player a, Player b)
        {
            return (a.getDistance() <= b.getDistance()) ? 1 : -1;
        });

    }

    private void SortPlayer()
    {
        players.Sort(delegate (Player a, Player b)
        {
            return (a.playerName >= b.playerName) ? 1 : -1;
        });

    }


    public List<Player> getPlayerLeaderBoard()
    {

        return playersLeaderBoard;

    }

}
