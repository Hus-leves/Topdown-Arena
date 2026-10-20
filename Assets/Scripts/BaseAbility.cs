using UnityEngine;

public abstract class BaseAbility : MonoBehaviour
{
    public KeyCode key;
    public float coolDown = 0.5f;

    public abstract void Activate();

    private void Update()
    {
        if (Input.GetKey(key) && coolDown <= 0.01f)
        {
            Activate();
        }
    }
}
