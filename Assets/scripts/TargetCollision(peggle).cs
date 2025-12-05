using UnityEngine;
public class TargetCollision : MonoBehaviour
{
    void Start()
    {

    }
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit!");
    }
}
