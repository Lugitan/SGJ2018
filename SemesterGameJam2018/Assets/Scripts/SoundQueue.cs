using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoundQueueSystem
{
    public class SoundQueue : MonoBehaviour
    {

        [SerializeField] private Vector3 position = new Vector3(0, 0, 0);
        [SerializeField] private float intensity = 1.0f;
        [SerializeField] private AudioClip sound = null;

        public SoundQueue(Vector3 position, float intensity, AudioClip sound)
        {
            this.position = position;
            this.intensity = intensity;
            this.sound = sound;
        }

        /// <summary>
        ///  Invokes every necessary Elements for this SoundQueue
        /// </summary>
        public void InvokeQueue()
        {
            GameObject sq = new GameObject();
            sq.transform.position = position;

            Destroy(sq);
        }

        

        public AudioClip Sound
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
}
