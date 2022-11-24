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
