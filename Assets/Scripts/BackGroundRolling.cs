using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundRolling : MonoBehaviour
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
        background.Translate(-MainSystem.speed * Time.deltaTime,0,0);
        if (background.position.x < checkx)
            background.position = rePosition;
    }
}
