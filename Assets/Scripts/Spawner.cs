
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public SpawnPoint[] spawnPoints;
    public Phantom phantom;

    public void SpawnPhantom() {
        SpawnPoint point = spawnPoints[Random.Range(0, spawnPoints.Length)];

        phantom.ResetPhantom(point.layer, point.positionToSpawn);
    }
}
