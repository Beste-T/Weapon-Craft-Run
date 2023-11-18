using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class DoorSpawningScript : MonoBehaviour
{
    [Header("Borders")]
    [SerializeField] private float startingZPosition;
    [SerializeField] private float endingZPosition;
    [SerializeField] private float leftBorder;
    [SerializeField] private float rightBorder;
    [SerializeField] private float spawnDistance;

    [Header("Prefabs")]
    [SerializeField] private GameObject winningDoorPrefab;
    [SerializeField] private GameObject losingDoorPrefab;




    void Start()
    {
        DoorSpawner();
    }

    void DoorSpawner()
    {
        int numberOfDoors = 3;
       
        for (int i = 0; i < numberOfDoors; i++)
        {
            
            float randomX = (Random.Range(0, 2) == 0) ? -1.267f : 1.267f;

            winningDoorPositions.Add(new Vector2(randomX, startingZPosition + i * spawnDistance));

            GameObject winningDoor = Instantiate(winningDoorPrefab, new Vector3(randomX, 1.0f, startingZPosition + i * spawnDistance), Quaternion.identity);
        }

     
        for (int i = 0; i < numberOfDoors; i++)
        {
       
            float randomX = (Random.Range(0, 2) == 0) ? -1.267f : 1.267f;

            while (IsPositionOccupied(randomX, startingZPosition + i * spawnDistance))
            {
                randomX = (Random.Range(0, 2) == 0) ? -1.267f : 1.267f;
            }

            losingDoorPositions.Add(new Vector2(randomX, startingZPosition + i * spawnDistance));

            GameObject losingDoor = Instantiate(losingDoorPrefab, new Vector3(randomX, 1.0f, startingZPosition + i * spawnDistance), Quaternion.identity);
        }
    }

    List<Vector2> winningDoorPositions = new List<Vector2>();
    List<Vector2> losingDoorPositions = new List<Vector2>();

    bool IsPositionOccupied(float x, float z)
    {
        return winningDoorPositions.Any(pos => Mathf.Abs(pos.x - x) < 0.1f && Mathf.Abs(pos.y - z) < 0.1f);
    }
}
