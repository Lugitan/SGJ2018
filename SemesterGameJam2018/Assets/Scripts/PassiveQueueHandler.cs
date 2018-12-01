using UnityEngine;
using SoundQueueSystem;
using System.Collections;

public class PassiveQueueHandler : MonoBehaviour {

    public float intenstiy = 1.0f;
    public AudioClip clip;
    public float m_timer = 10.0f;

    private SoundQueue m_sq;
    private float m_t;

	// Use this for initialization
	void Start () {
        m_sq = gameObject.AddComponent<SoundQueue>();

        m_sq.Intensity = intenstiy;
        m_sq.Sound = clip;
        m_sq.Source = gameObject.AddComponent<AudioSource>();

        m_t = m_timer;
	}
	
	// Update is called once per frame
	void Update () {
        m_t -= Time.deltaTime;
        if(m_t < 0)
        {
            m_t = m_timer;
            m_sq.InvokeQueue(transform.position);
        }
	}
}
