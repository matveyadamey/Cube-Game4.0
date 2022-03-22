using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerCount : MonoBehaviour
{
    public GameObject WaitingText;
    public timer script3;
    private void Start()
    {
        script3.timeStart = false;
    }
    void Update()
    {
        if (PhotonNetwork.PlayerList.Length>0)
        {
            WaitingText.SetActive(false);
            script3.timeStart = true;
        }
    }
}
