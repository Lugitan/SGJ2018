using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanLight : MonoBehaviour {

    private Light l;
    public Light parentLight;
    public float speed;

	// Use this for initialization
	void Start () {
        l = GetComponent<Light>();
        l.intensity = 0;
        l.color = parentLight.color;
        transform.SetParent(null);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += Vector3.up * speed * Time.deltaTime;
        if (parentLight == null) { Destroy(gameObject); return; }
        l.range = parentLight.range;
        l.intensity = parentLight.intensity;
	}
}
