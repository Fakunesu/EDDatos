using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public MyQueue<Vector2> inputQueue= new MyQueue<Vector2>();
    
    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (input != Vector2.zero)
        {
            var mov = input * speed * Time.deltaTime;
            transform.Translate(mov);
            inputQueue.Enqueue(mov);
            Debug.Log("Encola: " + mov);
        }

    }
}
