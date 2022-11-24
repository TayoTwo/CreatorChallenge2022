using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public List<PlayerController> players;

    public void OnPlayerJoin(PlayerController p){

        players.Add(p);

        for(int i = 0; i < players.Count;i++){

            players[i].score = 0;

        }

    }

    public void OnPlayerLeave(PlayerController p){

        players.Remove(p);

        for(int i = 0; i < players.Count;i++){

            players[i].score = 0;

        }

    }   

}
