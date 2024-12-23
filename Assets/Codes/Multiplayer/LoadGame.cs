using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class LoadGame : MonoBehaviourPun
{
    private void Update()
    {
        if (photonView.IsMine && PhotonNetwork.IsMasterClient)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                photonView.RPC("StartGame", RpcTarget.All);
            }
        }
    }
}
