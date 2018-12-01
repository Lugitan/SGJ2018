using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundQueue : MonoBehaviour {

    private Vector3 position = new Vector3(0, 0, 0);
    private float intensity = 1.0f;
    private AudioSource sound = null;

    public AudioSource Sound
    {
        get
        {
            return sound;
        }

        set
        {
            sound = value;
        }
    }

    public float Intensity
    {
        get
        {
            return intensity;
        }

        set
        {
            intensity = value;
        }
    }

    public Vector3 Position
    {
        get
        {
            return Position1;
        }

        set
        {
            Position1 = value;
        }
    }

    public Vector3 Position1
    {
        get
        {
            return position;
        }

        set
        {
            position = value;
        }
    }

}
