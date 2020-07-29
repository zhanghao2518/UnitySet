using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interfere : MonoBehaviour {

                 private Rigidbody rb;
                 void Start ()
                 {
                       rb = GetComponent<Rigidbody>();
                 }

                 void OnTriggerEnter (Collider other) {
                       if (other.gameObject.CompareTag("PickUp"))
                       {
                             other.gameObject.SetActive (false);
                       }
                 }
}
