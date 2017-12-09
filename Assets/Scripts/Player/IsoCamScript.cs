using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsoCamScript : MonoBehaviour {

    public GameObject target;
    public float rotationDegrees;
    public float time;

    private bool allow;

	// Use this for initialization
	void Start ()
    {
        allow = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = target.transform.position;
        
        if(allow && (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.Joystick1Button4)))
        {
            allow = false;
            StartCoroutine(Rotation(new Vector3(0, rotationDegrees, 0), time));
        }
        else if (allow && (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.Joystick1Button5)))
        {
            allow = false;
            StartCoroutine(Rotation(new Vector3(0, -rotationDegrees, 0), time));
        }
    }

    IEnumerator Rotation(Vector3 angle, float time)
    {

        Quaternion fromAngle = transform.rotation;
        Quaternion toAngle = Quaternion.Euler(transform.eulerAngles + angle);
        float elapsedTime = 0;
        while (elapsedTime <= time)
        {
            elapsedTime += Time.deltaTime;
            transform.rotation = Quaternion.Lerp(fromAngle, toAngle, (elapsedTime / time));
            yield return new WaitForEndOfFrame();
        }
        allow = true;
        yield return 0;
    }
}
