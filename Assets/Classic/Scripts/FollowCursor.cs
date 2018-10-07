using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TastyCirclesClassic
{
    public class FollowCursor : MonoBehaviour
    {
        public float speed;
        float speedByDistanceMultiplier;
        public float maxMultiplier;
        public static Vector3 cursorPos;

        Vector2 playArea;

        private void Start()
        {
            playArea = GameManager.instance.playArea;
        }

        void Update()
        {
            Vector3 temp = Input.mousePosition;
            temp.z = Mathf.Abs(Camera.main.transform.position.z);
            cursorPos = Camera.main.ScreenToWorldPoint(temp);
            float distanceToCursor = Vector3.Distance(transform.position, cursorPos);
            speedByDistanceMultiplier = Mathf.Clamp(distanceToCursor, 0, maxMultiplier);

            Vector3 bouncePos = transform.position;
            transform.position = Vector3.MoveTowards(transform.position, cursorPos, speed * speedByDistanceMultiplier * Time.deltaTime);

            //Check for borders
            if (transform.position.x > playArea.x)
            {
                bouncePos.x = playArea.x - 0.1f;
                transform.position = bouncePos;
            }
            else if (transform.position.x < -playArea.x)
            {
                bouncePos.x = -playArea.x + 0.1f;
                transform.position = bouncePos;
            }
            else if (transform.position.y > playArea.y)
            {
                bouncePos.y = playArea.y - 0.1f;
                transform.position = bouncePos;
            }
            else if (transform.position.y < -playArea.y)
            {
                bouncePos.y = -playArea.y + 0.1f;
                transform.position = bouncePos;
            }
        }
    }
}
