using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRandomizer : MonoBehaviour
{
    public Rigidbody2D rb;
    public float accelerationTime = 2f;
    public float maxSpeed = 5f;
    private Vector2 movement;
    private float timeLeft;

    public CharacterController2D controller;
    public Animator animator;

    bool jump = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        timeLeft -= Time.deltaTime;

        bool Boolean = (Random.value > 0.5f);

        //Randomizer
        if (timeLeft <= 0)
        {
            jump = Boolean;

            movement = new Vector2(Random.Range(-2f, 2f), Random.Range(-1f, 1f));

            controller.Move(movement[0], false, jump);

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

        jump = false;

    }

    void FixedUpdate()
    {
        rb.AddForce(movement * maxSpeed);
    }

    public void OnLanding()
    {
        // remet la valeur à 0 pour l'évenement d'atterissage
        animator.SetBool("IsJumping", false);

        // AJOUTER DÉLAI À ISJUMPING POUR LE FORCER

    }

}
