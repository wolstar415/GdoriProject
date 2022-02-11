using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public bool jump;
    public bool downjump;
    public float jumpSpeed;
    public float jumpmax;
    public bool down;
    public bool downA;
    public MainSystem mainSystem;
   
    void Start()  // 처음 시작시 실행되는 함수입니다.
    {
        
    }

    
    void Update() // 매 프레임마다 실행되는 함수입니다.
    {
        if (mainSystem.gameover)
        {
            return;
        }

        if ((Input.GetKey(KeyCode.Space)|| Input.GetKey(KeyCode.UpArrow))&&animator.GetBool("grounded") ==true)
        {
            animator.SetBool("grounded", false);
            jump = true;
            mainSystem.audiosourece.PlayOneShot(mainSystem.sound[2]);
        }
        if (jump)
        {
            transform.Translate( 0, jumpSpeed*Time.deltaTime, 0);
            if (transform.position.y >= jumpmax)
            {
                jump = false;
                downjump = true;
            }
        }
        if (downjump)
        {
            if (down)
                transform.Translate(0, -jumpSpeed * Time.deltaTime*2f, 0);
            else
                transform.Translate(0, -jumpSpeed * Time.deltaTime, 0);
        }

        if (animator.GetBool("grounded") == false && transform.position.y <= 0)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            animator.SetBool("grounded", true);
            jump = false;
            downjump = false;
        }

        if ((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.DownArrow)))
        {
            down = true;
            if (jump)
            {
                jump = false;
                downjump = true;
            }
        }
        if (transform.position.y == 0 && down)
        {
            downA = true;
            animator.SetFloat("velocityX", 0f);
            transform.rotation = Quaternion.Euler(0, 0, -90);
            transform.position = new Vector3(transform.position.x, -0.5f, transform.position.z);
        }
        if ((Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.DownArrow))&&down)
        {
            down = false;
            if (downA)
            {

            downA = false;
            animator.SetFloat("velocityX", 1f);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
            }
        }
    }
}
