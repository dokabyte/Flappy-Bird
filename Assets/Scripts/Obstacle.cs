using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private AudioSource audiosource;

    private void Awake()
    {
        audiosource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameBehavior.gameBehavior.gameOver == false)
        {
            audiosource.Play();
            GameBehavior.gameBehavior.GameOver();
        }
    }
}
