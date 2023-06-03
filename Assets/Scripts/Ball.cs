using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    GameController gameController;

    private void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameController.upScore();
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeathZone"))
        {
            GameObject[] gameObjects = FindObjectsOfType<GameObject>();
            foreach(GameObject gameObject in gameObjects)
            {
                if (gameObject.tag.Equals("Ball"))
                {
                    Destroy(gameObject);
                }
            }
            gameController.setGameOver(true);
        }
    }
}
