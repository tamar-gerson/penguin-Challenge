using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerScript : MonoBehaviour
{
    //[SerializeField] private LogicScript ls;
    [SerializeField] private PenguinScript ps;
    [SerializeField] private GameObject[] objToSpawn;
    [SerializeField] private float spawnRate;
    private float _timer = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (var obj in objToSpawn)
        {
            spawn(obj); 
        }
    }

    // Update is called once per frame
    void Update()
    {
       spawner(spawnRate, objToSpawn);
    }
    
    public void spawner(float spawnRate, GameObject[] objToSpawn)
    {
        if(_timer < spawnRate)
        {
            _timer += Time.deltaTime;
        }
        else
        {
            foreach (var obj in objToSpawn)
            {
               spawn(obj); 
            }
            _timer = 0;
        }
    }

    void spawn(GameObject obj)
    {
        float lowestPoint = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
        float highestPoint = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
        float leftPoint = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        float rightPoint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        if (ps.getAlive())
        { 
            Debug.Log("Spawn"+ obj.name);
            Instantiate(obj, new Vector3(Random.Range(leftPoint, rightPoint), Random.Range(lowestPoint, highestPoint), 0), Quaternion.identity);
        }
    }

    public float getSpawnRate()
    {
        return spawnRate;
    }
    
    public void setSpawnRate(float newSpawnRate)
    {
        spawnRate = newSpawnRate;
    }
}
