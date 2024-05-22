using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    void Update()
    {
        bool moveUp = Input.GetKey(KeyCode.W);
        bool moveDown = Input.GetKey(KeyCode.S);
        bool moveLeft = Input.GetKey(KeyCode.A);
        bool moveRight = Input.GetKey(KeyCode.D);

        Vector3 movement = Vector3.zero;

        if (moveUp)
        {
            movement += Vector3.up;
        }
        if (moveDown)
        {
            movement += Vector3.down;
        }
        if (moveLeft)
        {
            movement += Vector3.left;
        }
        if (moveRight)
        {
            movement += Vector3.right;
        }

        if (movement.magnitude > 1f)
        {
            movement.Normalize();
        }

        transform.Translate(movement * speed * Time.deltaTime);
    }
}