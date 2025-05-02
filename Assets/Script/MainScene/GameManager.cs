using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public Button warp1;
    public Button warp2;
    public Button warp3;
    public Button warp4;
    public Button warp5;
    public Button warp6;

    private void Start()
    {
        warp1.onClick.AddListener(Warp1);
        warp2.onClick.AddListener(Warp2);
        warp3.onClick.AddListener(Warp3);
        warp4.onClick.AddListener(Warp4);
        warp5.onClick.AddListener(Warp5);
        warp6.onClick.AddListener(Warp6);
    }

    private void Warp1()
    {
        player.transform.position = new Vector3(-13f, 3f, player.transform.position.z);
    }

    private void Warp2()
    {
        player.transform.position = new Vector3(-12f, -4.5f, player.transform.position.z);
    }

    private void Warp3()
    {
        player.transform.position = new Vector3(-17f, 7f, player.transform.position.z);
    }

    private void Warp4()
    {
        player.transform.position = new Vector3(16f, 7f, player.transform.position.z);
    }

    private void Warp5()
    {
        player.transform.position = new Vector3(-16f, -9f, player.transform.position.z);
    }

    private void Warp6()
    {
        player.transform.position = new Vector3(16f, -9f, player.transform.position.z);
    }
}
