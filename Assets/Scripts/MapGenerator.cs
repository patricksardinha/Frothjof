using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField]
    private int[] sizeMainArea;
    [SerializeField]
    private int sizeBorderSideArea;

    // All gameobjects for the main area and the side area of the game.
    // To find gameobjects related to a specific kingdom, check if the gameobject's name contains the kingdom's name.
    [SerializeField]
    private GameObject[] groundPrefabs;
    [SerializeField]
    private GameObject[] coverPrefabs;


    void Start()
    {
        Debug.Log("Hello map gen");
    }

    /// <summary>
    /// Generate the main and the side area of the map.
    /// </summary>
    public void GenerateMap(string kingdomName)
    {
        Debug.Log("Hello GenerateMap");

        List<GameObject> listCoverKingdom = new List<GameObject>();
        List<GameObject> listGroundKingdom = new List<GameObject>();

        listGroundKingdom = GetGroundKingdomPrefabs(kingdomName);
        listCoverKingdom = GetCoverKingdomPrefabs(kingdomName);

        GenerateMainArea();
        GenerateSideArea();
    }


    // Main Area.

    /// <summary>
    /// Generate the main area.
    /// </summary>
    private void GenerateMainArea()
    {
        // Gameobjects generation.
        GenerateMainAreaGround();
        GenerateMainAreaCover();

        // Animations display.
        EntranceAnimation();
    }

    /// <summary>
    /// Generate the ground for the main area.
    /// </summary>
    private void GenerateMainAreaGround()
    {

    }

    /// <summary>
    /// Generate objects and vegetation on the main area.
    /// </summary>
    private void GenerateMainAreaCover()
    {

    }


    private void ClearMainArea()
    {

    }



    // Side Area.

    /// <summary>
    /// Generate the side area.
    /// </summary>
    private void GenerateSideArea()
    {
        GenerateSideAreaGround();
        GenerateSideAreaCover();

        EntranceAnimation();
    }

    /// <summary>
    /// Generate the ground for the side area.
    /// </summary>
    private void GenerateSideAreaGround()
    {

    }

    /// <summary>
    /// Generate objects and vegetation on the side area.
    /// </summary>
    private void GenerateSideAreaCover()
    {

    }



    // Animations

    private void EntranceAnimation()
    {

    }

    private void ExitAnimation()
    {

    }


    // Kingdoms relations.

    /// <summary>
    /// Get all ground prefabs related to the kingdom passed as argument.
    /// </summary>
    /// <param name="kingdomPattern">The kingdom name pattern.</param>
    /// <returns></returns>
    private List<GameObject> GetGroundKingdomPrefabs(string kingdomPattern)
    {
        List<GameObject> listPrefabs = new List<GameObject>();

        foreach (GameObject groundPrefab in groundPrefabs)
        {
            if (groundPrefab.name.Contains(kingdomPattern))
            {
                listPrefabs.Add(groundPrefab);
            }
        }

        return listPrefabs;
    }


    /// <summary>
    /// Get all cover prefabs related to the kingdom passed as argument.
    /// </summary>
    /// <param name="kingdomPattern">The kingdom name pattern.</param>
    /// <returns></returns>
    private List<GameObject> GetCoverKingdomPrefabs(string kingdomPattern)
    {
        List<GameObject> listPrefabs = new List<GameObject>();

        foreach (GameObject coverPrefab in coverPrefabs)
        {
            if (coverPrefab.name.Contains(kingdomPattern))
            {
                listPrefabs.Add(coverPrefab);
            }
        }

        return listPrefabs;
    }
}
