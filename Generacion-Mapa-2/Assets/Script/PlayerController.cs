using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Cambia el movimiento vertical al eje Y
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }
}
