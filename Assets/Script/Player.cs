
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;


public class Player : NetworkBehaviour
{
    public bool isMine;
    public float m_speed = 3f;
    public override void OnStartClient()
    {
        base.OnStartClient();
        isMine = isOwned;
    }
    

    private void Update()
    {
        if (!isOwned)
            return;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector3 move = Vector3.up;
            transform.Translate(move * Time.deltaTime*m_speed);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Vector3 move = Vector3.down;
            transform.Translate(move * Time.deltaTime*m_speed);
        }
    }
}
