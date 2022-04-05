using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Point : MonoBehaviour
{
    public enum pointTypes { Point, Barrier };

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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Point>())
        {
            Point point = collision.gameObject.GetComponent<Point>();
            if (point.pointType == pointTypes.Barrier & pointValue >= 4)
            {
                pointValue /= 2;
                ChangePlayer();

                this.transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
            }
        }
    }
}
