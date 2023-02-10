using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockAnimations : MonoBehaviour
{
    private MapGenerator mapGeneratorScript;

    void Start()
    {
        mapGeneratorScript = GetComponent<MapGenerator>();
    }

    void Update()
    {
        Debug.Log("[blockAnimations.cs]");

        if (mapGeneratorScript.playEntranceAnim)
        {
            // TODO: for all element in list currentground
            // check if y position is > 0
            // if yes move toward 0 else continue

            // Disable playEntranceAnim when all blocks are well placed.
            mapGeneratorScript.playEntranceAnim = false;
        }
    }
}
