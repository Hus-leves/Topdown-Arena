using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSword : MonoBehaviour
{
    public GameObject sword;
    public Camera cam;
    public float angleOffset;


    void Update()
    {
        Vector2 mouse = Mouse.current.position.ReadValue();
        Vector3 world = cam.ScreenToWorldPoint(mouse);
        Vector2 dir = world - transform.position;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + angleOffset;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
