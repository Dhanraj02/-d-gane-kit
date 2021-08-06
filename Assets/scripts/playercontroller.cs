using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playercontroller : MonoBehaviour
{
    public Animator animator;
    public Scorecontroller scorecontroller;
    public gameovercontroller Gameovercontroller;
    public float speed;
    public float jump;
    private Rigidbody2D rb2d;
    private void Awake()
    {
        Debug.Log("player awake");
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    public void KillPlayer()
    {
        Debug.Log("player killed by enemy");
        Gameovercontroller.PlayerDied();
        this.enabled = false;
        animator.SetBool("Die", true);
        
    }

    

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
        PlayMovementAnimation(horizontal, vertical);
        MoveCharacter(horizontal, vertical);
        bool crouch = Input.GetKey(KeyCode.LeftControl);
        CrouchAnimation(crouch);
    }

    private void CrouchAnimation(bool crouch)
    {
        bool Crouch = Input.GetKey(KeyCode.LeftControl);
        if(Crouch)
        {
            animator.SetBool("Crouch", true);
        }
        else
        {
            animator.SetBool("Crouch", false);
        }
    }

    public void PickUpKey()
    {
        Debug.Log("player picked the key");
        scorecontroller.IncreaseScore(10);
    }

    private void MoveCharacter(float horizontal, float vertical)
    {
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

        if(vertical > 0)
        {
            rb2d.AddForce(new Vector2(0f, jump),ForceMode2D.Force);
        }
    }

    private void PlayMovementAnimation(float horizontal, float vertical)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
        if (vertical > 0)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
          
    }
}
