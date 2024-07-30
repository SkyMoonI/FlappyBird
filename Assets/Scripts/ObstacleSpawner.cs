using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
	public GameObject prefabToSpawn; // Your prefab reference (drag and drop in Inspector)
	private Vector2 obstacleSpawnPosition; // Where the prefab should be spawned
	private Quaternion spawnRotation = Quaternion.identity;
	private GameObject spawnedObject; // Reference to the spawned object
	private List<GameObject> spawnedObjects = new List<GameObject>();
	
	private float maxYPosition = 5f;
	private float minYPosition = 0f;
	private float obstacleYPosition = 0f;
	private float obstacleXPosition = 0f;
	
	private float spaceBetweenObstacles = 4.5f;
	
	
	public float gameSpeed = 2f;
	public float speedIncreasePerFrame = 0.1f;
	public float maxGameSpeed = 7f;
	
	
	// Start is called before the first frame update
	void Start()
	{
		// Getting the initial position of the first obstacle 
		obstacleXPosition = GetComponent<ObstacleSpawner>().transform.position.x;
		// Spawn 5 obstacles on start of the game
		for(int i = 0; i < 5; i++)	
		{
			ObjectSpawner();
			obstacleXPosition = spawnedObjects[spawnedObjects.Count - 1].transform.position.x + spaceBetweenObstacles;
		}
	}
	
	// Update is called once per frame
	void Update()
	{
		// Increase the game speed
		gameSpeed = Mathf.Clamp(gameSpeed + speedIncreasePerFrame * Time.deltaTime, 0f, maxGameSpeed);
		// Move the spawned objects
		foreach(GameObject spawnedObject in spawnedObjects)
		{
			spawnedObject.transform.Translate(Vector2.left * gameSpeed * Time.deltaTime);
		}
		// Check if the first obstacle is out of the screen, if so remove it from the list and destroy it
		if(spawnedObjects[0].transform.position.x < -10f)
		{
			obstacleXPosition = spawnedObjects[spawnedObjects.Count - 1].transform.position.x + spaceBetweenObstacles;
			Destroy(spawnedObjects[0]);
			spawnedObjects.RemoveAt(0);
			ObjectSpawner();
		}
	}
	
	
	private void ObjectSpawner()
	{
		obstacleYPosition = UnityEngine.Random.Range(minYPosition, maxYPosition);
		obstacleSpawnPosition = new Vector2(obstacleXPosition, obstacleYPosition);
		spawnedObject = Instantiate(prefabToSpawn, obstacleSpawnPosition, spawnRotation) as GameObject;
		spawnedObjects.Add(spawnedObject);
	}
}
