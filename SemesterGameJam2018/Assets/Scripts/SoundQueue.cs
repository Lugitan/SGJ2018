using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoundQueueSystem
{
    public class SoundQueue : MonoBehaviour
    {
        private Vector3 position = new Vector3(0, 0, 0);
        private float intensity = 1.0f;

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
            Source.clip = Sound;
            position = pos;
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
