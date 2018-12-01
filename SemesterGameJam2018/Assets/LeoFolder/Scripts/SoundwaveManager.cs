using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundwaveManager : MonoBehaviour {

    public static SoundwaveManager instance;
    public GameObject lightSphere;
    public AnimationCurve falloff;
    public Material mat;
    private float waveHeight;

	// Use this for initialization
	void Awake () {
        instance = this;
        mat.SetFloat("_Debug", 0);
    }

    public static void PlaceSoundSource(Vector3 position, float range, float endurance, Color color)
    {
        instance.StartCoroutine(instance.fade(position, range, endurance, 1, color));
    }

    void Update()
    {
        waveHeight += Time.deltaTime * 2;
        mat.SetFloat("_WaveY", waveHeight);
    }

    IEnumerator fade(Vector3 position, float range, float endurance, float intensity, Color color)
    {
        Light l = Instantiate(lightSphere, position, Quaternion.identity).GetComponent<Light>();
        l.color = color;
        l.range = range;
        waveHeight = position.y - 1;
        for (float a = 0; a < endurance; a += 0.02f)
        {
            l.range = range * falloff.Evaluate(a/endurance);
            l.intensity = intensity * falloff.Evaluate(a / endurance);
            yield return new WaitForSeconds(0.02f);
        }
        Destroy(l.gameObject);
    }

    void OnDestroy()
    {
        mat.SetFloat("_Debug", 1);
    }
}
