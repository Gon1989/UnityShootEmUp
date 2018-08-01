using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    private int score;

	// Use this for initialization
	void Start () {
        score = 0;
        StartCoroutine(spawnWaves());

	}
	
    //Spawn waves
	IEnumerator spawnWaves()
    {
        yield return new WaitForSeconds(startWait);

        //keep runing the loop
        while (true) {

            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                //to apply the stop here we need a coroutine in C#
                //we need to return an enumerator
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }



    


}
