using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookMe : MonoBehaviour {
    public Transform _cam;
    public sistemCam _sistemCam;

    // Update is called once per frame
    void Update() {
        if (_sistemCam != null) {
            Vector3 relative = transform.position - _cam.position;
            _cam.transform.position = _sistemCam.positionCam();
            _cam.transform.rotation = Quaternion.LookRotation(relative);
        }
    }

}
