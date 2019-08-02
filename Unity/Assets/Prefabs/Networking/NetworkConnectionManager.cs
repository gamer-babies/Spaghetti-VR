using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Assets.Prefabs.Networking
{
    class NetworkConnectionManager : MonoBehaviourPunCallbacks
    {
        void Start()
        {
            PhotonNetwork.OfflineMode = false;
            PhotonNetwork.NickName = "Player";
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.GameVersion = "v1";
            PhotonNetwork.ConnectUsingSettings();
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            base.OnDisconnected(cause);
            Debug.Log(cause);
        }

        public override void OnConnectedToMaster()
        {
            base.OnConnectedToMaster();
            Debug.Log("Connected to master!");

            // Examples:
            // PhotonNetwork.CreateRoom("Unique room name");
            // PhotonNetwork.JoinOrCreateRoom("Unique room name");
            // PhotonNetwork.JoinRoom("Unique room name");
            PhotonNetwork.JoinRandomRoom();
        }

        public override void OnJoinedRoom()
        {
            base.OnJoinedRoom();
            Debug.Log("Master: " + PhotonNetwork.IsMasterClient + " | Players in room: " + PhotonNetwork.CurrentRoom.PlayerCount);
        }

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            base.OnJoinRandomFailed(returnCode, message);
            // No room available, create a room
            PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 2 });
        }
    }
}
