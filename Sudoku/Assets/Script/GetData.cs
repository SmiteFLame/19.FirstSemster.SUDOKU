using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetData : MonoBehaviour
{
    public int x;
    public int y;
    private int Data;

    public GameObject WSprite;
    public Sprite[] Number;

    private Data DataScript;
    private GameObject DataBox;
    private GameObject Temp;
    private SpriteRenderer WSprite_Sprite;

   
    void Start()
    {
        DataBox = GameObject.Find("Data");
        DataScript = DataBox.GetComponent<Data>();
        WSprite_Sprite = WSprite.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
            if (hit.collider != null && hit.collider.transform == this.transform)
            {
                DataScript.SetText(x, y);
            }

        }
        Data = DataScript.GetData(x, y) - 1;
        WSprite_Sprite.sprite = Number[Data];
    }


    public void Set(int _x, int _y)
    {
        x = _x;
        y = _y;
    }

    public int GetX()
    {
        return x;
    }

    public int GetY()
    {
        return y;
    }
}
