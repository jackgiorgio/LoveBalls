using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] attackerPrefabArray;

    void Update()
    {
        foreach (GameObject thisAttacker in attackerPrefabArray)
        {
            if (isTimeToSpawn(thisAttacker))
            {
                Spawn(thisAttacker);
            }
        }
    }

    bool isTimeToSpawn(GameObject attackerGameObject)
    {
        Attacker attacker = attackerGameObject.GetComponent<Attacker>();

        float meanSpawnDelay = attacker.seenEverySeconds;

        float spawnsPerSecond = 1 / meanSpawnDelay;

        if (Time.deltaTime > meanSpawnDelay)
        {
            Debug.LogWarning("Spawn rate capped by the frame rate");
        }

        float threshold = spawnsPerSecond * Time.deltaTime /5;

        return (Random.value < threshold);

        
    }

    void Spawn(GameObject myGameObject)
    {
        GameObject myAttacker = Instantiate(myGameObject,transform.position,Quaternion.identity) as GameObject;
        myAttacker.transform.parent = transform;
    }
}
