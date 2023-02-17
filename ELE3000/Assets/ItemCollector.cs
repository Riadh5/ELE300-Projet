using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private int coins = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // detecte un collision entre le collider du player et du tag
        if (collision.gameObject.CompareTag("Coin"))
        {
            // d�truit l'objet apr�s collision
            Destroy(collision.gameObject);

            // ajoute une pi�ce au compteur 
            coins++;

            // affichage console
            Debug.Log("Coins : " + coins);
        }

        // Anti collision entre les clones
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("clone"))
        {
            Physics2D.IgnoreCollision(collision.GetComponent<CircleCollider2D>(), GetComponent<CircleCollider2D>());
            Physics2D.IgnoreCollision(collision.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
        }
    }
}
