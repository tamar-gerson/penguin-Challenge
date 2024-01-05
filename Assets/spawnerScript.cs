using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerScript : MonoBehaviour
{
    //[SerializeField] private GameObject fish;
    [SerializeField] private PenguinScript ps;
    //[SerializeField] private GameObject gummy;
    //[SerializeField] private float spawnRate = 4;
    //[SerializeField] private GameObject deadFish;
    //[SerializeField] private float gummySpawnRate = 8;
    private float timer = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        //spawn(fish);
        //spawn(deadFish);
    }

    // Update is called once per frame
    void Update()
    {
       //spawner(spawnRate, new []{fish,deadFish}); 
       //spawner(gummySpawnRate, new []{gummy}); 
    }
    
    public void spawner(float spawnRate, GameObject[] whatToSpawn)
    {
        if(timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            foreach (var obj in whatToSpawn)
            {
               spawn(obj); 
            }
            timer = 0;
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
}
