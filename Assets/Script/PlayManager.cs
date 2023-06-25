using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayManager : NetworkBehaviour
{
    [SerializeField] GameObject m_ball;

    private void Start()
    {
        Debug.Log("서버인가요 " + isServer);

        if (!isServer)
            return;

            Debug.Log("플레이매니저서 생성");
            GameObject ball = Instantiate(m_ball);
            NetworkServer.Spawn(ball);
        
    }
}
