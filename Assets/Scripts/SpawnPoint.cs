using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public int layer;
    public Vector3 positionToSpawn;

    void Awake()
    {
        positionToSpawn = transform.position;
    }
}
