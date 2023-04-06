using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

/**
 * This component instantiates a given prefab at random time intervals and random bias from its object position.
 */
public class TimedSpawnerRandom : MonoBehaviour
{
    [SerializeField] List<Mover> prefabsToSpawn;
    [SerializeField] List<Vector3> velocityOfSpawnedObjects;
    [Tooltip("Minimum time between consecutive spawns, in seconds")][SerializeField] float minTimeBetweenSpawns = 1f;
    [Tooltip("Maximum time between consecutive spawns, in seconds")][SerializeField] float maxTimeBetweenSpawns = 3f;
    [Tooltip("Maximum distance in X between spawner and spawned objects, in meters")][SerializeField] float maxXDistance = 0.5f;

    [SerializeField] bool enableSpawnerDetection = false;
    [SerializeField] float detectionRadius = .3f;
    [SerializeField] LayerMask triggeringLayers;

    void Start()
    {
        this.StartCoroutine(SpawnRoutine());    // co-routines
        // _ = SpawnRoutine();                   // async-await
    }

    IEnumerator SpawnRoutine()
    {    // co-routines
         // async Task SpawnRoutine() {  // async-await
        while (true)
        {
            float timeBetweenSpawnsInSeconds = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
            yield return new WaitForSeconds(timeBetweenSpawnsInSeconds);       // co-routines

            // await Task.Delay((int)(timeBetweenSpawnsInSeconds*1000));       // async-await
            Vector3 positionOfSpawnedObject = new Vector3(
                transform.position.x + Random.Range(-maxXDistance, +maxXDistance),
                transform.position.y,
                transform.position.z);


            Debug.Log("Powerup Spawning");

            // prevent two objects of being spawned at the same position
            if (enableSpawnerDetection)
            {
                Collider2D[] objects = Physics2D.OverlapCircleAll(positionOfSpawnedObject, detectionRadius, triggeringLayers);
                Debug.Log("Objects detected " + objects.Length);
                if (objects.Length > 0)
                    continue; // exit a coroutine
            }

            int index = Random.Range(0, prefabsToSpawn.Count);
            Mover picked = prefabsToSpawn[index];
            GameObject newObject = Instantiate(picked.gameObject, positionOfSpawnedObject, Quaternion.identity);
            newObject.GetComponent<Mover>().SetVelocity(velocityOfSpawnedObjects.ElementAt(index));
        }
    }
}
