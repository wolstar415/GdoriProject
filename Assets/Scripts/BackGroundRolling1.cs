using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundRolling1 : MonoBehaviour
{
    Transform background;
    public float rollingSpeed;
    public Vector3 rePosition;
        public float checkx;
    void Start()  // 처음 시작시 실행되는 함수입니다.
    {
        background = GetComponent<Transform>();
    }

    
    void Update() // 매 프레임마다 실행되는 함수입니다.
    {
        if (MainSystem.speed == 0)
        {
            return;
        }
        background.Translate(-2.5f * Time.deltaTime,0,0);
        if (background.position.x < checkx)
            background.position = rePosition;
    }
}
