using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Eye : MonoBehaviour
{
    public Rigidbody2D myRb;
    public float flapStrength;
    
    public LogicManager logic;
    public VineSpawner vineSpawner;
    
    private bool _isAlive = true;
    private Collider2D _eyeCollider;
    
    [SerializeField] private AudioSource hitSound;
    // Start is called before the first frame update
    void Start()
    {
        vineSpawner.enabled = false;
        myRb.constraints |= RigidbodyConstraints2D.FreezePositionY;
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
        _eyeCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Flap(InputAction.CallbackContext context)
    {
        if (context.performed && _isAlive)
        {
            vineSpawner.enabled = true;
            myRb.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
            myRb.velocity = Vector2.up * flapStrength;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        hitSound.Play();
        
        _isAlive = false;
        _eyeCollider.enabled = false;
        logic.GameOver();
    }
}
