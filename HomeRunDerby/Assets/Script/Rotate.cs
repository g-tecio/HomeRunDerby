﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    

     //Target rotation speed
     public float rotateSpeed = 0.5f;
 
     //Max angle rotation
     public float maxAngle = 30.0f;
 
     //Rotationtarget
     public Transform target;
 
     //Origin Angle
     public float originAngle = 0.0f;
 
     //Reset position?
     public bool resetPosition;
 
     //The Current Angle
     public float currentAngle;
 
     //Actual rotation speed
     private float rotSpeed;
     
 
     void Update(){
 
         //Calculate target rotation speed
         rotSpeed = rotateSpeed * Time.deltaTime;
 
         //Get the current angle
         currentAngle = target.localEulerAngles.z;
     
         //If current value is between 180 and 360 degrees, get it's negative equivalent
         //This just makes the math easier
         currentAngle = (currentAngle > 180) ? currentAngle - 360 : currentAngle;
 
         //If the current angle is greater than the max angle, set it equal to the max angle
         if (currentAngle > maxAngle) {
             currentAngle = maxAngle;
         }
         //Or If the current angle is smaller than the negative max angle equivalent, 
         //set it equal to the negative max angle equivalen
         else if(currentAngle < -maxAngle){
             currentAngle = -maxAngle;
         }
 
 
         //If press A, rotate the angle to the left, at the specified speed
         if (Input.GetMouseButton(0)){
             if (currentAngle < maxAngle) {
                 target.Rotate (0, 0, rotSpeed);
             }
         }
 
         //If press D, rotate the angle to the right, at the specified rotation speed
         if (Input.GetMouseButton(1)) {
 
         if (currentAngle > -maxAngle) {
                 target.Rotate (0, 0, -rotSpeed);
             
             }
         }
 
         //If either A or D is released, then set reset position to true
         if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1) ) {
             resetPosition = true;
         }
 
         //If reset position is set to true
         if (resetPosition == true) {
         
             //And as long as A or D are not pressed 
             if ((!Input.GetMouseButton(0) && !Input.GetMouseButton(1))) {
 
                 //If the current angle is greater than the origin angle then decrease it's value
                 if (currentAngle > originAngle) {
                     target.Rotate (0, 0, -rotSpeed);
                 } 
                 //Or if the current angle is less than origin angle then increase it's value
                 else if (currentAngle < originAngle) {
                     target.Rotate (0, 0, rotSpeed);
                 }
 
                 //If the current angle is between 0.1 and -0.1 degrees, then set reset to false
                 if (currentAngle < 0.1f && currentAngle > -0.1f) {
                     currentAngle = 0;
                     resetPosition = false;
                 }
             }
         }
     }
     
     void OnCollisionEnter2D(Collision2D col)
     {
         if (col.gameObject.tag == "ball" && currentAngle < 0.0)
         {
            col.rigidbody.AddForce(new Vector2(0,0), ForceMode2D.Impulse);
         } else if (currentAngle > 10.00)
         {
              col.rigidbody.AddForce(new Vector2(0,30), ForceMode2D.Impulse);
         }
     }
     

}
