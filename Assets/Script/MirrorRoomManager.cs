using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MirrorRoomManager : NetworkRoomManager
{
    string scenName = "Assets/Scenes/PlayScene.unity";
    GameObject m_ball;


    public override void OnServerChangeScene(string newSceneName)
    {
        //Debug.Log(newSceneName);
        //if (newSceneName == scenName)
        //{
        //    Debug.Log("Ȥ�ö� ������ ������ ���� ���");
        //    m_ball = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "Ball"));
        //    NetworkServer.Spawn(m_ball);
        //}
    }
}
