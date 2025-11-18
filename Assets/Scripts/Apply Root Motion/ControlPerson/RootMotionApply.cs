using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootMotionApply : MonoBehaviour
{
    public GameObject pivote;
    public Animator animator;
    public CharacterController _cC;
    private Quaternion rotApply = Quaternion.identity;
    public bool RotComplete;

    void Update() {
        float vertical = Input.GetAxis("Vertical");
        if (vertical <= -1f) {
            animator.Play("Turn");
        }

        _cC.Move(pivote.transform.forward * vertical * Time.deltaTime);
        if(vertical >= 1f) {
            transform.rotation = pivote.transform.rotation;
        }
        Quaternion newRot = transform.rotation;
        newRot.x = 0f;
        newRot.z = 0f;
        transform.rotation = newRot;
    }

    public void CallRot() {
        RotComplete = true;
        rotApply = transform.rotation;
        animator.Play("Idle");
        Debug.Log("Termino la vuelta");
    }

}
