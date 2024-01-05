using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishSpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject fish;
    [SerializeField] private GameObject deadfish;
    [SerializeField] private float spawnRate ;
    [SerializeField] private spawnerScript spawner;
    // Start is called before the first frame update
    void Start()
    {
        spawner.spawner(spawnRate, new []{fish,deadfish});
    }

    // Update is called once per frame
    void Update()
    {
        spawner.spawner(spawnRate, new []{fish,deadfish});
        
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
