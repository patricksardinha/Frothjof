using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField]
    private int[] sizeMainArea;

    [SerializeField]
    private GameObject[] mainAreaGroundPrefabs;
    [SerializeField]
    private GameObject[] sideAreaGroundPrefabs;

    void Start()
    {
        Debug.Log("Hello map gen");
    }

    /// <summary>
    /// Generate the main and the side area of the map.
    /// </summary>
    public void GenerateMap()
    {
        Debug.Log("Hello GenerateMap");
        GenerateMainAreaGround();
    }

    /// <summary>
    /// Generate the ground for the main area.
    /// </summary>
    private void GenerateMainAreaGround()
    {

    }

    /// <summary>
    /// Generate the ground for the side area.
    /// </summary>
    private void GenerateSideAreaGround()
    {

    }
}
