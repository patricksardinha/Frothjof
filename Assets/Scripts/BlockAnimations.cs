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
        Debug.Log("[blockAnimations.update]");

        Debug.Log("->" + mapGeneratorScript.playEntranceAnim);
        if (mapGeneratorScript.playEntranceAnim && mapGeneratorScript.groundFlag && !mapGeneratorScript.coverFlag)
        {
            float groundY = 0;
            float speedAnimation = 2.0f;

            // Disable playEntranceAnim when all blocks are well placed.
            //mapGeneratorScript.playEntranceAnim = false;

            foreach (GameObject go in mapGeneratorScript.currentGround)
            {
                if (go.activeInHierarchy && go.transform.position.y > 0)
                {
                    Vector3 goTargetPosition = new Vector3(go.transform.position.x, groundY, go.transform.position.z);

                    go.transform.position = Vector3.MoveTowards(go.transform.position, goTargetPosition, speedAnimation * Time.deltaTime);

                    // Enable flag for the next iteration.
                    mapGeneratorScript.playEntranceAnim = true;
                }
            }

            // Disable playEntranceAnim for the next iteration and check if all blocks are well placed.
            // [Yes] -> Stop animation loops by disabling flags.
            // [No]  -> Enable flags for the next iteration.
            mapGeneratorScript.playEntranceAnim = false;
            mapGeneratorScript.groundFlag = false;
            mapGeneratorScript.isGroundLayerBuilt = true;
            foreach (GameObject go in mapGeneratorScript.currentGround)
            {
                if (go.transform.position.y > 0)
                {
                    mapGeneratorScript.playEntranceAnim = true;
                    mapGeneratorScript.groundFlag = true;
                    mapGeneratorScript.isGroundLayerBuilt = false;
                    break;
                }
            }

        }
        else if (mapGeneratorScript.isGroundLayerBuilt)
        {
            Debug.Log("---------------------------------------------------->" + mapGeneratorScript.isGroundLayerBuilt);
            if (mapGeneratorScript.playEntranceAnim && !mapGeneratorScript.groundFlag && mapGeneratorScript.coverFlag)
            {
                float coverY = 1;
                float speedAnimation = 2.0f;

                foreach (GameObject go in mapGeneratorScript.currentCover)
                {
                    if (go.activeInHierarchy && go.transform.position.y > 0)
                    {
                        Vector3 goTargetPosition = new Vector3(go.transform.position.x, coverY, go.transform.position.z);

                        go.transform.position = Vector3.MoveTowards(go.transform.position, goTargetPosition, speedAnimation * Time.deltaTime);

                        // Enable flag for the next iteration.
                        mapGeneratorScript.playEntranceAnim = true;
                    }
                }

                // Disable playEntranceAnim for the next iteration and check if all blocks are well placed.
                // [Yes] -> Stop animation loops by disabling flags.
                // [No]  -> Enable flags for the next iteration.
                mapGeneratorScript.playEntranceAnim = false;
                mapGeneratorScript.coverFlag = false;
                foreach (GameObject go in mapGeneratorScript.currentCover)
                {
                    if (go.transform.position.y > 0)
                    {
                        mapGeneratorScript.playEntranceAnim = true;
                        mapGeneratorScript.coverFlag = true;
                        break;
                    }
                }

            }

        }

    }
}
