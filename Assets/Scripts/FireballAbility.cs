using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballAbility : BaseAbility
{
    public float damage = 50f;
    public float fireballSpeed = 10f;

    private Vector3 mousePosition;
    private Vector2 direction;

    public override void Activate()
    {
        GameObject ball = Instantiate(objectToInstantiate, transform.position, Quaternion.identity);
        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
        LocateMouse();
        rb.linearVelocity = direction * fireballSpeed;
    }

    void LocateMouse()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        direction = (mousePosition - transform.position).normalized;
    }
}
