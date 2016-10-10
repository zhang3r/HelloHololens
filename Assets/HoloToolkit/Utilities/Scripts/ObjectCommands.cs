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
        if (!this.isSelected)
        {
            this.isSelected = true;
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
            float y = -(float)Math.Tan(System.Convert.ToDouble(headRotation.x.ToString()) * radian);
            float z = (float)Math.Cos(System.Convert.ToDouble(headRotation.y.ToString()) * radian);
            z *= (float)Math.Cos(System.Convert.ToDouble(headRotation.x.ToString()) * radian);
            //z = (float)(1 - Math.Pow((double)x,2) - Math.Pow((double)y,2));
            //z = (float)Math.Sqrt(z);
            var newPosition = headPosition + new Vector3(x * 2, y*2, z*2);
            this.gameObject.transform.position = newPosition;
            this.gameObject.transform.eulerAngles = headRotation;
            Debug.Log("new position " + newPosition);
            Debug.Log("new rotation " + headRotation);
           

        }
    }
  

    
}
