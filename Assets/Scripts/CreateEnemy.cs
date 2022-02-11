using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CreateEnemy : MonoBehaviour
{
    public List<GameObject> enemyPrefebs = new List<GameObject>();
    

    public void enemyCreate(int aa)
    {

    }
    private void Start()
    {
        StartCoroutine(createenemy());
        
    }

    IEnumerator createenemy()
    {
        while (true)
        {
            float t = Random.Range(MainSystem.randomTimeMin, MainSystem.randomTimeMax);
            GameObject enemy = Instantiate(enemyPrefebs[Random.Range(0, enemyPrefebs.Count)], transform.position, transform.rotation);
            if (Random.Range(0, 100) <= MainSystem.downper)
            {
            enemy.transform.position=new Vector3(enemy.transform.position.x,0.5f,enemy.transform.position.z);
            }
            yield return new WaitForSeconds(t);
            //StartCoroutine(createenemy(t));
        }
         
        
    }




}
