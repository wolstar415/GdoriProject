using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainSystem : MonoBehaviour
{
    static public float speed;
    public float timespeed;
    public Text score;
    public GameObject score2;
    public GameObject HIscore;
    public Text HIscore2;
    public int scoretext;
    public float textspeed;
    public bool gameover;
    public PlayerController playerController;
    public GameObject restart;
    public int playerscore;
    static public int downper;
    public AudioSource audiosourece;
    public List<AudioClip> sound;
    public bool texteffect;
    static public float randomTimeMin= 1.8f;
    static public float randomTimeMax= 2.2f;
    void Start()  // 처음 시작시 실행되는 함수입니다.
    {
        //PlayerPrefs.SetInt("score", 0);
        randomTimeMin = 1.4f;
        randomTimeMax = 1.8f;
        timespeed = 0.07f;
           speed =8f;
        downper = 0;
        StartCoroutine(times());
        playerscore=PlayerPrefs.GetInt("score");
        if (playerscore >0)
        {
            HIscore.SetActive(true);
            HIscore2.text ="HI "+ playerscore.ToString("00000");
        }
    }
    IEnumerator texteff()
    {
        float f = 0.2f;
        texteffect = true;
        score2.SetActive(false);
         yield return new WaitForSeconds(f);
        score2.SetActive(true);
        yield return new WaitForSeconds(f);
        score2.SetActive(false);
        yield return new WaitForSeconds(f);
        score2.SetActive(true);
        yield return new WaitForSeconds(f);
        score2.SetActive(false);
        yield return new WaitForSeconds(f);
        score2.SetActive(true);
        texteffect = false;
    }
    public void scoreUp()
    {
        scoretext++;
        if (texteffect==false)
        {
        score.text=scoretext.ToString("00000");

        }
        if ((scoretext % 100)==0)
        {
            audiosourece.PlayOneShot(sound[0]);
            StartCoroutine(texteff());
        }
        switch (scoretext)
        {
            case 100:
                timespeed -= 0.005f;
                speed += 0.5f;
                downper = 10;
                break;
            case 200:
                speed += 1f;
                downper = 15;
                break;
            case 300:
                timespeed -= 0.005f;
                speed += 1f;
                downper = 20;
                break;
            case 400:
                speed += 1f;
                downper = 25;
                randomTimeMin -= 0.1f;
                randomTimeMax -= 0.1f;
                break;
            case 500:
                timespeed -= 0.005f;
                speed += 0.5f;
                downper = 30;
                break;
            case 600:
                speed += 0.5f;
                break;
            case 700:
                timespeed -= 0.005f;
                speed += 0.5f;

                break;
            case 800:
                timespeed -= 0.005f;
                speed += 0.5f;
                randomTimeMin -= 0.1f;
                randomTimeMax -= 0.1f;
                break;
            case 900:
                timespeed -= 0.005f;
                speed += 0.5f;
                break;
            case 1000:

                break;
            case 1100:

                break;
            case 1200:

                break;
            case 1300:

                break;
            case 1400:

                break;
            case 1500:
                break;
            case 2000:
                speed += 0.5f;
                break;
            case 2500:
                speed += 1f;
                timespeed -= 0.005f;
                randomTimeMin -= 0.1f;
                randomTimeMax -= 0.1f;
                break;
            case 3000:
                speed += 1f;
                break;
            case 3500:
                speed += 0.5f;
                break;
            case 4000:
                speed += 0.5f;
                randomTimeMin -= 0.1f;
                randomTimeMax -= 0.1f;
                break;
            case 4500:
                speed += 0.5f;
                randomTimeMin -= 0.1f;
                randomTimeMax -= 0.1f;
                break;
            case 5000:
                speed += 1f;
                randomTimeMin -= 0.1f;
                randomTimeMax -= 0.1f;
                break;
            case 5500:
                speed += 1f;

                break;
            default:
                break;
        }
    }
    public void Gameover()
    {
        gameover = true;
        StopAllCoroutines();
        audiosourece.PlayOneShot(sound[1]);
        speed = 0;
        playerController.animator.SetTrigger("hurt");
        playerController.animator.SetBool("dead", true);
        playerController.transform.position = new Vector3(playerController.transform.position.x, 0, playerController.transform.position.z);
        restart.SetActive(true);
        if (scoretext > playerscore)
        {
            PlayerPrefs.SetInt("score", scoretext);
            HIscore2.text = "HI " + playerscore.ToString("00000");
        HIscore.SetActive(true);
        }
    }

    IEnumerator times()
    {
        while (true)
        {
            float t = timespeed;
            Mathf.Clamp(t, 0.01f, 1);
            scoreUp();
            yield return new WaitForSeconds(t);
            //StartCoroutine(createenemy(t));
        }


    }
    public void Gamerestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
