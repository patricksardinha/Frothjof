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
    public void GenerateMap()
    {
        Debug.Log("Hello GenerateMap");
        GenerateMainArea();
        GenerateSideArea();

        List<GameObject> listGroundKingdom = new List<GameObject>();
        listGroundKingdom = GetGroundKingdomPrefabs("Geir");

        Debug.Log("->" + gameObject.name.Contains("mema"));
    }


    // Main Area.

    /// <summary>
    /// Generate the main area.
    /// </summary>
    private void GenerateMainArea()
    {
        GenerateMainAreaGround();
        GenerateMainAreaCover();
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



    // Side Area.

    /// <summary>
    /// Generate the side area.
    /// </summary>
    private void GenerateSideArea()
    {
        GenerateSideAreaGround();
        GenerateSideAreaCover();
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



    // Kingdoms relations.

    private List<GameObject> GetGroundKingdomPrefabs(string kingdomPattern)
    {
        List<GameObject> listPrefabs = new List<GameObject>();
        return listPrefabs;
    }

    private List<GameObject> GetCoverKingdomPrefabs(string kingdomPattern)
    {
        List<GameObject> listPrefabs = new List<GameObject>();
        return listPrefabs;
    }
}
