using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

                 public float speed;
                 public float force;
                 public Text countText;
                 public Text collisionText;
                 public Text winText;

                 private Rigidbody rb;
                 private int count;
                 private int collision;
               
                 private int front;
                 private int behind;

                 void Start ()
                 {
                       rb = GetComponent<Rigidbody>();
                       front = 0;
                       behind = 0;
                       count = 0;
                       collision = 0;
                       SetCountText ();
                       SetCollisionText ();
                       winText.text = "";
                 }

                 void FixedUpdate ()
                 {
                       float moveHorizontal = Input.GetAxis ("Horizontal");
                       float moveVertical = Input.GetAxis ("Vertical");

                       Vector3 movement = new Vector3 (moveHorizontal , 0.0f , moveVertical);

                       rb.AddForce (movement * speed);
                       if(Input.GetKey("a"))
                       {
                             rb.AddForce(Vector3.up * force);
                       }                      
                 }

                 void OnTriggerEnter (Collider other) {
                       if (other.gameObject.CompareTag("PickUp"))
                       {
                             other.gameObject.SetActive (false);
                             count = count + 1;
                             SetCountText ();
                       }
                       if (other.gameObject.CompareTag("interfere"))
                       {
                             collision = collision + 1;
                             SetCollisionText ();
                             count = count - 1;
                             SetCountText ();
                       }
                 }

                 void OnCollisionEnter (Collision other) {
                       if (other.gameObject.CompareTag("interfere1"))
                       {
                             collision = collision + 1;
                             SetCollisionText ();
                             count = count - 1;
                             SetCountText ();
                       }
                       if (other.gameObject.CompareTag("Step"))
                       {
                             if(count < 8)
                             {
                                   other.gameObject.SetActive(false);
                              }
                              if(count >= 8 )
                              {
                                    collision = 0;
                                    SetCollisionText ();
                                    winText.text = "";
                              }
                       }
                       if (other.gameObject.CompareTag("Step1"))
                       {
                             if(count < 15)
                             {
                                   other.gameObject.SetActive(false);
                              }
                              if(count >= 15 )
                              {
                                    countText.text = "";
                                    collisionText.text = "";
                                    winText.text = "";
                              }
                       }
                       if (other.gameObject.CompareTag("play1"))
                       {
                             winText.text = "You Win";
                       }
                       if (other.gameObject.CompareTag("interfereWall"))
                       {
                             collision = collision + 1;
                             SetCollisionText ();
                             count = count - 1;
                             SetCountText ();
                       }
                       if (other.gameObject.CompareTag("front"))
                       {
                             behind = 0;
                             front = 1;
                              winText.text = "add one";
                       }
                       if (other.gameObject.CompareTag("behind") && front == 1)
                       {
                             behind = 1;
                             winText.text = "add two";
                       }else if(other.gameObject.CompareTag("behind") && front == 0){
                             winText.text = "";
                       }
                       if (other.gameObject.CompareTag("right") && front == 1 && behind == 1)
                       {
                             other.gameObject.SetActive(false);
                             winText.text = "";
                             count = count + 2;
                             SetCountText ();
                       }else if (other.gameObject.CompareTag("right") && behind == 0){
                             front = 0 ;
                             winText.text = "";
                       }
                 }

                 void SetCountText (){
                       countText.text = "Count: " + count.ToString();
                       if(count == 8)
                       {
                             winText.text = "First Level";
                        }
                        if(count == 15)
                       {
                             winText.text = "Second Level";
                        }
                        if(count < 8 || (count > 8 && count < 15) || count > 15)
                        {
                              winText.text = "";
                         }
                 }

                 void SetCollisionText (){
                       collisionText.text = "Collision: " + collision.ToString();
                 }
}