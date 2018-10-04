using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PupilMovement : MonoBehaviour
{
    public GameObject eyeball;
    public GameObject pupil;

    private void Update()
    {
        //We find the distance from center of the eye to the targer
        Vector3 distanceToTarget = FollowCursor.cursorPos - eyeball.transform.position;

        float eyeballWidth = eyeball.GetComponent<SpriteRenderer>().bounds.size.x;
        float pupilWidth = pupil.GetComponent<SpriteRenderer>().bounds.size.x;
        distanceToTarget = Vector3.ClampMagnitude(distanceToTarget, eyeballWidth/2-pupilWidth/2);

        Vector3 finalPupilPosition = eyeball.transform.position + distanceToTarget;
        pupil.transform.position = Vector3.MoveTowards(transform.position, finalPupilPosition, 20.0f * Time.deltaTime);
    }
}
