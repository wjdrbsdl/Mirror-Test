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

    public float mainSlope;

    private void Start()
    {
        CalVertax();
    }

    private void CalVertax()
    {
        //�簢���� 4 ������ ������ �� ���� �ð�������� üũ �س���. 
        float width = transform.localScale.x;
        float height = transform.localScale.y;

     //   Debug.Log("�ʱ� ���� ������ ���� ��� ����" + halfWidth + "����" + halfHeight);
        mainSlope = height / width;
    }

    public Vector2 ReflectBall(Transform _ballPos, Vector2 _come)
    {
        Vector2 outVector = new Vector2();

        //�ε����� �� ���ܳ� ������ ���ؼ� ����
        float gapX = _ballPos.position.x - transform.position.x; 
        float gapY = _ballPos.position.y - transform.position.y;

        RectengleLine line;

      //  Debug.Log("�ε��� ��ġ������ ���ʹ�" + gapX + " ," + gapY);
        //�������� ���� ��� 
        if (gapX == 0)
        {
            if (0 <= gapY)
            {
                line = RectengleLine.UpLine;
           //     Debug.Log("���򿡼� �ε��� ��� ����");
            }
            else
            {
                line = RectengleLine.DownLine;
            //    Debug.Log("���򿡼� �ε��� ��� ����");
            }
                
        }
        else
        {
            
            float absolutSlope = Mathf.Abs( gapY / gapX);
         //   Debug.Log("������ �ƴ� ��� ���⸦ ����"+ absolutSlope +"���� �������� �� "+mainSlope);
            if (mainSlope <= absolutSlope)
            {
          //      Debug.Log("������ ���� �������� �� ū ��� �� �ƴϸ� �Ʒ� ����");
                if (0 <= gapY)
                    line = RectengleLine.UpLine;
                else
                    line = RectengleLine.DownLine;
            }
            else
            {
          //      Debug.Log("������ ���� �������� �� ���� ��� ���� �ƴϸ� ������");
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
        Debug.Log("����� üũ���� ����� �߰�");
        return outVector;
    }
}
