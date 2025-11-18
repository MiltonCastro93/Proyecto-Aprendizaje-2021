using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class sistemCam : MonoBehaviour {
    [SerializeField] GameObject _pivoteMaster;
    [SerializeField] GameObject _ejeX, _ejeZ;
    [SerializeField] Vector3 _positions = Vector3.zero;
    [SerializeField] BoxCollider _cajaEvento;//remodificar posicion de la camara
    [SerializeField] bool _inLeft = false;
    [SerializeField] private GameObject _player;
    [SerializeField] private float _heightCam = 2f;

    // Start is called before the first frame update
    void Start() {
        _positions.x = (_ejeX.transform.localPosition.x - _pivoteMaster.transform.localPosition.x) / 2f;
        _positions.z = (_ejeZ.transform.localPosition.z - _pivoteMaster.transform.localPosition.z) / 2f;
        if (_cajaEvento == null) {
            _cajaEvento = gameObject.AddComponent<BoxCollider>();
            _cajaEvento.center = _positions + new Vector3(0f, 0.5f, 0f);
            _cajaEvento.size = new Vector3(_ejeX.transform.localPosition.x, 1f, _ejeZ.transform.localPosition.z);
            _cajaEvento.isTrigger = true;
        }
    }

    private void OnTriggerStay(Collider other) {
        if (_player != null) {
            Vector3 side = _player.transform.InverseTransformPoint(transform.position) * -1f;
            _inLeft = side.x <= _positions.x;
            Debug.Log(side);
            if(side.x <= _positions.x) {
                Debug.Log("Estoy del lado Izquierdo " + _inLeft);
            }
            if (side.x > _positions.x) {
                Debug.Log("Estoy del lado Derecho " + _inLeft);
            }

        }

    }


    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            _player = other.gameObject;
            _player.GetComponent<CameraLookMe>()._sistemCam = this;
        }

    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            _player = null;
        }

    }

    public Vector3 positionCam() {
        if (_inLeft) {
            return transform.TransformPoint(_ejeZ.transform.localPosition + new Vector3(0, _heightCam, 0));
        } else {
            return transform.TransformPoint((_ejeX.transform.localPosition + _ejeZ.transform.localPosition) + new Vector3(0, _heightCam, 0));
        }

    }


    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.TransformPoint(_pivoteMaster.transform.localPosition), transform.up);
        Gizmos.DrawLine(transform.TransformPoint(_ejeX.transform.localPosition), transform.up);
        Gizmos.DrawLine(transform.TransformPoint(_ejeZ.transform.localPosition), transform.up);
        Gizmos.DrawWireSphere(transform.TransformPoint(_positions), 0.5f);
        Gizmos.DrawWireCube(transform.TransformPoint(_positions + new Vector3(0f,0.5f,0f)), new Vector3(_ejeX.transform.localPosition.x, 1f, _ejeZ.transform.localPosition.z));

    }

}
