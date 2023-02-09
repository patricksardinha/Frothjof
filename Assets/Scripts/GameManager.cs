using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private MapGenerator mapGeneratorScript;


    void Start()
    {
        mapGeneratorScript = GetComponent<MapGenerator>();


        StartGame();
    }

    void StartGame()
    {
        mapGeneratorScript.GenerateMap();
    }

}
