using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingScript : MonoBehaviour {

    private bool walking = false;
    private Vector3 spawnPoint;

    // Use this for initialization
    void Start () {
        spawnPoint = transform.position;
        //transform.position = new Vector3(74, 49.8f, 124.8f);
    }
	
	// Update is called once per frame
	void Update () {
        //if we fall out of the map
        if (transform.position.y < -1)
        {
            transform.position = spawnPoint;
        }

        //if walking go
        if (walking)
        {
            transform.position = transform.position + Camera.main.transform.forward * .9f * Time.deltaTime;
            
        }
        
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f, 0));
        RaycastHit hit;

        //stop
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.name.Contains("plane"))
            {
                walking = false;
            }
            else
            {
                walking = true;
            }

        } 
    }
}
