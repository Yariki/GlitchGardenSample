using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{

    public GameObject[] attackerPrefabArray;



    // Update is called once per frame
    void Update()
    {
        if (attackerPrefabArray != null && attackerPrefabArray.Length > 0)
        {
            foreach (var thisAttacker in attackerPrefabArray)
            {
                if (isTimeToSpawn(thisAttacker))
                {
                    Spawn(thisAttacker);
                }
            }
        }

    }

    private void Spawn(GameObject thisAttacker)
    {
        GameObject myAttacker = Instantiate(thisAttacker) as GameObject;
        myAttacker.transform.parent = transform;
        myAttacker.transform.position = transform.position;
    }

    private bool isTimeToSpawn(GameObject thisAttacker)
    {
        Attacker attacker = thisAttacker.GetComponent<Attacker>();
        float meanSpawnDelay = attacker != null ? attacker.seenEverySeconds : 10f;
        float spawnPerSecond = 1 / meanSpawnDelay;
        if (Time.deltaTime > meanSpawnDelay)
        {
            Debug.LogWarning("Spawn rate capped by frame rate");
        }
        float threshold = spawnPerSecond * Time.deltaTime / 5;

        return Random.value < threshold;
    }
}
