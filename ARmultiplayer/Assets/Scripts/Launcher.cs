using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
public class Launcher : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_InputField nameofroom;
    [SerializeField] TMP_Text errormesage;
    [SerializeField] TMP_Text roomname;
    void Start()
    {
        Debug.Log("connecting to master");
        PhotonNetwork.ConnectUsingSettings();//use to connect with ther photon master server;

    }
     
    
    public override void OnConnectedToMaster() //funtions replay that you are connected to server
    {
        Debug.Log("connected to the master");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        menumanger.Instance.OpenMenu("title");
        Debug.Log("joined ton the lobby");
    }

    public void CreatRoom()
    {
        if (string.IsNullOrEmpty(nameofroom.text))
        {
            return;
        }
        PhotonNetwork.CreateRoom(nameofroom.text);
        menumanger.Instance.OpenMenu("loading");
    }

    public override void OnJoinedRoom()
    {
        menumanger.Instance.OpenMenu("room");
        roomname.text = PhotonNetwork.CurrentRoom.Name;
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        errormesage.text = "Error due to  " + message;
        menumanger.Instance.OpenMenu("error");
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        menumanger.Instance.OpenMenu("loading");

    }
    public override void OnLeftRoom()
    {
        menumanger.Instance.OpenMenu("title");
    }
}
