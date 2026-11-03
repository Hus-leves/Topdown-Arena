using UnityEngine;

public class PlayerSword : Sword
{

    protected override void Update()
    {
        base.Update();
        if (Input.GetKey(KeyCode.Mouse0))
            swing = true;
        else
            swing = false;
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
    }
}
