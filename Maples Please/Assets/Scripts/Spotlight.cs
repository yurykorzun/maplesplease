using UnityEngine;

public class Spotlight : MonoBehaviour {

	// drag/smooth time for the spotlight
	public float FloatTime = .05F;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		// Get the mouse position
		var mousePos = Input.mousePosition;

		// check bounds
		checkBounds(ref mousePos);

		// update spotlight position
		updateSpotlightPosition(mousePos);

		// detect enemy
		detectEnemy();
	}

	void checkBounds(ref Vector3 mousePos) {

		// Get the camera position
		var cameraPos = Camera.main.pixelRect;

		// x bounds
		mousePos.x = Mathf.Clamp(mousePos.x, cameraPos.xMin, cameraPos.xMax);

		// y bounds
		mousePos.y = Mathf.Clamp(mousePos.y, cameraPos.yMin, cameraPos.yMax);
	}

	void updateSpotlightPosition(Vector3 mousePos) {

		// Get a vector for the Camera from the mouse position
		Vector3 pz = Camera.main.ScreenToWorldPoint(mousePos);
		pz.z = this.transform.position.z;

		// Update the transform with the mouse position
		Vector3 velocity = new Vector3();
		this.transform.position = Vector3.SmoothDamp(this.transform.position, pz, ref velocity, FloatTime);
	}

	void detectEnemy() {

	}
}
