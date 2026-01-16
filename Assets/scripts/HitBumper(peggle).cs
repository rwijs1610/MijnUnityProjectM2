using System;
using UnityEngine;
public class HitBumper : MonoBehaviour
{
    [SerializeField] private int bumperValue = 50;
    private ParticleSystem ps;
    public static event Action<Transform, int> onHitBumper;
    private void Start()
    {
        ps = GetComponent<ParticleSystem>();
        ps?.Stop();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            onHitBumper?.Invoke(gameObject.transform, bumperValue);
            ps?.Stop();
            ps?.Play();
        }
    }
}
