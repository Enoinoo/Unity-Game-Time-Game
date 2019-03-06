using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawn : MonoBehaviour
{
	public GameObject[] asteroids = new GameObject[5];
	public int minCount = 10;
	public int maxCount = 20;
	public int minSpawnRadius = 10;
	public int maxSpawnRadius = 100;
    public int minSize = 5;
    public int maxSize = 10;
    public float minSpeed = 4f;
    public float maxSpeed = 6f;

	private int totalCount;

    // Start is called before the first frame update
    void Start()
    {
    	totalCount = Random.Range(minCount, maxCount);
        for(int i = 0; i < totalCount; i++){
        	SpawnAsteroid();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnAsteroid(){
	    int x = GetRandomAxisValue(.5f);
		int y = GetRandomAxisValue(.9f);
		int z = GetRandomAxisValue(.9f);
		Vector3 randomPos = new Vector3(x, y, z);
		GameObject newAsteroid = Instantiate(asteroids[Random.Range(0, 4)], randomPos, Random.rotation) as GameObject;
		newAsteroid.transform.localScale = new Vector3(Random.Range(minSize, maxSize), Random.Range(minSize, maxSize), Random.Range(minSize, maxSize)); 
	 	newAsteroid.GetComponent<Rigidbody>().velocity = Random.onUnitSphere * (Random.Range(minSpeed, maxSpeed));
    }

    int GetRandomAxisValue(float positivePossibility){
    	float randNum = Random.Range(0f, 1f);
    	if(randNum < positivePossibility){
    		return Random.Range(minSpawnRadius, maxSpawnRadius);
    	}
    	else {
    		return Random.Range(-maxSpawnRadius, -minSpawnRadius);
    	}
    }
}
