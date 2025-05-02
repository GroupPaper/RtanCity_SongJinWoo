using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameManager : MonoBehaviour
{
    public static MiniGameManager Instance { get; private set; }

    public GameObject maincamera;
    public GameObject minicamera;

    public GameObject player;
    public GameObject miniplayer;

    public GameObject gamemenu;
    public GameObject gameOver;

    public Button startButton;
    public Button restartButton;
    public Button exitButton;

    public BgLooper bgLooper;

    private List<Transform> backgroundObjects = new List<Transform>();
    private List<Vector3> backgroundInitialPositions = new List<Vector3>();

    private List<Obstacle> obstacleObjects = new List<Obstacle>();
    private List<Vector3> obstacleInitialPositions = new List<Vector3>();

    private int score = 0;
    private int bestscore = 0;

    public Text scoreText;
    public Text bestScoreText;

    public bool isStop;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        bestscore = PlayerPrefs.GetInt("BestScore", 0);

        restartButton.onClick.AddListener(ReStartGame);
        exitButton.onClick.AddListener(ExitMiniGame);

        // ��� �ʱ�ȭ
        GameObject[] backgrounds = GameObject.FindGameObjectsWithTag("BackGround");
        foreach (var bg in backgrounds)
        {
            backgroundObjects.Add(bg.transform);
            backgroundInitialPositions.Add(bg.transform.position);
        }

        // ��ֹ� �ʱ�ȭ
        Obstacle[] obstacles = FindObjectsOfType<Obstacle>();
        foreach (var obs in obstacles)
        {
            obstacleObjects.Add(obs);
            obstacleInitialPositions.Add(obs.transform.position);
        }
    }

    private void Update()
    {
        if (isStop)
        {
            scoreText.text = score.ToString();
        }
    }

    public void GameMenu()
    {
        startButton.onClick.AddListener(GameStart);
        gamemenu.SetActive(true);

        isStop = false;
        Time.timeScale = 0f; // ������ ����
    }

    public void GameStart()
    {
        gamemenu.SetActive(false);

        isStop = true;
        Time.timeScale = 1f; // ������ ����
    }

    public void GameOver()
    {
        gameOver.SetActive(true);

        if(score >= bestscore)
        {
            bestscore = score;
            PlayerPrefs.SetInt("BestScore", bestscore); // ����
        }

        bestScoreText.text = $"{bestscore}";
    }

    public void AddScore(int value)
    {
        score += value;
    }

    public void ReStartGame()
    {
        miniplayer = GameObject.FindGameObjectWithTag("MiniPlayer");
        miniplayer.transform.position = new Vector3(0f, -50f, miniplayer.transform.position.z);

        Animator animator = miniplayer.GetComponent<Animator>();

        if (animator)
        {
            animator.SetTrigger("Idle");
        }

        score = 0;
        gameOver.SetActive(false);
        MiniGameController.isDead = false;

        // ��� ��ġ �ʱ�ȭ
        for (int i = 0; i < backgroundObjects.Count; i++)
        {
            backgroundObjects[i].position = backgroundInitialPositions[i];
        }

        // ��ֹ����� ���ġ
        for (int i = 0; i < obstacleObjects.Count; i++)
        {
            Vector3 newPosition = obstacleInitialPositions[i];
            newPosition.x += 25f; // ���ġ�� X ���� ����
            obstacleObjects[i].transform.position = newPosition;
        }

        scoreText.text = "0";
    }

    public void ExitMiniGame()
    {
        miniplayer.SetActive(false);
        minicamera.SetActive(false);

        player.SetActive(true);
        maincamera.SetActive(true);

        gameOver.SetActive(false);
        scoreText.text = "";
    }
}