using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoundQueueSystem
{
    public class SoundQueue : MonoBehaviour
    {
        private Vector3 position = new Vector3(0, 0, 0);
        private float intensity = 1.0f;

        private float spatialBlend = 1.0f;

        public AudioClip Sound { get; set; }
        public AudioSource Source { get; set; }

        //public SoundQueue(Vector3 position, float intensity, AudioClip sound)
        //{
        //    this.position = position;
        //    this.intensity = intensity;
        //    this.sound = sound;

        //    m_g = new GameObject
        //    {
        //        name = "SoundQueue"
        //    };
        //    m_g.AddComponent<AudioSource>();
        //}

        /// <summary>
        ///  Invokes every necessary Elements for this SoundQueue
        /// </summary>
        public void InvokeQueue(Vector3 pos)
        {
            // Set Position of the SoundQueue object
            gameObject.transform.position = pos;

            // Set AudioSource Properties
            Source.clip = Sound;
            Source.spatialBlend = spatialBlend;
            Source.volume = intensity > 1.0f ? intensity / 100.0f: intensity;

            Source.Play();
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
                return position;
            }

            set
            {
                position = value;
            }
        }

        public float SpatialBlend
        {
            get
            {
                return spatialBlend;
            }

            set
            {
                spatialBlend = value;
            }
        }
    }
}
