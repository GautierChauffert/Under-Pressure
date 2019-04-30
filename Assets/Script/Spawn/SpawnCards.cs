using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnCards : MonoBehaviour {


    // [Space]
    [Header("liste des Joueurs")]
    [SerializeField]
    private Player[] player;

    [Space]
    [Header("Nombre de Carte de départ")]
    public int StartingCards = 0;

    [Space]
    [Header("PoolCards Script")]
    [SerializeField]
    private PoolCards poolCard;

    [Space]
    [Header("Temps de spawn en seconde")]
    [SerializeField]
    private float SpawnTime=3f;

    [Space]
    [Header("Nombre actuel d'avatar à l'écran")]
    public int currentCardNumberSpawn = 0;

    UnityEvent m_MyEvent;

    // Use this for initialization
    void Start()
    {

        poolCard.Init();
        for (int i =0;i < player.Length; i++)
        {
            for(int j = 0; j < StartingCards; j++)
            {
                player[i].AddCard(poolCard.GetCard());
            }
            
        }
        StartCoroutine(SpawnAvatarCoroutine());
        currentCardNumberSpawn = 0;
        if (m_MyEvent == null)
            m_MyEvent = new UnityEvent();
        m_MyEvent.AddListener(Supress);
    }

    public PoolCards getpoolScript()
    {
        return poolCard;
    }

    /// <summary>
    /// spawn an avatar time to time
    /// </summary>
    /// <returns></returns>
    IEnumerator SpawnAvatarCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(SpawnTime);
            for (int i = 0; i < player.Length; i++)
            {
               player[i].AddCard( poolCard.GetCard());
            }
            currentCardNumberSpawn += 4;
        }
    }


    void Supress()
    {
        currentCardNumberSpawn--;
    }

    public void InvokeSupress()
    {
        m_MyEvent.Invoke();
    }
}
