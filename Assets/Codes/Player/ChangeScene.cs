using System;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviourPun
{
    [SerializeField] private String WhereAmI;
    public LayerMask layerMask;
    bool isInDoor;
    String RoomName;
    private int id;
    private void Start()
    {
        id = this.gameObject.GetComponent<PhotonView>().ViewID;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isInDoor)
        {
            PhotonNetwork.LoadLevel(RoomName);
            photonView.RPC("NotificateOthersUAreNotInRoom", RpcTarget.All, WhereAmI, id);
            WhereAmI = RoomName;
        }

    }

    [PunRPC]
    public void StartGame()
    {
        WhereAmI = "ControlRoom";
        // PlayerList.Instance.list.Add(this.gameObject);
        PhotonNetwork.LoadLevel("ControlRoom");
    }
    [PunRPC]
    public void NotificateOthersUAreNotInRoom(String roomName, int id)
    {
        if (this.id == id) return;
        if (WhereAmI == roomName)
        {
            PhotonView photonView = PhotonView.Find(id);
            GameObject playerObject = photonView.gameObject;
            print(playerObject.name + " " + roomName);
            playerObject.SetActive(false);
        }
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
