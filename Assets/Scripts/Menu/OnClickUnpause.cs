using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickUnpause : MonoBehaviour {

	public void UnPause()
    {
        Time.timeScale = 1.0f;
    }
}
