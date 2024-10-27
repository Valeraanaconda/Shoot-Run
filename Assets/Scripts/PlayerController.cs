using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private bl_Joystick joystick;
    [SerializeField] private float speed = 5;
    [SerializeField] private float speedRotation = 10;
    void Update()
    {
        float v = joystick.Vertical;
        float h = joystick.Horizontal;

        Vector3 moveVector = new Vector3(h, 0, v);
        Vector3 translate = transform.position + moveVector * Time.deltaTime * speed;
        transform.position = translate;

        if (moveVector != Vector3.zero)
        {
            var targetRotation = Quaternion.LookRotation(moveVector);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, speedRotation * Time.deltaTime);
        }
    }
}
