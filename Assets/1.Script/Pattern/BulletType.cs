using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletType : MonoBehaviour
{

    protected LineRenderer lr;
    protected Vector2 curPos, nextPos, startPos;
    float expandNum; // 선이 천천히 길어지게 만들려고 함

    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    void OnEnable()
    {
        PatternManager.Action += MovePos;
    }

    public virtual void MovePos() { } // 패턴 무빙 구현

    public virtual void LineSlide() { } // 접선 구현

    protected IEnumerator LineExpand(Vector2 dirvec) //선이 점점 커지는 코루틴
    {
        float xValue = 0.0f; // 이차함수 밸류 변수
        while (true)
        {
            
            expandNum = Mathf.Pow(xValue, 2);
            yield return new WaitForSeconds(0.01f);
            //LineDrawManager.instance.LineDraw(lr, curPos - dirvec * expandNum, curPos + dirvec * expandNum, 0.05f, 0.05f, new Color(255, 255, 255));
            //if (-5.0f >= transform.TransformDirection((curPos - dirvec * expandNum)).x && 5.0f <= transform.TransformDirection((curPos + dirvec * expandNum)).x )
            //    break;
            //if (-8.0f >= transform.TransformDirection((curPos - dirvec * expandNum)).y && 8.0f <= transform.TransformDirection((curPos + dirvec * expandNum)).y )
            //    break;
            LineDrawManager.instance.LineDraw(lr, startPos - dirvec * expandNum, startPos + dirvec * expandNum, 0.05f, 0.05f, new Color(255, 255, 255));
            if ((-8.0f >= (startPos - dirvec * expandNum).x && 8.0f <= (startPos + dirvec * expandNum).x)
                || (-5.0f >= (startPos - dirvec * expandNum).y && 5.0f <= (startPos + dirvec * expandNum).y)
                || (-8.0f >= (startPos + dirvec * expandNum).x && 8.0f <= (startPos - dirvec * expandNum).x)
                || (-5.0f >= (startPos + dirvec * expandNum).y && 5.0f <= (startPos - dirvec * expandNum).y)
                )
                break;
            xValue += 0.1f;
        }
        yield return new WaitForSeconds(2.0f);
        PatternManager.Action -= MovePos;
        gameObject.SetActive(false);
    }

}
