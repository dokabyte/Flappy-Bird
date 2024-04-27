using UnityEngine;

public class FloorTopBehavior : MonoBehaviour
{
    private float velocity;
    private float minPositionX;
    private float initialPositionX;

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
                new Vector2(initialPositionX, transform.position.y);
            transform.position = newPosition;
        }
    }
}
