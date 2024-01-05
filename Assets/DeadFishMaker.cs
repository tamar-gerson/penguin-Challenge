using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadFishMaker : MonoBehaviour
{
    [SerializeField] private GameObject fish;
    [SerializeField] private PenguinScript ps;
    [SerializeField] private float spawnRate = 4;
    private float timer = 0;
    void Start()
    {
        spawnFish();
    }
    
    void Update()
    {
        if(timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnFish();
            timer = 0;
        } 
    }
    
    void spawnFish()
    {
        float lowestPoint = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
        float highestPoint = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
        float leftPoint = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        float rightPoint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;

        if (ps.getAlive())
        {
            Debug.Log("Spawn dead fish");
            Instantiate(fish, new Vector3(Random.Range(leftPoint, rightPoint), Random.Range(lowestPoint, highestPoint), 0), Quaternion.identity);    
        }
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
