using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// DONE

public class PlayerMovement : MonoBehaviour
{

    // Appel le controller & Animator dans le fichier
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;

    bool jump = false;


    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        // Donne une vitesse positive malgré la direction pour activer l'animation
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        // Confirme input Jump et lance l'animation
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);   
        }

    }

    public void OnLanding ()
    {
        // remet la valeur à 0 pour l'évenement d'atterissage
        animator.SetBool("IsJumping", false);

        // AJOUTER DÉLAI À ISJUMPING POUR LE FORCER

    }

    void FixedUpdate ()
    {
        // Jump = false aprés avoir sauté 
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);

        jump = false;
    }
}
