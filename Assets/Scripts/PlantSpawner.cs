using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSpawner : MonoBehaviour
{
    public GameObject[] prefabs;
    public float spawnTime;
    
    private float _timer;
    private float _yPos = -3.1f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (_timer < spawnTime)
            _timer += Time.deltaTime;
        else
        {
            SpawnPlant();
            _timer = 0;
        }
    }

    void SpawnPlant()
    {
        var newPosition = new Vector3(transform.position.x,_yPos, transform.position.z);
        Instantiate(prefabs[Random.Range(0,prefabs.Length)], newPosition, transform.rotation);
    }
}
