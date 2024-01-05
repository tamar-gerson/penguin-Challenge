using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GummySpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject gummy;
    [SerializeField] private float spawnRate ;
    [SerializeField] private spawnerScript spawner;
    // Start is called before the first frame update
    void Start()
    {
        spawner.spawner(spawnRate, new []{gummy});
    }

    // Update is called once per frame
    void Update()
    {
        spawner.spawner(spawnRate, new []{gummy});
    }
    public void setSpawnRate(float newSpawnRate)
    {
        spawnRate = newSpawnRate;
    }
    
    public float getSpawnRate()
    {
        return spawnRate;
    }
}
