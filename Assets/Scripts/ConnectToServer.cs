using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    public void OnStartPressed()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Connected using settings!");
    }

    public override void OnConnectedToMaster()
    {

        PhotonNetwork.JoinLobby();
        
    }

    public override void OnJoinedLobby()
    {

        Debug.Log("Joined a lobby");
        SceneManager.LoadScene("Lobby");
    }

}
