using UnityEngine;

public class ShadowController : MonoBehaviour
{
    public PlayerController player;
    public float speed = 5f;
    public float delay = 0.003f;

    private float delayTimer = 0f;
    private Vector2 currentInput = Vector2.zero;

    void Update()
    {
        delayTimer += Time.deltaTime;

        if (delayTimer >= delay && player.inputQueue.count>0)
        {
            var mov = player.inputQueue.Dequeue() ;
            transform.Translate(mov);
            delayTimer = 0f; 
            Debug.Log("Desencola: " + mov);
        }
    }
}