using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    //벽의 선분을 시계방향으로 정의
    enum RectengleLine
    {
        UpLine, RightLine, DownLine, LeftLine
    }

    //라인에 맞게 기본 벡터 해놓고 
    public Vector2[] nomalVectors = { Vector2.down, Vector2.left, Vector2.up, Vector2.right }; //반사되는 법선 벡터 방향

    public float rectSlope;

    private void Start()
    {
        CalSlope();
    }

    private void CalSlope()
    {
        //사각형의 4 정점을 오른쪽 위 부터 시계방향으로 체크 해놓음. 
        float width = transform.localScale.x;
        float height = transform.localScale.y;

     //   Debug.Log("초기 매인 슬로프 기울기 계산 가로" + halfWidth + "세로" + halfHeight);
        rectSlope = height / width;
    }

    public Vector2 ReflectBall(Transform _ballPos, Vector2 _come)
    {
        //부딪혔을 때 퉁겨낼 방향을 구해서 리턴
        Vector2 outVector = new Vector2();

        
        //부딪힌 면을 구해서 법선벡터 도출 
        float gapX = _ballPos.position.x - transform.position.x; 
        float gapY = _ballPos.position.y - transform.position.y;

        RectengleLine line;

        //  Debug.Log("부딪힌 위치에서의 벡터는" + gapX + " ," + gapY);
        //수평으로 꽂힌 경우 
        if (gapX == 0)
        {
            if (0 <= gapY)
                line = RectengleLine.UpLine;
            else
                line = RectengleLine.DownLine;
                
        }
        else
        {
            
            float absolutSlope = Mathf.Abs( gapY / gapX);
          //  Debug.Log("수평이 아닌 경우 기울기를 구함"+ absolutSlope +"절대 슬로프와 비교 "+mainSlope);
            if (rectSlope <= absolutSlope)
            {
          //  Debug.Log("구와의 기울기가 큰 경우 위 아니면 아래 라인");
                if (0 <= gapY)
                    line = RectengleLine.UpLine;
                else
                    line = RectengleLine.DownLine;
            }
            else
            {
          // 기울기가 작으면 좌우 면에 맞은것
                if (0 <= gapX)
                    line = RectengleLine.RightLine;
                else
                    line = RectengleLine.LeftLine;
            }

        }

        //  Debug.Log("부딪힌 라인은 " + line);

        //반사된 벡터 구하기 

      //  Debug.Log("들어온 벡터값" + _come);
        float length = -1* Vector2.Dot(_come, nomalVectors[(int)line]);
      //  Debug.Log("투영에 필요한 길이 " + length); //법선 * 같이 나가는 방향의 벡터 
       
        Vector2 longNomal = nomalVectors[(int)line] * length; //들어온 벡터와 직각 길이를 이루는 벡터생성
        //Debug.Log("투영된 법선 " + longNomal);
        Vector2 direcLine = _come + longNomal; //들어온 벡터 위치에서 수평으로 그어지는 가상의 선
        //Debug.Log("가상의 법선 " + direcLine);
        outVector = 2 * direcLine - _come; //가상의 선 2배(반사되면 2배) 에서 들어온 벡터를 빼서 반사되는 벡터 산출
        //Debug.Log("반사된 벡터 " + outVector);

        Vector2 test = _come - 2 * nomalVectors[(int)line] * (Vector2.Dot(_come, nomalVectors[(int)line])); //위 과정을 대입하고 정리된 식
        //Debug.Log("계산된 벡터" + test);

        Debug.Log("데스크에서 디버그 추가");

        Debug.Log("디버그 체크에서 디버그 추가");

        return outVector;
    }

    private void DeskMethodTest()
    {

    }

    private void DebugTestMethod()
    {

    }
}
