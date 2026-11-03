using System.Collections;
using UnityEngine;

public class BaseProjectile : MonoBehaviour
{
    
    void Start()
    {
        StartCoroutine(Timeout());
    }
    IEnumerator Timeout()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }
}
