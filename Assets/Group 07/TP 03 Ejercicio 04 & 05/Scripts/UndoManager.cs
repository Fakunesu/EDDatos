using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndoManager : MonoBehaviour
{
    public float speed = 5f;
    public MyStack<Vector2> inputStack = new MyStack<Vector2>();
    void Start()
    {

    }


    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (input != Vector2.zero)
        {
            var mov = input * speed * Time.deltaTime;
            transform.Translate(mov);
            inputStack.Push(mov);
        }


        if (inputStack.count >= 0)
        {

             if (Input.GetKey(KeyCode.Z))
             {
                 var mov = inputStack.Pop();
                 transform.Translate(-mov);

             }
        }
    }
}