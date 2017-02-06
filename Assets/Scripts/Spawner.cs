﻿using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject[] attackerPrefabArray;

	// Update is called once per frame
	void Update () {
	    foreach (GameObject thisAttacker in attackerPrefabArray)
        {
            if (isTimeToSpawnAttacker(thisAttacker))
            {
                Spawn(thisAttacker);
            }
        }
	}

    void Spawn(GameObject myGameObject)
    {
        GameObject myAttacker = Instantiate(myGameObject) as GameObject;
        myAttacker.transform.parent = transform;
        myAttacker.transform.position = transform.position;
    }

    bool isTimeToSpawnAttacker (GameObject attackerGameObject)
    {
        Attacker attacker = attackerGameObject.GetComponent<Attacker>();
        float meanSpawnDelay = attacker.seenEverySeconds;
        float spawnsPerSeocnd = 1 / meanSpawnDelay;

        if (Time.deltaTime > meanSpawnDelay)
        {
            Debug.LogWarning("Spawn rate capped by framerate.");
        }

        float threshold = spawnsPerSeocnd * Time.deltaTime / 5;
        return (Random.value < threshold);
    }
}