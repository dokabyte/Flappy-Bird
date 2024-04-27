using UnityEngine;
using UnityEngine.UI;

public class GameBehavior : MonoBehaviour
{
    public static GameBehavior gameBehavior;

    public Sprite[] pointImages;
    public Image pointDecimal;
    public Image pointUnit;
    public Image gameOverImage;
    public Image gameStartImage;

    public float gameVelocity;
    public float minPositionX = -4.3f;
    public float initialPositionX = 4.3f;
    public bool gameOver = false;
    public float currentVelocity;

    private float initialVelocity = 0;
    private bool gameStarted = false;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        currentVelocity = initialVelocity;
        gameBehavior = this;
        SetEnableGameOverUI(false);
        gameStartImage.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && gameStarted == false)
        {
            gameStarted = true;
            audioSource.Play();
            currentVelocity = gameVelocity;
            gameStartImage.gameObject.SetActive(false);
        }
    }

    public void UpdateScoreUI(int score)
    {
        int unit = score % 10;
        int decimalPoint = score / 10;

        pointDecimal.sprite = pointImages[decimalPoint];
        pointUnit.sprite = pointImages[unit];
    }

    public void GameOver()
    {
        //Vamos avisar aos outros Scripts com nome behavior que o jogador perdeu
        gameOver = true;
        currentVelocity = 0;
        SetEnableGameOverUI(true);
    }

    private void SetEnableGameOverUI(bool enable)
    {
        gameOverImage.gameObject.SetActive(enable);
    }
}
