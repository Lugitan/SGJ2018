using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ScaleToLightRange : MonoBehaviour {

    private Light lightSource;

	// Use this for initialization
	void Start () {
        lightSource = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.localScale = new Vector3(lightSource.range, lightSource.range, lightSource.range);
	}
}
