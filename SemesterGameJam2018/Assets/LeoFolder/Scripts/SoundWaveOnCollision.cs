using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundWaveOnCollision : MonoBehaviour {

    public Color color = Color.white;
    public float range = 8, endurance = 2, velocityScale = 0.5f;

    void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.relativeVelocity.magnitude);
        if (col.relativeVelocity.magnitude < 0.1f) { return; }
        float factor = 1;
        Vector3 pos = transform.position;
        if (col.contacts.Length > 0)
        {
            pos = col.contacts[0].point + col.contacts[0].normal * 0.2f;
        }
        factor = col.relativeVelocity.magnitude * velocityScale;
        SoundwaveManager.PlaceSoundSource(transform.position, factor * range, endurance, color);
    }

    void OnTriggerEnter(Collider other)
    {
        SoundwaveManager.PlaceSoundSource(transform.position, range, endurance, color);
    }
}
