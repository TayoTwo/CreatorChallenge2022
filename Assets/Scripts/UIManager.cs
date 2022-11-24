using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class UIManager : MonoBehaviourPunCallbacks
{

    public TMP_InputField createField;
    public TMP_InputField joinField;
    public TMP_Text youScore;
    public TMP_Text otherScore;
    public PlayerController localPlayer;
    ScoreManager scoreManager;

    void Start(){

        scoreManager = FindObjectOfType<ScoreManager>();

    }

    void LateUpdate(){

        if(scoreManager != null){

            UpdateUI();

        }

    }

    void UpdateUI(){

        youScore.text = localPlayer.score.ToString();
        otherScore.text = scoreManager.players.Find(x => x.gameObject != localPlayer.gameObject).score.ToString();

    }

    public void OnCreateRoomPressed(){

        PhotonNetwork.CreateRoom(createField.text);

    }

    public void OnJoinRoomPressed(){

        PhotonNetwork.JoinRoom(joinField.text);

    }

    public override void OnJoinedRoom(){

        Debug.Log("Joined room " + joinField.text);

        PhotonNetwork.LoadLevel("Game");

    }

}
