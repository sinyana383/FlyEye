using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class VineSpawner : MonoBehaviour
{
    public GameObject vines;
    public float spawnTime;
    
    private float _yBorders = 2.75f;
    private float _timer;
    // Start is called before the first frame update
    void Start()
    {
        // while (Input.GetKeyDown(KeyCode.Space) == false){}
        SpawnVine();
    }

    // Update is called once per frame
    void Update()
    {
        if (_timer < spawnTime)
            _timer += Time.deltaTime;
        else
        {
            SpawnVine();
            _timer = 0;
        }
    }

    void SpawnVine()
    {
        var down = -_yBorders;
        var up = _yBorders;
        var newPosition = new Vector3(transform.position.x,Random.Range(down, up), transform.position.z);
        
        Instantiate(vines, newPosition, transform.rotation);
    }
}
