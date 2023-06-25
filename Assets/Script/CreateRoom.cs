using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CreateRoom : MonoBehaviour
{
    public MirrorRoomManager m_manager;

    public List<Transform> m_spawnTransForm = new List<Transform>();

    public void StartHost()
    {
        Debug.Log("호스트 시작");
        m_manager.StartHost();
    }
    public void LinkRoom()
    {
        Debug.Log("클라이언트 시작");
        m_manager.StartClient();
    }
}
