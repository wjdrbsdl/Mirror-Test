using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    //���� ������ �ð�������� ����
    enum RectengleLine
    {
        UpLine, RightLine, DownLine, LeftLine
    }

    //���ο� �°� �⺻ ���� �س��� 
    public Vector2[] nomalVectors = { Vector2.down, Vector2.left, Vector2.up, Vector2.right }; //�ݻ�Ǵ� ���� ���� ����

    public float rectSlope;

    private void Start()
    {
        CalSlope();
    }

    private void CalSlope()
    {
        //�簢���� 4 ������ ������ �� ���� �ð�������� üũ �س���. 
        float width = transform.localScale.x;
        float height = transform.localScale.y;

     //   Debug.Log("�ʱ� ���� ������ ���� ��� ����" + halfWidth + "����" + halfHeight);
        rectSlope = height / width;
    }

    public Vector2 ReflectBall(Transform _ballPos, Vector2 _come)
    {
        //�ε����� �� ���ܳ� ������ ���ؼ� ����
        Vector2 outVector = new Vector2();

        
        //�ε��� ���� ���ؼ� �������� ���� 
        float gapX = _ballPos.position.x - transform.position.x; 
        float gapY = _ballPos.position.y - transform.position.y;

        RectengleLine line;

        //  Debug.Log("�ε��� ��ġ������ ���ʹ�" + gapX + " ," + gapY);
        //�������� ���� ��� 
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
          //  Debug.Log("������ �ƴ� ��� ���⸦ ����"+ absolutSlope +"���� �������� �� "+mainSlope);
            if (rectSlope <= absolutSlope)
            {
          //  Debug.Log("������ ���Ⱑ ū ��� �� �ƴϸ� �Ʒ� ����");
                if (0 <= gapY)
                    line = RectengleLine.UpLine;
                else
                    line = RectengleLine.DownLine;
            }
            else
            {
          // ���Ⱑ ������ �¿� �鿡 ������
                if (0 <= gapX)
                    line = RectengleLine.RightLine;
                else
                    line = RectengleLine.LeftLine;
            }

        }

        //  Debug.Log("�ε��� ������ " + line);

        //�ݻ�� ���� ���ϱ� 

      //  Debug.Log("���� ���Ͱ�" + _come);
        float length = -1* Vector2.Dot(_come, nomalVectors[(int)line]);
      //  Debug.Log("������ �ʿ��� ���� " + length); //���� * ���� ������ ������ ���� 
       
        Vector2 longNomal = nomalVectors[(int)line] * length; //���� ���Ϳ� ���� ���̸� �̷�� ���ͻ���
        //Debug.Log("������ ���� " + longNomal);
        Vector2 direcLine = _come + longNomal; //���� ���� ��ġ���� �������� �׾����� ������ ��
        //Debug.Log("������ ���� " + direcLine);
        outVector = 2 * direcLine - _come; //������ �� 2��(�ݻ�Ǹ� 2��) ���� ���� ���͸� ���� �ݻ�Ǵ� ���� ����
        //Debug.Log("�ݻ�� ���� " + outVector);

        Vector2 test = _come - 2 * nomalVectors[(int)line] * (Vector2.Dot(_come, nomalVectors[(int)line])); //�� ������ �����ϰ� ������ ��
        //Debug.Log("���� ����" + test);

        Debug.Log("����ũ���� ����� �߰�");

        Debug.Log("����� üũ���� ����� �߰�");

        return outVector;
    }

    private void DeskMethodTest()
    {

    }

    private void DebugTestMethod()
    {

    }
}
