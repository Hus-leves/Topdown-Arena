using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRotation : MonoBehaviour
{
    public Camera cam;
    public float size = 0.5f;

    void Update()
    {
        Vector2 mouse = Mouse.current.position.ReadValue();
        float mouseX = cam.ScreenToWorldPoint(mouse).x;

        float side = mouseX > transform.position.x ? size : -size;
        transform.localScale = new Vector3(side, size, size);
    }
}
