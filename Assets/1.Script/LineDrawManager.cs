using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawManager : MonoBehaviour // 라인 그리는 기능 매니저
{
    public static LineDrawManager instance;
    private LineRenderer ln;
    void Start()
    {
        if (instance != this)
            instance = this;
    }

    public void LineDraw(LineRenderer lr, Vector2 startPos, Vector2 endPos)
    {
        ln = lr;
        ln.SetPosition(0, startPos);
        ln.SetPosition(1, endPos);
    }

    public void LineDraw(LineRenderer lr, Vector2 startPos, Vector2 endPos, float sw, float ew)
    {
        ln = lr;
        ln.startWidth = sw;
        ln.endWidth = ew;
        ln.SetPosition(0, startPos);
        ln.SetPosition(1, endPos);
    }

    public void LineDraw(LineRenderer lr, Vector2 startPos, Vector2 endPos, float sw, float ew, Color c)
    {
        ln = lr;
        ln.startWidth = sw;
        ln.endWidth = ew;
        ln.startColor = c;
        ln.endColor = c;
        ln.SetPosition(0, startPos);
        ln.SetPosition(1, endPos);
    }

    public void LineOff()
    {
        ln = null;
    }

    //public void LineDraw(Vector2 incline,Vector2 startPos, Vector2 endPos, float sw, float ew)
    //{
    //    ldf.LineDraw
    //}

}