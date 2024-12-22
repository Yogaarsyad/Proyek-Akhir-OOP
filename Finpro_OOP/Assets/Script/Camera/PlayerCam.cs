using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    GameObject playerPos;
    bool followPlayer = true;
    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            followPlayer = false;
        }
        else
        {
            followPlayer = true;
        }
        if (followPlayer)
        {
            FollowPlayer();
        }
        else
        {
            LookAhead();
        }
    }

    public void setFollowPlayer(bool follow)
    {
        followPlayer = follow;
    }

    void FollowPlayer()
    {
        Vector3 newPos = new Vector3(playerPos.transform.position.x, playerPos.transform.position.y, transform.position.z);
        this.transform.position = newPos;
    }

    void LookAhead()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 lookDir = mousePos - playerPos.transform.position;
        float halfHeight = Camera.main.orthographicSize;
        float halfWidth = halfHeight * Camera.main.aspect;
        if (lookDir.x > 2*halfWidth)
        {
            lookDir.x = 2*halfWidth;
        }
        else if (lookDir.x < -2*halfWidth)
        {
            lookDir.x = -2*halfWidth;
        }
        if (lookDir.y > 2*halfHeight)
        {
            lookDir.y = 2*halfHeight;
        }
        else if (lookDir.y < -2*halfHeight)
        {
            lookDir.y = -2*halfHeight;
        }
        transform.position = new Vector3(playerPos.transform.position.x + lookDir.x / 2, playerPos.transform.position.y + lookDir.y / 2, transform.position.z);
    }
}
