using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Gizmo for a specific manipulation mode (translate, rotate, scale) on an object.
/// </summary>
public class ModeGizmo : MonoBehaviour
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowGizmo(bool show)
    {
        gameObject.SetActive(show);
    }
}
