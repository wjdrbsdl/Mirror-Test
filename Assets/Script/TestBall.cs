using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBall : MonoBehaviour
{
    public Vector2 moveVector = new Vector2(1, 1);
    public GameObject m_target;
    public float speed = 10;
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 direc = moveVector;
        direc = direc.normalized * speed * Time.deltaTime;
        transform.Translate(direc);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Wall colliededWall = collision.gameObject.GetComponent<Wall>();
        if (colliededWall == null)
        {
            Debug.LogError("벽이 아닌 것과 부딪혔음");
            return;
        }

        moveVector = colliededWall.ReflectBall(transform, moveVector);
        Debug.Log("톨토이즈 테스트!");
    }

    
}
