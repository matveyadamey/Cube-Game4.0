using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
public class ChangeMod : MonoBehaviourPunCallbacks
{
    public void Online()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinRandomRoom();
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        print(returnCode+""+ message);
    }
    public override void OnJoinedRoom()
    {
        SceneManager.LoadScene("Game");
    }
}

