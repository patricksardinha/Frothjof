using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField]
    private int[] sizeMainArea;
    [SerializeField]
    private int sizeBorderSideArea;

    [SerializeField]
    private Transform mainGroundContainer;
    [SerializeField]
    private Transform mainCoverContainer;

    // All gameobjects for the main area and the side area of the game.
    // To find gameobjects related to a specific kingdom, check if the gameobject's name contains the kingdom's name.
    [SerializeField]
    private GameObject[] groundPrefabs;
    [SerializeField]
    private GameObject[] coverPrefabs;

    private List<GameObject> listGroundKingdom = new List<GameObject>();
    private List<GameObject> listCoverKingdom = new List<GameObject>();

    private List<int> listRouletteCover = new List<int>();
    [SerializeField]
    private int emptyCoverPercentage;
    private List<float> anglesForBlocks = new List<float> { 0.0f, 90.0f, 180.0f, 270.0f };

    public List<GameObject> currentGround = new List<GameObject>();
    public List<GameObject> currentCover = new List<GameObject>();

    // Animations.
    public bool playEntranceAnim = false;
    public bool playExitAnim = false;
    private float displayDelay = 0.001f;

    public bool groundFlag = false;
    public bool coverFlag = false;
    public bool isGroundLayerBuilt = false;
    public bool isCoverLayerBuilt = false;

    void Start()
    {
        Debug.Log("Hello map gen");
    }

    private void Update()
    {

    }

    /// <summary>
    /// Generate the main and the side area of the map.
    /// </summary>
    public IEnumerator GenerateMap(string kingdomName)
    {
        Debug.Log("Hello GenerateMap");

        listGroundKingdom = GetGroundKingdomPrefabs(kingdomName);
        listCoverKingdom = GetCoverKingdomPrefabs(kingdomName);

        listRouletteCover = GenerateRoulette(emptyCoverPercentage, listCoverKingdom.Count);

        GenerateMainArea();
        GenerateSideArea();

        // Animations display.
        groundFlag = true;
        EntranceAnimation(currentGround);

        while (!isGroundLayerBuilt)
        {
            yield return new WaitForSeconds(0.1f);
        }
        
        coverFlag = true;
        EntranceAnimation(currentCover);
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
    }

    /// <summary>
    /// Generate the ground for the main area.
    /// </summary>
    private void GenerateMainAreaGround()
    {
        float offsetAnimation = 1.0f;

        for (int x = 0; x < sizeMainArea[0]; x++)
        {
            for (int z = 0; z < sizeMainArea[1]; z++)
            {
                GameObject block = listGroundKingdom[Random.Range(0, listGroundKingdom.Count)];
                block.SetActive(false);

                Vector3 blockPosition = new Vector3(x, offsetAnimation, z);

                currentGround.Add(Instantiate(block, blockPosition, Quaternion.identity, mainGroundContainer));
            }
        }
    }

    /// <summary>
    /// Generate objects and vegetation on the main area.
    /// </summary>
    private void GenerateMainAreaCover()
    {
        float offsetAnimation = 2.0f;

        for (int x = 0; x < sizeMainArea[0]; x++)
        {
            for (int z = 0; z < sizeMainArea[1]; z++)
            {
                GameObject block = listCoverKingdom[listRouletteCover[Random.Range(0, listRouletteCover.Count)]];
                block.SetActive(false);

                Vector3 blockPosition = new Vector3(x, offsetAnimation, z);

                currentCover.Add(Instantiate(block, blockPosition, Quaternion.Euler(0, anglesForBlocks[Random.Range(0, anglesForBlocks.Count)], 0), mainCoverContainer));
            }
        }
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

    private void EntranceAnimation(List<GameObject> listGo)
    {
        // [BlockAnimations.cs]
        playEntranceAnim = true;

        StartCoroutine(WaitAndDisplayRandom(listGo));
    }

    private void ExitAnimation()
    {

    }


    /// <summary>
    /// Display randomly gameobjects in the input list with a short delay between each display.
    /// </summary>
    /// <param name="layer">The list of gameobjects.</param>
    /// <returns>Yield with delay.</returns>
    private IEnumerator WaitAndDisplayRandom(List<GameObject> listGameobjects)
    {
        List<GameObject> listGameobjectsShuffled = ShuffleGameobjects(listGameobjects);

        foreach (GameObject go in listGameobjectsShuffled)
        {
            if (!go.name.Contains("EmptyCover"))
            {
                yield return new WaitForSeconds(displayDelay);
            }
            go.SetActive(true);
            Debug.Log("-> " + go.activeInHierarchy + ": " + go.name);
        }
    }


    /// <summary>
    /// Shuffle a list of gameobjects.
    /// </summary>
    /// <param name="listGo">The initial list of gameobjects.</param>
    /// <returns>The list randomly shuffled.</returns>
    private List<GameObject> ShuffleGameobjects(List<GameObject> listGo)
    {
        for (int i = 0; i < listGo.Count; i++)
        {
            GameObject temp = listGo[i];
            int randomIndex = Random.Range(i, listGo.Count);
            listGo[i] = listGo[randomIndex];
            listGo[randomIndex] = temp;
        }
        return listGo;
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

    /// <summary>
    /// Generate a roulette list to display a percentage of empty item.
    /// </summary>
    /// <param name="percent">The percentage of empty item wanted.</param>
    /// <param name="nbItemsInList">The current nomber of items in the list.</param>
    /// <returns></returns>
    private List<int> GenerateRoulette(int percent, int nbItemsInList)
    {
        List<int> listInt = new List<int>();

        int nbItemsNoEmptyItem; 
        int newNbItemsEmptyItem;

        if (percent >= 100)
        {
            nbItemsNoEmptyItem = 0;
            newNbItemsEmptyItem = 1;
        } 
        else
        {
            nbItemsNoEmptyItem = nbItemsInList - 1;
            newNbItemsEmptyItem = nbItemsNoEmptyItem * (percent / (100-percent));
        }

        int index = 0;

        for (int i = 0; i < (newNbItemsEmptyItem + nbItemsNoEmptyItem); i++)
        {
            listInt.Add(index);

            if (i > newNbItemsEmptyItem - 1)
            {
                index++;
            }
        }

        return listInt;
    }

}
