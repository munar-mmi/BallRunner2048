using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public TextMeshPro pointValueText;
    public ParticleSystem particle;
    public int pointValue;
    public int starValue;
    public Color[] pointColors;

    void Start()
    {
        ChangePlayer();
    }

    void ChangePlayer()
    {
        if (pointValue > 0)
        {
            pointValueText.text = $"{pointValue}";
            GetComponent<Renderer>().material.color =
                pointColors[(int)Mathf.Log((float)pointValue, (float)2) - 1];
        }
    }
    public void GameOver(GameObject levelArea)
    {
        pointValue = 2;
        starValue = 0;
        ChangePlayer();

        transform.localScale = new Vector3(4.0f, 4.0f, 4.0f);
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.SetActive(false);

        Destroy(levelArea);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Point>())
        {
            Point point = collision.gameObject.GetComponent<Point>();
            if (point.pointValue == pointValue)
            {
                pointValue *= 2;
                ChangePlayer();

                transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);

                var emission = particle.emission;
                emission.enabled = true;
                particle.Play();

                Destroy(collision.gameObject);
            }

            else if (point.pointType == Point.pointTypes.Barrier & pointValue >= 4)
            {
                pointValue /= 2;
                ChangePlayer();

                transform.localScale -= new Vector3(0.2f, 0.2f, 0.2f);
            }
        }
        else if (collision.gameObject.GetComponent<Star>())
        {
            starValue++;

            Destroy(collision.gameObject);
        }
    }
}
