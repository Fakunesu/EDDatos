using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public MyQueue<Vector2> inputQueue= new MyQueue<Vector2>();
    void Start()
    {
        
    }

    
    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (input != Vector2.zero)
        {
            transform.Translate(input * speed * Time.deltaTime);
            inputQueue.Enqueue(input);
        }
    }
}
