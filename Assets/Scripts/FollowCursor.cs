using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCursor : MonoBehaviour
{
    public float speed;
    float speedByDistanceMultiplier;
    public float maxMultiplier;
    public static Vector3 cursorPos;

    void Update()
    {
        Vector3 temp = Input.mousePosition;
        temp.z = Mathf.Abs(Camera.main.transform.position.z);
        cursorPos = Camera.main.ScreenToWorldPoint(temp);
        float distanceToCursor = Vector3.Distance(transform.position, cursorPos);
        speedByDistanceMultiplier = Mathf.Clamp(distanceToCursor, 0, maxMultiplier);
        transform.position = Vector3.MoveTowards(transform.position, cursorPos, speed * speedByDistanceMultiplier * Time.deltaTime);
    }
}
