using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    private float _moveSpeed = 2;
    private float _xBorders = 11f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * _moveSpeed * Time.deltaTime;
        
        if (transform.position.x - (-_xBorders) < 0)
            Destroy(gameObject);
    }
}
