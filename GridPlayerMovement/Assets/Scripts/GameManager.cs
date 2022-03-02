using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject cubePrefab;
    public GameObject playerPrefab;
    public int gridWidth;
    public int gridHeight;

    public GameObject mainCamera;

    private List<List<GameObject>> cubesGrid = new List<List<GameObject>>();

    private PlayerController playerControllerScript;
    private Bounds bounds = new Bounds();
    // Start is called before the first frame update
    void Start()
    {
        CreateGrid();
        SetPlayerPositionAtStart();
        AdjustCameraPosition();
    }

    void CreateGrid()
    {
        for (int x = 0; x < gridHeight; x++)
        {
            cubesGrid.Add(new List<GameObject>());
            for (int y = 0; y < gridWidth; y++)
            {
                GameObject tempCube = Instantiate(cubePrefab, new Vector3(x, 0, y), cubePrefab.transform.rotation);
                bounds.Encapsulate(tempCube.transform.position);
                cubesGrid[x].Add(tempCube);
            }
        }
    }

    void SetPlayerPositionAtStart()
    {
        GameObject tempPlayer = Instantiate(playerPrefab, new Vector3(0, 1.6f, 0), playerPrefab.transform.rotation);
        playerControllerScript = tempPlayer.GetComponent<PlayerController>();
        playerControllerScript.SetGameManager(this);
    }

    public void MovePlayer(string direction)
    {
        if (direction == "Left")
        {
            if(playerControllerScript.transform.position.x > 0)
            {
                playerControllerScript.transform.position = new Vector3(playerControllerScript.transform.position.x - 1, playerControllerScript.transform.position.y, playerControllerScript.transform.position.z);
            }
        } else if (direction == "Right")
        {
            if (playerControllerScript.transform.position.x < cubesGrid.Count - 1)
            {
                playerControllerScript.transform.position = new Vector3(playerControllerScript.transform.position.x + 1, playerControllerScript.transform.position.y, playerControllerScript.transform.position.z);
            }
        }
        else if (direction == "Forward")
        {
            if (playerControllerScript.transform.position.z < cubesGrid[0].Count - 1)
            {
                playerControllerScript.transform.position = new Vector3(playerControllerScript.transform.position.x, playerControllerScript.transform.position.y, playerControllerScript.transform.position.z + 1);
            }
        }
        else if (direction == "Backward")
        {
            if (playerControllerScript.transform.position.z > 0)
            {
                playerControllerScript.transform.position = new Vector3(playerControllerScript.transform.position.x, playerControllerScript.transform.position.y, playerControllerScript.transform.position.z - 1);
            }
        }
    }

    void AdjustCameraPosition()
    {
        mainCamera.transform.position = bounds.center;
        mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, bounds.max.x + 2, mainCamera.transform.position.z);
    }
}
