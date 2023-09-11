using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool isGameOver;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    void Start(){
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void StartGame()
    {

    }

    public void GameOver(bool flag)
    {
        isGameOver = flag;
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }
}
