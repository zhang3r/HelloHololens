using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR.WSA.Input;

public class GazeGestureManager : MonoBehaviour {

	// Use this for initialization
    public static GazeGestureManager Instance { get; private set; }
    // selected object
    public GameObject FocusedObject { get; private set; }

    GestureRecognizer recognizer;

    // initialization
    void Awake()
    {
        Instance = this;

        //setting up Gesture Recognizer
        recognizer = new GestureRecognizer();
        recognizer.TappedEvent += (source, tapCount, ray) =>
         {
             //send OnSelect message to the focused object
             if(FocusedObject != null)
             {
                 FocusedObject.SendMessageUpwards("OnSelect");
             }
         };
        recognizer.StartCapturingGestures();
    }
	
	// Update is called once per frame
	void Update () {

        GameObject oldFocusObject = FocusedObject;

        //Do a raycast into the world based on the suers head position

        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;

        RaycastHit hitInfo;
        if(Physics.Raycast(headPosition, gazeDirection, out hitInfo))
        {
            //if the raycast hit a hologram use that as focus object
            FocusedObject = hitInfo.collider.gameObject;
        }
        else
        {
            //if raycast didn't hit anything clear object
            FocusedObject = null;
        }
        //new object is selected
        if (FocusedObject != oldFocusObject)
        {
            recognizer.CancelGestures();
            recognizer.StartCapturingGestures();
        }
	}
}
