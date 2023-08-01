using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vines : MonoBehaviour
{
    public float moveSpeed;
    
    private enum VinesParts
    {
        Down = 0,
        Up = 1
    }
    private float _xBorders = 11f;
    private float _vinesGap = 9.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        Transform upPos = gameObject.transform.GetChild((int) VinesParts.Up);
        Transform downPos = gameObject.transform.GetChild((int) VinesParts.Down);
        
        upPos.position += new Vector3(0, _vinesGap/2, 0);
        downPos.position += new Vector3(0, -_vinesGap/2, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        
        if (transform.position.x - (-_xBorders) < 0)
            Destroy(gameObject);
    }
}
