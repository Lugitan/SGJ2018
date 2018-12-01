using UnityEngine;

public class ClickWaves : MonoBehaviour {

    public Camera cam;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit))
            {
                SoundwaveManager.PlaceSoundSource(hit.point + hit.normal * 0.2f, 10, 2, Random.ColorHSV());
            }
        }
	}
}
