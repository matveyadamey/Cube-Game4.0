using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class PhotonIsMine : MonoBehaviour
{
    public controller controller;
    public manager manager;
    public CameraController camera;
    PhotonView view;
    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        if (view.IsMine)
        {
            controller.enabled = false;
            manager.enabled = false;
            camera.enabled = false;
        }
    }
}
