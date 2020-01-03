package com.example.sudoku;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

import org.w3c.dom.Text;

import java.util.Arrays;
import java.util.Random;

public class MainActivity extends AppCompatActivity {

    private static final int SUDOKU_SIZE = 9;
    int[][] Sudoku = {
            {1, 2, 3, 4, 5, 6, 7, 8, 9},
            {4, 5, 6, 7, 8, 9, 1, 2, 3},
            {7, 8, 9, 1, 2, 3, 4, 5, 6},
            {2, 3, 1, 5, 6, 4, 8, 9, 7},
            {5, 6, 4, 8, 9, 7, 2, 3, 1},
            {8, 9, 7, 2, 3, 1, 5, 6, 4},
            {3, 1, 2, 6, 4, 5, 9, 7, 8},
            {6, 4, 5, 9, 7, 8, 3, 1, 2},
            {9, 7, 8, 3, 1, 2, 6, 4, 5}
    };

    int x = 0;
    int y = 0;

    boolean checkSudoku = true;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        Button btn1 = findViewById(R.id.B1);
        Button btn2 = findViewById(R.id.B2);
        Button btn3 = findViewById(R.id.B3);
        Button btn4 = findViewById(R.id.B4);
        Button btn5 = findViewById(R.id.B5);
        Button btn6 = findViewById(R.id.B6);
        Button btn7 = findViewById(R.id.B7);
        Button btn8 = findViewById(R.id.B8);
        Button btn9 = findViewById(R.id.B9);
        Button btnX = findViewById(R.id.x);
        Button btnY = findViewById(R.id.y);

        TextView Final = findViewById(R.id.Final);
        Button btn_check = findViewById(R.id.Check);
        Button btn_random = findViewById(R.id.Random);

        Settext();

        btn1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Sudoku[x][y] = 1;
                Settext();
            }
        });

        btn2.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Sudoku[x][y] = 2;
                Settext();
            }
        });
        btn3.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Sudoku[x][y] = 3;
                Settext();
            }
        });
        btn4.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Sudoku[x][y] = 4;
                Settext();
            }
        });
        btn5.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Sudoku[x][y] = 5;
                Settext();
            }
        });
        btn6.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Sudoku[x][y] = 6;
                Settext();
            }
        });
        btn7.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Sudoku[x][y] = 7;
                Settext();
            }
        });
        btn8.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Sudoku[x][y] = 8;
                Settext();
            }
        });
        btn9.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Sudoku[x][y] = 9;
                Settext();
            }
        });
        btnX.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                x = x + 1;
                if (x >= 9)
                    x = 0;
                TextView X_text = findViewById(R.id.XX);
                X_text.setText(Integer.toString(x + 1));
            }
        });
        btnY.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                y = y + 1;
                if (y >= 9)
                    y = 0;
                TextView Y_text = findViewById(R.id.YY);
                Y_text.setText(Integer.toString(y + 1));
            }
        });
        btn_check.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                CheckSUDOCU();
            }
        });
        btn_random.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                RandomSudoku();
                Settext();
            }
        });
    }

    public void Settext() {
        TextView Sudoku_text = findViewById(R.id.L);
        String temp1;
        String temp2;
        String Text = "";
        for (int i = 0; i < SUDOKU_SIZE; i++) {
            temp2 = " ";
            for (int j = 0; j < SUDOKU_SIZE; j++) {
                temp1 = Integer.toString(Sudoku[i][j]);
                temp2 = temp2 + temp1 + " ";
            }
            Text = Text + temp2;
            Text = Text + "\n";
        }
        Sudoku_text.setText(Text);
    }

    class RowCheck extends Thread {
        public void run() {
            boolean[] Check = new boolean[SUDOKU_SIZE];
            for(int i = 0; i < SUDOKU_SIZE; i++){
                for(int j = 0 ; j <  SUDOKU_SIZE; j++)
                    Check[j] = false;
                for(int j = 0 ; j <  SUDOKU_SIZE; j++){
                    if(Check[Sudoku[i][j] - 1] == false)
                        Check[Sudoku[i][j] - 1] = true;
                    else
                        checkSudoku = false;
                }
            }
        }
    }

    class ColumnCheck extends Thread {
        public void run() {
           boolean[] Check = new boolean[SUDOKU_SIZE];
           for(int i = 0; i < SUDOKU_SIZE; i++){
               for(int j = 0 ; j <  SUDOKU_SIZE; j++)
                   Check[j] = false;
               for(int j = 0 ; j <  SUDOKU_SIZE; j++){
                    if(Check[Sudoku[j][i] - 1] == false)
                        Check[Sudoku[j][i] - 1] = true;
                    else
                        checkSudoku = false;
               }
           }
        }
    }

    class BoxCheck extends Thread {
        int BoxNumber;
        public void run() {
            boolean[] Check = new boolean[SUDOKU_SIZE];
            for (int i = (BoxNumber / 3) * 3; i < (BoxNumber / 3) * 3 + 3; i++) {
                for (int j = 0; j < SUDOKU_SIZE; j++)
                    Check[j] = false;
                for (int j = (BoxNumber % 3) * 3; j < (BoxNumber % 3) * 3 + 3; j++) {
                    if (Check[Sudoku[i][j] - 1] == false)
                        Check[Sudoku[i][j] - 1] = true;
                    else
                        checkSudoku = false;
                }
            }
        }
    }

    public void CheckSUDOCU() {
        checkSudoku = true;
        RowCheck RC = new RowCheck();
        ColumnCheck CC = new ColumnCheck();
        BoxCheck[] BC = new BoxCheck[SUDOKU_SIZE];
        for (int i = 0; i < SUDOKU_SIZE; i++)
            BC[i] = new BoxCheck();

        RC.start();
        CC.start();
        for (int i = 0; i < SUDOKU_SIZE; i++) {
            BC[i].BoxNumber = i;
            BC[i].start();
        }
        try {
            RC.join();
            CC.join();
            for (int i = 0; i < SUDOKU_SIZE; i++)
                BC[i].join();
        } catch (Exception e) {
        }
        TextView EndText = findViewById(R.id.Final);
        if (checkSudoku == true)
            EndText.setText("SUCCESS");
        else
            EndText.setText("FAIL");
    }

    public void RandomSudoku(){
        boolean[] array = new boolean[SUDOKU_SIZE];
        for (int i = 0; i < 9; i++)
            array[i] = false;
        Random randomGenerator = new Random();

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                int temp;
                while (array[temp = randomGenerator.nextInt(SUDOKU_SIZE)]) ;
                Sudoku[i][j] = temp + 1;
                array[temp] = true;
            }
        }
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                Sudoku[i + 3][(j + 1) % 3] = Sudoku[i + 6][(j + 2) % 3] = Sudoku[i][j];

        for (int i = 0; i < 9; i++)
            for (int j = 0; j < 3; j++)
                Sudoku[(i / 3) * 3 +  (i + 1) % 3][j + 3] = Sudoku[(i / 3) *3 + (i + 2) % 3][j + 6] = Sudoku[i][j];
    }
}
