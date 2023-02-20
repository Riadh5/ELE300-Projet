using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRandomizer : MonoBehaviour
{
    public float accelerationTime = 2f;
    private Vector2 movement;
    private float timeLeft;
    public float runSpeed = 40f;

    public CharacterController2D controller;
    public Animator animator;

    bool jump = false;

    void Update()
    {
        timeLeft -= Time.deltaTime;

        bool Boolean = (Random.value > 0.5f);

        //Randomizer
 
        if (timeLeft <= 0)
        {
            jump = Boolean;

            movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));

            timeLeft += accelerationTime;
        }

        //Animator stuff
        if (jump == true)
        {
            animator.SetBool("IsJumping", true);
        }
        else
        {
            animator.SetBool("IsJumping", false);
        }

        if (movement[0] > 0.01f)
        {
            animator.SetFloat("Speed", Mathf.Abs(movement[0]));
        }
        else
        {
            animator.SetFloat("Speed", Mathf.Abs(movement[0]));
        }

    }

    void FixedUpdate()
    {
        controller.Move(movement[0] * Time.fixedDeltaTime * runSpeed, false, jump);
        jump = false;
    }

    public void OnLanding()
    {
        // remet la valeur à 0 pour l'évenement d'atterissage
        animator.SetBool("IsJumping", false);

    }

}
