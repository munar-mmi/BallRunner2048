using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Point : MonoBehaviour
{
    public enum pointTypes { Player, Point, Barrier, Star };

    public TextMeshPro pointValueText;
    public int pointValue;
    public int starValue;
    public pointTypes pointType;
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

    public void GameOver()
    {
        pointValue = 2;
        starValue = 0;
        ChangePlayer();

        transform.localScale = new Vector3(4.0f, 4.0f, 4.0f);
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.SetActive(false);

        Destroy(GameObject.Find("Level(Clone)"));
    }

    void OnCollisionEnter(Collision collision)
    {
        Point point = collision.gameObject.GetComponent<Point>();
        if (point)
        {
            if (point.pointValue == pointValue)
            {
                pointValue *= 2;
                ChangePlayer();

                this.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);

                Destroy(collision.gameObject);
            }

            else if (point.pointType.HasFlag(pointTypes.Star) & pointType.HasFlag(pointTypes.Player))
            {
                starValue++;

                Destroy(collision.gameObject);
            }
            
            else if (point.pointType.HasFlag(pointTypes.Barrier) & pointValue >=4)
            {
                pointValue /= 2;
                ChangePlayer();

                this.transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
            }
        }
    }
}
