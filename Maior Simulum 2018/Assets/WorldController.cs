using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour {

	//This script controls everything relating to the "Terrain" from generating/spawning the terrain to handiling day and night cycles.
	public GameObject trees;
	public void Start () {
		
		SpawnTrees(trees);

	}
	
	void Update () {
		
	}

	//Function which spawns tree randomly across the terrain.
	void SpawnTrees (GameObject treeModel) {

		
		for (int i = 0; i < Random.Range(40, 90); i++)
		{
			Vector3 spaght = new Vector3(Random.Range(50, 200), 0, Random.Range(50, 200));
			GameObject treeVar = Instantiate(treeModel, spaght, treeModel.transform.rotation);
		}

	}
}
