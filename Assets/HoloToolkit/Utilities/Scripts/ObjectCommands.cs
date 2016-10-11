using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectCommands : MonoBehaviour {
    
    public bool isSelected;
    private static float radian = 0.0174533f;
	// Called by GazeGestureManager when the user performs a Select gesture
    void OnSelect()
    {
        Debug.Log("ON_SELECT");
        if (!this.isSelected)
        {
            this.isSelected = true;
        }else
        {
            this.isSelected = false;
        }
        /**if (!this.GetComponent<Rigidbody>())
        {
            var rigidbody = this.gameObject.AddComponent<Rigidbody>();
            rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        }*/
    }
    void Update()
    {

        
        if (this.isSelected)
        {
            var gazeDirection = Camera.main.transform.forward;
            var headPosition = Camera.main.transform.position;
            var headRotation = Camera.main.transform.eulerAngles;
            float x = (float)Math.Sin(System.Convert.ToDouble(headRotation.y.ToString()) * radian);
            float y = -(float)Math.Sin((System.Convert.ToDouble(headRotation.x.ToString())) * radian);
            float z = (float)Math.Cos(System.Convert.ToDouble(headRotation.y.ToString()) * radian);

           // x *= (float)Math.Cos((System.Convert.ToDouble(headRotation.x.ToString())) * radian);
           // z *= (float)Math.Cos((System.Convert.ToDouble(headRotation.x.ToString())) * radian);



            var newPosition = headPosition + new Vector3(x * 2, y*2, z*2);
            this.gameObject.transform.position = newPosition;
            this.gameObject.transform.eulerAngles = headRotation;
          
           

        }
    }
  

    
}
