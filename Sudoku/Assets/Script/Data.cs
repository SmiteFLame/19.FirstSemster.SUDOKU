using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Data : MonoBehaviour
{
    public Text CheckText;
    public GameObject[] NumberButton;

    private int ButtonNumber;
    private int[,] Sudoku = {
            { 1,2,3,4,5,6,7,8,9 },
            { 4,5,6,7,8,9,1,2,3 },
            { 7,8,9,1,2,3,4,5,6 },
            { 2,3,1,5,6,4,8,9,7 },
            { 5,6,4,8,9,7,2,3,1 },
            { 8,9,7,2,3,1,5,6,4 },
            { 3,1,2,6,4,5,9,7,8 },
            { 6,4,5,9,7,8,3,1,2 },
            { 9,7,8,3,1,2,6,4,5 }
        };
    private int x;
    private int y;
   
    void Start()
    {
        x = 0;
        y = 0;
    }

    // Update is called once per frame
    void Update()
    {
        int TextX = x + 1;
        int TextY = y + 1;
        CheckText.text = TextY.ToString("0") + "행," + TextX.ToString("0") + "열 입력 ";
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
            ButtonNumber = -1;
            if (hit.collider != null)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (hit.collider.transform == NumberButton[i].transform)
                    {
                        ButtonNumber = i;
                    }
                }

                if (hit.collider != null && ButtonNumber != -1)
                {
                    Sudoku[x, y] = ButtonNumber + 1;
                }
            }

        }
    }

    public void SetText(int _x, int _y)
    {
        x = _x;
        y = _y;
    }

    public int GetData(int _x, int _y)
    {
        return Sudoku[_x, _y];
    }

    public void SetSudokuIndex(int _SudokuNumber,int _i, int _j)
    {
        Sudoku[_i, _j] = _SudokuNumber;
    }
}
