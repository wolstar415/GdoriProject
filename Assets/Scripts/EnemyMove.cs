using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    void Update() // 매 프레임마다 실행되는 함수입니다.
    {
        transform.Translate(-MainSystem.speed * Time.deltaTime, 0, 0);
        if (transform.position.x < -30)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag=="Player")
        {
            GameObject.Find("MainSystem").GetComponent<MainSystem>().Gameover();
            Destroy(gameObject);
        }
    }
}
