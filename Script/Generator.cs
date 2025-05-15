using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    public GameObject pickupPrefab; // Asigna el prefab del pickup en el Inspector
    public int maxPickups = 5;
    public Vector3 minSpawnPos = new Vector3(-10, 1, -10);
    public Vector3 maxSpawnPos = new Vector3(10, 1, 10);

    void Start()
    {
        for (int i = 0; i < maxPickups; i++)
        {
            Vector3 randomPos = new Vector3(
                Random.Range(minSpawnPos.x, maxSpawnPos.x),
                Random.Range(minSpawnPos.y, maxSpawnPos.y),
                Random.Range(minSpawnPos.z, maxSpawnPos.z)
            );
            Instantiate(pickupPrefab, randomPos, Quaternion.identity);
        }
    }
}
