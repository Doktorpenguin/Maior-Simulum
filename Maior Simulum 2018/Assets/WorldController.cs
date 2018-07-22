using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour {

	//This script controls everything relating to the "Terrain" from generating/spawning the terrain to handiling day and night cycles.
	public GameObject trees;
	public GameObject appleTrees;
	public void Start () {
		
		SpawnTrees(trees, Random.Range(80, 120));
		SpawnTrees(appleTrees, Random.Range(50, 100));

	}
	
	void Update () {
		
	}

	//Function which spawns tree randomly across the terrain.
	void SpawnTrees (GameObject treeModel, int treeSpawnCount) {

		
		for (int i = 0; i < treeSpawnCount; i++)
		{
			Vector3 spaght = new Vector3(Random.Range(50, 200), 0, Random.Range(50, 200));
			GameObject treeVar = Instantiate(treeModel, spaght, treeModel.transform.rotation);
		}

	}
}
