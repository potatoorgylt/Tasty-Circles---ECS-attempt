using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TastyCirclesClassic
{
    public class PupilMovement : MonoBehaviour
    {
        PlayerManager playerManager;

        Vector2 playArea;

        private void Start()
        {
            playArea = GameManager.instance.playArea;

            playerManager = GetComponent<PlayerManager>();
        }
        private void Update()
        {
            //We find the distance from center of the eye to the targer
            Vector3 distanceToTarget = FollowCursor.cursorPos - playerManager.eyeball.transform.position;

            distanceToTarget = Vector3.ClampMagnitude(distanceToTarget, playerManager.getEyeballWidth() / 2 - playerManager.getPupilWidth() / 2);

            Vector3 finalPupilPosition = playerManager.eyeball.transform.position + distanceToTarget;

            playerManager.pupil.transform.position = Vector3.MoveTowards(transform.position, finalPupilPosition, 20.0f * Time.deltaTime);
        }
    }
}
