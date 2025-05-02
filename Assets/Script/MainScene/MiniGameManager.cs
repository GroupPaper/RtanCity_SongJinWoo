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

    public GameObject gameOver;
    public Button restartButton;
    public Button exitButton;

    public BgLooper bgLooper;

    private List<Transform> backgroundObjects = new List<Transform>();
    private List<Vector3> backgroundInitialPositions = new List<Vector3>();

    private List<Obstacle> obstacleObjects = new List<Obstacle>();
    private List<Vector3> obstacleInitialPositions = new List<Vector3>();

    private int score = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        restartButton.onClick.AddListener(ReStartGame);
        exitButton.onClick.AddListener(ExitMiniGame);

        // 배경 초기화
        GameObject[] backgrounds = GameObject.FindGameObjectsWithTag("BackGround");
        foreach (var bg in backgrounds)
        {
            backgroundObjects.Add(bg.transform);
            backgroundInitialPositions.Add(bg.transform.position);
        }

        // 장애물 초기화
        Obstacle[] obstacles = FindObjectsOfType<Obstacle>();
        foreach (var obs in obstacles)
        {
            obstacleObjects.Add(obs);
            obstacleInitialPositions.Add(obs.transform.position);
        }
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
    }

    public void AddScore(int value)
    {
        score = value;
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

        // 배경 위치 초기화
        for (int i = 0; i < backgroundObjects.Count; i++)
        {
            backgroundObjects[i].position = backgroundInitialPositions[i];
        }

        // 장애물들을 원래 위치로 되돌리기
        for (int i = 0; i < obstacleObjects.Count; i++)
        {
            obstacleObjects[i].transform.position = obstacleInitialPositions[i];
        }
    }

    public void ExitMiniGame()
    {
        miniplayer.SetActive(false);
        minicamera.SetActive(false);

        player.SetActive(true);
        maincamera.SetActive(true);

        gameOver.SetActive(false);
    }
}