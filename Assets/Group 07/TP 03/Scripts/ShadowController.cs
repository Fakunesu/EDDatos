using UnityEngine;

public class ShadowController : MonoBehaviour
{
    public PlayerController player;
    public float speed = 5f;
    public float delay = 0.5f;

    private float delayTimer = 0f;
    private Vector2 currentInput = Vector2.zero;

    void Update()
    {
        delayTimer += Time.deltaTime;


        // Cada vez que pasen "delay" segundos, reproducir un input
        if (delayTimer >= delay && player.inputQueue.count>0)
        {
            transform.Translate(player.inputQueue.Dequeue() * speed * Time.deltaTime);
            delayTimer = 0f; // reiniciamos el cronómetro
        }
    }
}
