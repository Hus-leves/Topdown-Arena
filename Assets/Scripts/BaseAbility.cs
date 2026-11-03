using UnityEngine;
using UnityEngine.UI;

public abstract class BaseAbility : MonoBehaviour
{
    public KeyCode key;
    public float coolDown = 0.5f;
    public Image abilityImage;
    public GameObject objectToInstantiate;

    private float cd;

    public abstract void Activate();

    private void Start()
    {
        cd = coolDown;
    }

    private void Update()
    {
        if (Input.GetKey(key) && cd >= coolDown)
        {
            Activate();
            cd = 0f;
            abilityImage.fillAmount = 0;
        }
        else if (cd <= coolDown)
        {
            cd += Time.deltaTime;
            abilityImage.fillAmount = cd / coolDown;
        }
    }
}
