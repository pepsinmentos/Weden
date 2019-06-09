using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PreviewController : MonoBehaviour
{

    public int Width;
    public int Length;
    //public int Rotation;

    public Text WidthText;
    public Text LengthText;
    //public Text RotationText;
    public GameObject Ground;


    void Start()
    {
        SetSize();
    }


    public void SetSize()
    {
        transform.localScale = new Vector2(Width, Length);
    }

    public void SetWidth()
    {
        Width = int.Parse(WidthText.text);
        SetSize();
    }

    public void SetLength()
    {
        Length = int.Parse(LengthText.text);
        SetSize();
    }

    //public void SetRotation()
    //{
    //    Rotation = int.Parse(RotationText.text);
    //    transform.eulerAngles = new Vector3(0, 0, Rotation);
    //}

    public void Generate()
    {
        Ground.transform.localScale = new Vector2(Width, Length);
        //Ground.transform.eulerAngles = new Vector3(0, 0, Rotation);

    }
}
