using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletType : MonoBehaviour
{

    public GameObject parentObj;

    void Start()
    {
        
    }

    void OnEnable()
    {
        PatternManager.sinAction += MovePos;
    }

    public virtual void MovePos() { } // ���� ���� ����


}
