using UnityEngine;

public class PipeBehavior : MonoBehaviour
{
    private AudioSource audioSource;

    private float velocity;
    private float minPositionX;
    private float initialPositionX;
    public float minPositionY = -1.78f;
    public float maxPositionY = 2.47f;

    private int score;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        minPositionX = GameBehavior.gameBehavior.minPositionX;
        initialPositionX = GameBehavior.gameBehavior.initialPositionX;
    }

    private void Update()
    {
        velocity = GameBehavior.gameBehavior.currentVelocity;
        //Vector2.Left == new Vector2 (-1, 0) - Se move para esquerda em 1 unidade
        transform.Translate(Vector2.left * velocity * Time.deltaTime);

        if (transform.position.x < minPositionX)
        {
            Vector2 newPosition =
                new Vector2(initialPositionX, SetRandomYPosition());
            transform.position = newPosition;
        }
    }

    private float SetRandomYPosition()
    {
        return Random.Range(minPositionY, maxPositionY);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        audioSource.Play();
        score++;
        GameBehavior.gameBehavior.UpdateScoreUI(score);
    }
}
