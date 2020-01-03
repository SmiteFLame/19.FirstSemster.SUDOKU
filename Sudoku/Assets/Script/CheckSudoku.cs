using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class CheckSudoku : MonoBehaviour
{
    public Text EndText;

    private Data DataScript;
    private GameObject DataBox;
    private int[,] Sudoku = new int[9, 9];
    const int SUDOKU_SIZE = 9;
    private bool checkSudoku = true;

    void Start()
    {
        EndText.text = " ";
    }

    // 행을 체크하는 쓰레드가 하는일
    private void rowCheck()
    {
        for (int i = 0; i < SUDOKU_SIZE; i++)
        {
            int Sum = 0;
            int Product = 1;
            for (int j = 0; j < SUDOKU_SIZE; j++)
            {
                Sum += Sudoku[i,j];
                Product *= Sudoku[i,j];
            }
            if (Sum != 45 || Product != 362880)
                checkSudoku = false;
        }
    }

    // 열을 체크하는 쓰레드가 하는일
    private void columnCheck()
    {
        for (int i = 0; i < SUDOKU_SIZE; i++)
        {
            int Sum = 0;
            int Product = 1;
            for (int j = 0; j < SUDOKU_SIZE; j++)
            {
                Sum += Sudoku[j, i];
                Product *= Sudoku[j, i];
            }
            if (Sum != 45 || Product != 362880)
                checkSudoku = false;
        }
    }

    // Box 안에서 9개의 숫자를 판별하는 쓰레드가 하는일
    private void boxCheck(object _BoxNumber)
    {
        int BoxNumber = (int)_BoxNumber;
        int x = BoxNumber / 3;
        int y = BoxNumber % 3;
        int Sum = 0;
        int Product = 1;
        for (int i = x * 3; i < x * 3 + 3; i++)
        {
            for (int j = y * 3; j < y * 3 + 3; j++)
            {
                Sum += Sudoku[i, j];
                Product *= Sudoku[i, j];
            }
        }
        if (Sum != 45 || Product != 362880)
            checkSudoku = false;
    }

    //Button을 누르면 실행되는 것
    public void Execution()
    {
        checkSudoku = true;
        DataBox = GameObject.Find("Data");
        DataScript = DataBox.GetComponent<Data>();
        for (int i = 0; i < SUDOKU_SIZE; i++)
        {
            for(int j = 0; j< SUDOKU_SIZE; j++)
            {
                Sudoku[i,j] = DataScript.GetData(i, j);
            }
        }

        //쓰레드 생성 행을 체크하는 쓰레드 1개 열을 체크하는 쓰레드 1개 박스를 체크하는 쓰레드 9개
        Thread Column = new Thread(new ThreadStart(columnCheck));
        Thread Row = new Thread(new ThreadStart(rowCheck));
        Thread[] Box = new Thread[9];
        for (int i = 0; i < SUDOKU_SIZE; i++)
        {
            Box[i] = new Thread(new ParameterizedThreadStart(boxCheck));
        }

        // 쓰레드를 각각 실행시킨다.
        Column.Start();
        Row.Start();
        for(int i = 0; i< SUDOKU_SIZE; i++)        
            Box[i].Start(i);

        // 쓰레드들 끼리 종료되는 것을 기다린다.
        Column.Join();
        Row.Join();
        for (int i = 0; i < SUDOKU_SIZE; i++)
            Box[i].Join();

        if (checkSudoku == true)
            EndText.text = "S\nU\nC\nC\nE\nS\nS";
        else
            EndText.text = "F\nA\nI\nL";

    }
}