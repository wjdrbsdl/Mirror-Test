using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayManager : NetworkBehaviour
{
    [SerializeField] GameObject m_ball;

    private void Start()
    {
        Debug.Log("�����ΰ��� " + isServer);

        if (!isServer)
            return;

            Debug.Log("�÷��̸Ŵ����� ����");
            GameObject ball = Instantiate(m_ball);
            NetworkServer.Spawn(ball);
        
    }
}
