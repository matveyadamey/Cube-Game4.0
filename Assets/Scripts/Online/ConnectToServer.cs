/*
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
public class ConnectToServer : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    public void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }
    public override void OnJoinedLobby()
    {
        SceneManager.LoadScene("lobby");
    }
}
*/