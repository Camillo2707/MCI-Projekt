using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private static GameMaster instance;
    public Vector2 lastCheckPointPos;
    public bool doubleJumpCollected = false;
    private PlayerMove2 player;
    public GameObject DoubleJumpPickup;
    public static bool collected = false;
    public GameObject Tutorial;
    public GameObject Plattform;
    public GameObject Plattform2;
    public GameObject DirectionText;
    void Awake()
    {
        player = FindObjectOfType<PlayerMove2>();
        DoubleJumpPickup = GameObject.Find("DoubleJumpPickup");
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance); 
        }
        else
        {
            Destroy(gameObject);
        }
        
        if (collected == true)
        {
            player.extraJumpsValue = 1;
            DoubleJumpPickup.SetActive(false);  
            Tutorial.SetActive(true);
            Plattform.SetActive(true);
            Plattform2.SetActive(true);
            DirectionText.SetActive(true);
        }
    }

    void Update()
    {
        if (doubleJumpCollected == true)
        {
            collected = true;
        }
    }
}
