using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomSudoku : MonoBehaviour
{
    private Data DataScript;
    private GameObject DataBox;

    private int[,] Sudoku = new int[9, 9];
    private bool[] array = new bool[9];
    public void MakeRandomSudoku()
    {
        DataBox = GameObject.Find("Data");
        DataScript = DataBox.GetComponent<Data>();

        for (int i = 0; i < 9; i++)
            array[i] = false;


        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                int temp;
                while (array[temp = Random.Range(0, 9)]) ;
                Sudoku[i, j] = temp + 1;
                array[temp] = true;
            }
        }
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                Sudoku[i + 3, (j + 1) % 3] = Sudoku[i + 6, (j + 2) % 3] = Sudoku[i, j];

        for (int i = 0; i < 9; i++)
            for (int j = 0; j < 3; j++)
                Sudoku[(i / 3) * 3 +  (i + 1) % 3, j + 3] = Sudoku[(i / 3) *3 + (i + 2) % 3, j + 6] = Sudoku[i, j];
        for (int i = 0; i < 9; i++)
            for (int j = 0; j < 9; j++)
                DataScript.SetSudokuIndex(Sudoku[i, j], i, j);
    }
}
