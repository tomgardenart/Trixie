﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform ObjectToFollow;
    public float FollowSpeed;

    private Rigidbody2D followBody;
    
    private float xMin = 0f;
    private float xMax = 1000f;
    private float yMin = 0f;
    private float yMax = 40f;
    
    private float xOffset = 0f;
    private float yOffset = 0f;

    private void Start ()
    {
        if (FollowSpeed == 0f && ObjectToFollow != null)
        {
            Debug.LogWarning("Camera follow object set but speed is zero");
        }

        followBody = ObjectToFollow.GetComponent<Rigidbody2D>();
    }
	
	private void FixedUpdate ()
    {
        if (followBody != null)
        {
            xOffset = Mathf.Lerp(xOffset, followBody.velocity.x, Time.deltaTime * FollowSpeed);
            yOffset = Mathf.Lerp(yOffset, followBody.velocity.y * 0.75f, Time.deltaTime * FollowSpeed);
        }

        Vector2 targetPos = new Vector2();
        targetPos.x = Mathf.Clamp(ObjectToFollow.position.x + xOffset, xMin, xMax);
        targetPos.y = Mathf.Clamp(ObjectToFollow.position.y + yOffset, yMin, yMax);
        
        Vector2 newPos = Vector2.Lerp(transform.position, targetPos, 2 * Time.deltaTime);
        transform.position = new Vector3(newPos.x, newPos.y, transform.position.z);
	}
}
