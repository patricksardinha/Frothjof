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
        if (mapGeneratorScript.playEntranceAnim)
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

                    // Enable playEntranceAnim for the next iteration.
                    mapGeneratorScript.playEntranceAnim = true;
                }
            }

            
        }
    }
}
