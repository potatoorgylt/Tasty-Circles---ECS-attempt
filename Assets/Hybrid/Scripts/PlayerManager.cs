using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TastyCirclesHybrid
{
    public class PlayerManager : MonoBehaviour
    {
        public GameObject eyeball;
        public GameObject pupil;

        float pupilWidth;
        float eyeballWidth;
        float scale;

        float area;

        SpriteRenderer pupilRenderer;
        SpriteRenderer eyeballRenderer;

        private void Start()
        {
            pupilRenderer = pupil.GetComponent<SpriteRenderer>();
            eyeballRenderer = eyeball.GetComponent<SpriteRenderer>();

            scale = gameObject.transform.localScale.x;
            area = Mathf.PI * Mathf.Pow(gameObject.transform.localScale.x / 2f, 2);
        }

        private void Update()
        {
            if (getScale() >= 4f)
            {
                GameManager.instance.Victory();
            }
            else if (getScale() <= 0.1f)
            {
                GameManager.instance.Defeat();
            }
        }

        public float getPupilWidth()
        {
            return pupilWidth = pupilRenderer.bounds.size.x;
        }

        public float getEyeballWidth()
        {
            return eyeballWidth = eyeballRenderer.bounds.size.x;
        }

        public float getArea()
        {
            return area;
        }

        public void setArea(float area)
        {
            this.area = Mathf.PI * Mathf.Pow(gameObject.transform.localScale.x / 2f, 2);
        }

        public void setScale(float scale)
        {
            gameObject.transform.localScale = new Vector3(scale, scale, scale);
            this.scale = scale;
        }

        public float getScale()
        {
            return scale;
        }
    }
}