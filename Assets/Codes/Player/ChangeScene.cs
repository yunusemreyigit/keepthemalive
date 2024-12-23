using System;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviourPun
{
    public LayerMask layerMask;
    bool isInDoor;
    String RoomName;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isInDoor)
        {
            PhotonNetwork.LoadLevel(RoomName);
        }

    }

    [PunRPC]
    public void StartGame(){
        PhotonNetwork.LoadLevel("ControlRoom");
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Door") && ((1 << other.gameObject.layer) & layerMask) != 0)
        {
            isInDoor = true;
            RoomName = other.gameObject.name;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Door") && ((1 << other.gameObject.layer) & layerMask) != 0)
        {
            isInDoor = false;
            RoomName = "";
        }
    }
}
