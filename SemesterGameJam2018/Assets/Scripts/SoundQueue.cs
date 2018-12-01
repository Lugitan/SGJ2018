using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoundQueueSystem
{
    public class SoundQueue : MonoBehaviour
    {
        private Vector3 position = new Vector3(0, 0, 0);
        private float volume = 1.0f;

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
        public void InvokeQueue(Vector3 pos, float range, float endurance)
        {
            // Set Position of the SoundQueue object
            if(gameObject.tag != "Player")
            {
                gameObject.transform.position = pos;
            }

            SoundwaveManager.PlaceSoundSource(pos, range, endurance, Random.ColorHSV());

            // Set AudioSource Properties
            Source.clip = Sound;
            Source.spatialBlend = spatialBlend;
            Source.volume = volume > 1.0f ? volume / 100.0f: volume;

            Source.Play();
        }

        public float Volume
        {
            get
            {
                return volume;
            }

            set
            {
                volume = value;
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
