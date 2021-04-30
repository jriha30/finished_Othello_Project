using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;


// This is the project of Jason Riha, Jonathan Yakimow, Zac Miller, and Jacob Wilkins.
// This is Sprint 4 of the Othello project, the final product.


// In this sprint, the main thing we implemented was the menu.

// Added a form to explain the rules of Othello,
// we added a button to quit the game,
// we added a button to play the game.

// Most importantly though, the menu is super cool and fun to interact with!

// Other than the menu, we made some much-needed bug fixes.

// We also changed some of the code on the back-end to make more sense,
// still doesn't make a ton of sense to anyone other than who wrote it,
// but it is quite a bit better than it was before.

namespace Othello
{
    public partial class Form1 : Form
    {
        static int theBoardSize = 8;
        static Board theBoard = new Board(theBoardSize);
        public Button[,] btnGrid = new Button[theBoard.Size, theBoard.Size];
        static Cell[,] cellGrid = theBoard.theGrid;
        string turn = "black";
        int whiteCounter = 0;
        int blackCounter = 0;
        bool isOver = false;

        public Form1()
        {
            InitializeComponent();
            populateBoard();
            turnLabel.Text = turn;
        }

        private void populateBoard()
        {
            /*Loops through each row and column to initalize the buttons*/
            int cellSize = panel1.Width / theBoard.Size;

            panel1.Height = panel1.Width;

            for(int column = 0; column < theBoard.Size; column++)
            {
                for (int row = 0; row < theBoard.Size; row++)
                {
                    btnGrid[column, row] = new Button();
                    btnGrid[column, row].BackColor = Color.LightGray;
                    btnGrid[column, row].Height = cellSize;
                    btnGrid[column, row].Width = cellSize;

                    btnGrid[column, row].Click += Grid_Button_Click;
                    panel1.Controls.Add(btnGrid[column, row]);
                    btnGrid[column, row].Location = new Point(column * cellSize, row * cellSize);
                }
            }
            int startingPlace = (theBoard.Size - 1) / 2;
            populateStartingPieces(startingPlace, startingPlace);
        }

        private void populateStartingPieces(int startingRow, int startingColumn)
        {
            /*Initalizes the starting pieces*/
            for(int column = startingColumn; column <= startingColumn + 1; column++)
            {
                for(int row = startingRow; row <= startingRow + 1; row++)
                {
                    cellGrid[column, row].notOccupied = false;

                    if (row == column)
                    {
                        cellGrid[column, row].OccupiedByWhite = true;
                        btnGrid[column, row].BackColor = Color.White;
                    } else
                    {
                        theBoard.theGrid[column, row].OccupiedByWhite = false;
                        btnGrid[column, row].BackColor = Color.Black;
                    }
                }
            }
        }

        private int[] LookUp(Button clickedButton, int startingRow)
        {
            //retreive button location this allows us to access the button at a particular point in the grid.
            int[] index = new int[2];

            for (int column = 0; column < theBoard.Size; column++)
            {
                for (int row = 0; row < theBoard.Size; row++)
                {
                    if (object.ReferenceEquals(clickedButton, btnGrid[column, row]) == true)
                    {
                        index[0] = column; //y
                        index[1] = row; //x
                        return index;
                    }
                }
            }
            return index;
        }
        
        // Each time the board changes, it checks if the board is completely filled up.
        private int checkFilledTiles()
        {
            int counter = 0;
            
            // goes through all tiles and checks if they are filled in
            for (int column = 0; column < theBoard.Size; column++)
            {
                for (int row = 0; row < theBoard.Size; row++)
                {
                    if (btnGrid[column, row].BackColor == Color.White || btnGrid[column, row].BackColor == Color.Black)
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }

        // All these "isValid" functions do pretty much the same thing, they just check in their specified direction if a move can be done.
        // If any of these return "true" (returned int[0] != -10), then the move is valid.
        private int[] isValidUp(int[] index, string turn)
        {
            int column = index[0];
            int row = index[1];
            int[] badAR = new int[2];
            badAR[0] = -10;
            badAR[1] = -10;


            Cell currCell = cellGrid[index[0], index[1]];
            Cell checkCell = currCell.up;

            Button checkBtn = null;
            Button currBtn = btnGrid[currCell.ColumnNumber, currCell.RowNumber];

            if (checkCell != null)
            {
                checkBtn = btnGrid[checkCell.ColumnNumber, checkCell.RowNumber];
            }

            if(turn == "white")
            {
                if (checkCell != null && checkBtn.BackColor == Color.Black)
                {
                    while (checkCell.up != null)
                    {
                        checkCell = checkCell.up;
                        checkBtn = btnGrid[checkCell.ColumnNumber, checkCell.RowNumber];
                        if (checkBtn.BackColor == Color.White)
                        {
                            int[] ar = new int[2];
                            ar[0] = checkCell.ColumnNumber;
                            ar[1] = checkCell.RowNumber;
                            return ar;
                        }
                        else if (checkBtn.BackColor == Color.LightGray)
                        {
                            return badAR;
                        }
                    }
                }

                else
                {
                    return badAR;
                }
            }
            else
            {
                if (checkCell != null && checkBtn.BackColor == Color.White)
                {
                    while(checkCell.up != null)
                    {
                        checkCell = checkCell.up;
                        checkBtn = btnGrid[checkCell.ColumnNumber, checkCell.RowNumber];
                        if (checkBtn.BackColor == Color.Black)
                        {
                            int[] ar = new int[2];
                            ar[0] = checkCell.ColumnNumber;
                            ar[1] = checkCell.RowNumber;
                            return ar;
                        }
                        else if (checkBtn.BackColor == Color.LightGray)
                        {
                            return badAR;
                        }
                    }
                }
                else
                {
                    return badAR;
                }
            }
            return badAR;
        }

        private int[] isValidUpRight(int[] index, string turn)
        {
            int column = index[0];
            int row = index[1];
            int[] badAR = new int[2];
            badAR[0] = -10;
            badAR[1] = -10;

            Cell currCell = cellGrid[index[0], index[1]];
            Cell checkCell = currCell.UpperRightDiagonal;

            Button checkBtn = null;
            Button currBtn = btnGrid[currCell.ColumnNumber, currCell.RowNumber];

            if (checkCell != null)
            {
                checkBtn = btnGrid[checkCell.ColumnNumber, checkCell.RowNumber];
            }

            if (turn == "white")
            {
                if (checkCell != null && checkBtn.BackColor == Color.Black)
                {
                    while (checkCell.UpperRightDiagonal != null)
                    {
                        checkCell = checkCell.UpperRightDiagonal;
                        checkBtn = btnGrid[checkCell.ColumnNumber, checkCell.RowNumber];
                        if (checkBtn.BackColor == Color.White)
                        {
                            int[] ar = new int[2];
                            ar[0] = checkCell.ColumnNumber;
                            ar[1] = checkCell.RowNumber;
                            return ar;
                        }
                        else if (checkBtn.BackColor == Color.LightGray)
                        {
                            return badAR;
                        }
                    }
                }

                else
                {
                    return badAR;
                }
            }
            else
            {
                if (checkCell != null && checkBtn.BackColor == Color.White)
                {
                    while (checkCell.UpperRightDiagonal != null)
                    {
                        checkCell = checkCell.UpperRightDiagonal;
                        checkBtn = btnGrid[checkCell.ColumnNumber, checkCell.RowNumber];
                        if (checkBtn.BackColor == Color.Black)
                        {
                            int[] ar = new int[2];
                            ar[0] = checkCell.ColumnNumber;
                            ar[1] = checkCell.RowNumber;
                            return ar;
                        }
                        else if (checkBtn.BackColor == Color.LightGray)
                        {
                            return badAR;
                        }
                    }
                }
                else
                {
                    return badAR;
                }
            }
            return badAR;
        }

        private int[] isValidRight(int[] index, string turn)
        {
            int column = index[0];
            int row = index[1];
            int[] badAR = new int[2];
            badAR[0] = -10;
            badAR[1] = -10;

            Cell currCell = cellGrid[index[0], index[1]];
            Cell checkCell = currCell.right;

            Button checkBtn = null;
            Button currBtn = btnGrid[currCell.ColumnNumber, currCell.RowNumber];

            if (checkCell != null)
            {
                checkBtn = btnGrid[checkCell.ColumnNumber, checkCell.RowNumber];
            }

            if (turn == "white")
            {
                if (checkCell != null && checkBtn.BackColor == Color.Black)
                {
                    while (checkCell.right != null)
                    {
                        checkCell = checkCell.right;
                        checkBtn = btnGrid[checkCell.ColumnNumber, checkCell.RowNumber];
                        if (checkBtn.BackColor == Color.White)
                        {
                            int[] ar = new int[2];
                            ar[0] = checkCell.ColumnNumber;
                            ar[1] = checkCell.RowNumber;
                            return ar;
                        }
                        else if (checkBtn.BackColor == Color.LightGray)
                        {
                            return badAR;
                        }
                    }
                }

                else
                {
                    return badAR;
                }
            }
            else
            {
                if (checkCell != null && checkBtn.BackColor == Color.White)
                {
                    while (checkCell.right != null)
                    {
                        checkCell = checkCell.right;
                        checkBtn = btnGrid[checkCell.ColumnNumber, checkCell.RowNumber];
                        if (checkBtn.BackColor == Color.Black)
                        {
                            int[] ar = new int[2];
                            ar[0] = checkCell.ColumnNumber;
                            ar[1] = checkCell.RowNumber;
                            return ar;
                        }
                        else if (checkBtn.BackColor == Color.LightGray)
                        {
                            return badAR;
                        }
                    }
                }
                else
                {
                    return badAR;
                }
            }
            return badAR;
        }

        private int[] isValidDownRight(int[] index, string turn)
        {
            int column = index[0];
            int row = index[1];
            int[] badAR = new int[2];
            badAR[0] = -10;
            badAR[1] = -10;

            Cell currCell = cellGrid[index[0], index[1]];
            Cell checkCell = currCell.LowerRightDiagonal;

            Button checkBtn = null;
            Button currBtn = btnGrid[currCell.ColumnNumber, currCell.RowNumber];

            if (checkCell != null)
            {
                checkBtn = btnGrid[checkCell.ColumnNumber, checkCell.RowNumber];
            }

            if (turn == "white")
            {
                if (checkCell != null && checkBtn.BackColor == Color.Black)
                {
                    while (checkCell.LowerRightDiagonal != null)
                    {
                        checkCell = checkCell.LowerRightDiagonal;
                        checkBtn = btnGrid[checkCell.ColumnNumber, checkCell.RowNumber];
                        if (checkBtn.BackColor == Color.White)
                        {
                            int[] ar = new int[2];
                            ar[0] = checkCell.ColumnNumber;
                            ar[1] = checkCell.RowNumber;
                            return ar;
                        }
                        else if (checkBtn.BackColor == Color.LightGray)
                        {
                            return badAR;
                        }
                    }
                }

                else
                {
                    return badAR;
                }
            }
            else
            {
                if (checkCell != null && checkBtn.BackColor == Color.White)
                {
                    while (checkCell.LowerRightDiagonal != null)
                    {
                        checkCell = checkCell.LowerRightDiagonal;
                        checkBtn = btnGrid[checkCell.ColumnNumber, checkCell.RowNumber];
                        if (checkBtn.BackColor == Color.Black)
                        {
                            int[] ar = new int[2];
                            ar[0] = checkCell.ColumnNumber;
                            ar[1] = checkCell.RowNumber;
                            return ar;
                        }
                        else if (checkBtn.BackColor == Color.LightGray)
                        {
                            return badAR;
                        }
                    }
                }
                else
                {
                    return badAR;
                }
            }
            return badAR;
        }

        private int[] isValidDown(int[] index, string turn)
        {
            int column = index[0];
            int row = index[1];
            int[] badAR = new int[2];
            badAR[0] = -10;
            badAR[1] = -10;

            Cell currCell = cellGrid[index[0], index[1]];
            Cell checkCell = currCell.bottom;

            Button checkBtn = null;
            Button currBtn = btnGrid[currCell.ColumnNumber, currCell.RowNumber];

            if (checkCell != null)
            {
                checkBtn = btnGrid[checkCell.ColumnNumber, checkCell.RowNumber];
            }

            if (turn == "white")
            {
                if (checkCell != null && checkBtn.BackColor == Color.Black)
                {
                    while (checkCell.bottom != null)
                    {
                        checkCell = checkCell.bottom;
                        checkBtn = btnGrid[checkCell.ColumnNumber, checkCell.RowNumber];
                        if (checkBtn.BackColor == Color.White)
                        {
                            int[] ar = new int[2];
                            ar[0] = checkCell.ColumnNumber;
                            ar[1] = checkCell.RowNumber;
                            return ar;
                        }
                        else if (checkBtn.BackColor == Color.LightGray)
                        {
                            return badAR;
                        }
                    }
                }

                else
                {
                    return badAR;
                }
            }
            else
            {
                if (checkCell != null && checkBtn.BackColor == Color.White)
                {
                    while (checkCell.bottom != null)
                    {
                        checkCell = checkCell.bottom;
                        checkBtn = btnGrid[checkCell.ColumnNumber, checkCell.RowNumber];
                        if (checkBtn.BackColor == Color.Black)
                        {
                            int[] ar = new int[2];
                            ar[0] = checkCell.ColumnNumber;
                            ar[1] = checkCell.RowNumber;
                            return ar;
                        }
                        else if (checkBtn.BackColor == Color.LightGray)
                        {
                            return badAR;
                        }
                    }
                }
                else
                {
                    return badAR;
                }
            }
            return badAR;
        }

        private int[] isValidDownLeft(int[] index, string turn)
        {
            int column = index[0];
            int row = index[1];
            int[] badAR = new int[2];
            badAR[0] = -10;
            badAR[1] = -10;

            Cell currCell = cellGrid[index[0], index[1]];
            Cell checkCell = currCell.LowerLeftDiagonal;

            Button checkBtn = null;
            Button currBtn = btnGrid[currCell.ColumnNumber, currCell.RowNumber];

            if (checkCell != null)
            {
                checkBtn = btnGrid[checkCell.ColumnNumber, checkCell.RowNumber];
            }

            if (turn == "white")
            {
                if (checkCell != null && checkBtn.BackColor == Color.Black)
                {
                    while (checkCell.LowerLeftDiagonal != null)
                    {
                        checkCell = checkCell.LowerLeftDiagonal;
                        checkBtn = btnGrid[checkCell.ColumnNumber, checkCell.RowNumber];
                        if (checkBtn.BackColor == Color.White)
                        {
                            int[] ar = new int[2];
                            ar[0] = checkCell.ColumnNumber;
                            ar[1] = checkCell.RowNumber;
                            return ar;
                        }
                        else if (checkBtn.BackColor == Color.LightGray)
                        {
                            return badAR;
                        }
                    }
                }

                else
                {
                    return badAR;
                }
            }
            else
            {
                if (checkCell != null && checkBtn.BackColor == Color.White)
                {
                    while (checkCell.LowerLeftDiagonal != null)
                    {
                        checkCell = checkCell.LowerLeftDiagonal;
                        checkBtn = btnGrid[checkCell.ColumnNumber, checkCell.RowNumber];
                        if (checkBtn.BackColor == Color.Black)
                        {
                            int[] ar = new int[2];
                            ar[0] = checkCell.ColumnNumber;
                            ar[1] = checkCell.RowNumber;
                            return ar;
                        }
                        else if (checkBtn.BackColor == Color.LightGray)
                        {
                            return badAR;
                        }
                    }
                }
                else
                {
                    return badAR;
                }
            }
            return badAR;
        }

        private int[] isValidLeft(int[] index, string turn)
        {
            int column = index[0];
            int row = index[1];
            int[] badAR = new int[2];
            badAR[0] = -10;
            badAR[1] = -10;

            Cell currCell = cellGrid[index[0], index[1]];
            Cell checkCell = currCell.left;

            Button checkBtn = null;
            Button currBtn = btnGrid[currCell.ColumnNumber, currCell.RowNumber];

            if (checkCell != null)
            {
                checkBtn = btnGrid[checkCell.ColumnNumber, checkCell.RowNumber];
            }

            if (turn == "white")
            {
                if (checkCell != null && checkBtn.BackColor == Color.Black)
                {
                    while (checkCell.left != null)
                    {
                        checkCell = checkCell.left;
                        checkBtn = btnGrid[checkCell.ColumnNumber, checkCell.RowNumber];
                        if (checkBtn.BackColor == Color.White)
                        {
                            int[] ar = new int[2];
                            ar[0] = checkCell.ColumnNumber;
                            ar[1] = checkCell.RowNumber;
                            return ar;
                        }
                        else if (checkBtn.BackColor == Color.LightGray)
                        {
                            return badAR;
                        }
                    }
                }

                else
                {
                    return badAR;
                }
            }
            else
            {
                if (checkCell != null && checkBtn.BackColor == Color.White)
                {
                    while (checkCell.left != null)
                    {
                        checkCell = checkCell.left;
                        checkBtn = btnGrid[checkCell.ColumnNumber, checkCell.RowNumber];
                        if (checkBtn.BackColor == Color.Black)
                        {
                            int[] ar = new int[2];
                            ar[0] = checkCell.ColumnNumber;
                            ar[1] = checkCell.RowNumber;
                            return ar;
                        }
                        else if (checkBtn.BackColor == Color.LightGray)
                        {
                            return badAR;
                        }
                    }
                }
                else
                {
                    return badAR;
                }
            }
            return badAR;
        }

        private int[] isValidUpLeft(int[] index, string turn)
        {
            int column = index[0];
            int row = index[1];
            int[] badAR = new int[2];
            badAR[0] = -10;
            badAR[1] = -10;

            Cell currCell = cellGrid[index[0], index[1]];
            Cell checkCell = currCell.UpperLeftDiagonal;

            Button checkBtn = null;
            Button currBtn = btnGrid[currCell.ColumnNumber, currCell.RowNumber];

            if (checkCell != null)
            {
                checkBtn = btnGrid[checkCell.ColumnNumber, checkCell.RowNumber];
            }

            if (turn == "white")
            {
                if (checkCell != null && checkBtn.BackColor == Color.Black)
                {
                    while (checkCell.UpperLeftDiagonal != null)
                    {
                        checkCell = checkCell.UpperLeftDiagonal;
                        checkBtn = btnGrid[checkCell.ColumnNumber, checkCell.RowNumber];
                        if (checkBtn.BackColor == Color.White)
                        {
                            int[] ar = new int[2];
                            ar[0] = checkCell.ColumnNumber;
                            ar[1] = checkCell.RowNumber;
                            return ar;
                        }
                        else if (checkBtn.BackColor == Color.LightGray)
                        {
                            return badAR;
                        }
                    }
                }

                else
                {
                    return badAR;
                }
            }
            else
            {
                if (checkCell != null && checkBtn.BackColor == Color.White)
                {
                    while (checkCell.UpperLeftDiagonal != null)
                    {
                        checkCell = checkCell.UpperLeftDiagonal;
                        checkBtn = btnGrid[checkCell.ColumnNumber, checkCell.RowNumber];
                        if (checkBtn.BackColor == Color.Black)
                        {
                            int[] ar = new int[2];
                            ar[0] = checkCell.ColumnNumber;
                            ar[1] = checkCell.RowNumber;
                            return ar;
                        }
                        else if (checkBtn.BackColor == Color.LightGray)
                        {
                            return badAR;
                        }
                    }
                }
                else
                {
                    return badAR;
                }
            }
            return badAR;
        }

        // All these changeMultipleTiles functions do almsot identical things.
        // Based on who's turn it is, it will change all tiles between the start and end piece to the current team color.
        // This is called for a specific tile in each direction, if the move is valid in that direction.
        private void changeMultipleTilesUp(int[] startTile, int[] endTile)
        {
            Cell currCell = cellGrid[startTile[0], startTile[1]];
            Cell endCell = cellGrid[endTile[0], endTile[1]];

            if (turn == "white")
            {

                while(currCell != endCell)
                {
                    btnGrid[currCell.ColumnNumber, currCell.RowNumber].BackColor = Color.White;
                    currCell = currCell.up;
                }
            }
            else
            {
                while (currCell != endCell)
                {
                    btnGrid[currCell.ColumnNumber, currCell.RowNumber].BackColor = Color.Black;
                    currCell = currCell.up;
                }
            }
        }

        private void changeMultipleTilesUpRight(int[] startTile, int[] endTile)
        {
            Cell currCell = cellGrid[startTile[0], startTile[1]];
            Cell endCell = cellGrid[endTile[0], endTile[1]];

            if (turn == "white")
            {

                while (currCell != endCell)
                {
                    btnGrid[currCell.ColumnNumber, currCell.RowNumber].BackColor = Color.White;
                    currCell = currCell.UpperRightDiagonal;
                }
            }
            else
            {
                while (currCell != endCell)
                {
                    btnGrid[currCell.ColumnNumber, currCell.RowNumber].BackColor = Color.Black;
                    currCell = currCell.UpperRightDiagonal;
                }
            }
        }

        private void changeMultipleTilesRight(int[] startTile, int[] endTile)
        {
            Cell currCell = cellGrid[startTile[0], startTile[1]];
            Cell endCell = cellGrid[endTile[0], endTile[1]];

            if (turn == "white")
            {

                while (currCell != endCell)
                {
                    btnGrid[currCell.ColumnNumber, currCell.RowNumber].BackColor = Color.White;
                    currCell = currCell.right;
                }
            }
            else
            {
                while (currCell != endCell)
                {
                    btnGrid[currCell.ColumnNumber, currCell.RowNumber].BackColor = Color.Black;
                    currCell = currCell.right;
                }
            }
        }

        private void changeMultipleTilesDownRight(int[] startTile, int[] endTile)
        {
            Cell currCell = cellGrid[startTile[0], startTile[1]];
            Cell endCell = cellGrid[endTile[0], endTile[1]];

            if (turn == "white")
            {

                while (currCell != endCell)
                {
                    btnGrid[currCell.ColumnNumber, currCell.RowNumber].BackColor = Color.White;
                    currCell = currCell.LowerRightDiagonal;
                }
            }
            else
            {
                while (currCell != endCell)
                {
                    btnGrid[currCell.ColumnNumber, currCell.RowNumber].BackColor = Color.Black;
                    currCell = currCell.LowerRightDiagonal;
                }
            }
        }

        private void changeMultipleTilesDown(int[] startTile, int[] endTile)
        {
            Cell currCell = cellGrid[startTile[0], startTile[1]];
            Cell endCell = cellGrid[endTile[0], endTile[1]];

            if (turn == "white")
            {

                while (currCell != endCell)
                {
                    btnGrid[currCell.ColumnNumber, currCell.RowNumber].BackColor = Color.White;
                    currCell = currCell.bottom;
                }
            }
            else
            {
                while (currCell != endCell)
                {
                    btnGrid[currCell.ColumnNumber, currCell.RowNumber].BackColor = Color.Black;
                    currCell = currCell.bottom;
                }
            }
        }

        private void changeMultipleTilesDownLeft(int[] startTile, int[] endTile)
        {
            Cell currCell = cellGrid[startTile[0], startTile[1]];
            Cell endCell = cellGrid[endTile[0], endTile[1]];

            if (turn == "white")
            {

                while (currCell != endCell)
                {
                    btnGrid[currCell.ColumnNumber, currCell.RowNumber].BackColor = Color.White;
                    currCell = currCell.LowerLeftDiagonal;
                }
            }
            else
            {
                while (currCell != endCell)
                {
                    btnGrid[currCell.ColumnNumber, currCell.RowNumber].BackColor = Color.Black;
                    currCell = currCell.LowerLeftDiagonal;
                }
            }
        }

        private void changeMultipleTilesLeft(int[] startTile, int[] endTile)
        {
            Cell currCell = cellGrid[startTile[0], startTile[1]];
            Cell endCell = cellGrid[endTile[0], endTile[1]];

            if (turn == "white")
            {

                while (currCell != endCell)
                {
                    btnGrid[currCell.ColumnNumber, currCell.RowNumber].BackColor = Color.White;
                    currCell = currCell.left;
                }
            }
            else
            {
                while (currCell != endCell)
                {
                    btnGrid[currCell.ColumnNumber, currCell.RowNumber].BackColor = Color.Black;
                    currCell = currCell.left;
                }
            }
        }

        private void changeMultipleTilesUpLeft(int[] startTile, int[] endTile)
        {
            Cell currCell = cellGrid[startTile[0], startTile[1]];
            Cell endCell = cellGrid[endTile[0], endTile[1]];

            if (turn == "white")
            {

                while (currCell != endCell)
                {
                    btnGrid[currCell.ColumnNumber, currCell.RowNumber].BackColor = Color.White;
                    currCell = currCell.UpperLeftDiagonal;
                }
            }
            else
            {
                while (currCell != endCell)
                {
                    btnGrid[currCell.ColumnNumber, currCell.RowNumber].BackColor = Color.Black;
                    currCell = currCell.UpperLeftDiagonal;
                }
            }
        }

        // This function is used to check every non-taken tile on the board for a specific color.
        // The main function of it is to check if the game is over. This function is called after
        // every time the board changes to see if either color has a valid move.
        private bool checkBoard(string turn)
        {
            for (int column = 0; column < theBoard.Size; column++)
            {
                for (int row = 0; row < theBoard.Size; row++)
                {
                    int[] index = LookUp(btnGrid[column,row], theBoardSize);
                    if (btnGrid[column,row].BackColor == Color.LightGray)
                    {
                        int[] upCoords = isValidUp(index, turn);
                        int[] upRightCoords = isValidUpRight(index, turn);
                        int[] rightCoords = isValidRight(index, turn);
                        int[] downRightCoords = isValidDownRight(index, turn);
                        int[] downCoords = isValidDown(index, turn);
                        int[] downLeftCoords = isValidDownLeft(index, turn);
                        int[] leftCoords = isValidLeft(index, turn);
                        int[] upLeftCoords = isValidUpLeft(index, turn);
                        if (upCoords[0] != -10 || upRightCoords[0] != -10 || rightCoords[0] != -10 || downRightCoords[0] != -10 || downCoords[0] != -10 || downLeftCoords[0] != -10 || leftCoords[0] != -10 || upLeftCoords[0] != -10)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        // This is where all the game logic lives.
        // Othello logic only occurs when a grid button is pressed.
        private void Grid_Button_Click(object sender, EventArgs e)
        {
            if(!isOver)
            {
                /*Click event for button*/
                Button clickedButton = sender as Button;


                int[] index = LookUp(clickedButton, theBoardSize);
                bool isBoardChange = false;

                if (clickedButton.BackColor == Color.LightGray)
                {
                    int[] upCoords = isValidUp(index, turn);
                    int[] upRightCoords = isValidUpRight(index, turn);
                    int[] rightCoords = isValidRight(index, turn);
                    int[] downRightCoords = isValidDownRight(index, turn);
                    int[] downCoords = isValidDown(index, turn);
                    int[] downLeftCoords = isValidDownLeft(index, turn);
                    int[] leftCoords = isValidLeft(index, turn);
                    int[] upLeftCoords = isValidUpLeft(index, turn);

                    //performs question check
                    if (upCoords[0] != -10 || upRightCoords[0] != -10 || rightCoords[0] != -10 || downRightCoords[0] != -10 || downCoords[0] != -10 || downLeftCoords[0] != -10 || leftCoords[0] != -10 || upLeftCoords[0] != -10)
                    {
                        Random rand = new Random();
                        Variables.choice = rand.Next(64);

                        Form2 frm2 = new Form2();
                        frm2.ShowDialog();
                    }

                    if (Variables.questionCorrect == true)
                    {
                        if (upCoords[0] != -10)
                        {
                            changeMultipleTilesUp(index, upCoords);
                            isBoardChange = true;
                        }
                        if (upRightCoords[0] != -10)
                        {
                            changeMultipleTilesUpRight(index, upRightCoords);
                            isBoardChange = true;
                        }
                        if (rightCoords[0] != -10)
                        {
                            changeMultipleTilesRight(index, rightCoords);
                            isBoardChange = true;
                        }
                        if (downRightCoords[0] != -10)
                        {
                            changeMultipleTilesDownRight(index, downRightCoords);
                            isBoardChange = true;
                        }
                        if (downCoords[0] != -10)
                        {
                            changeMultipleTilesDown(index, downCoords);
                            isBoardChange = true;
                        }
                        if (downLeftCoords[0] != -10)
                        {
                            changeMultipleTilesDownLeft(index, downLeftCoords);
                            isBoardChange = true;
                        }
                        if (leftCoords[0] != -10)
                        {
                            changeMultipleTilesLeft(index, leftCoords);
                            isBoardChange = true;
                        }
                        if (upLeftCoords[0] != -10)
                        {
                            changeMultipleTilesUpLeft(index, upLeftCoords);
                            isBoardChange = true;
                        }

                        if (isBoardChange)
                        {
                            if (turn == "white")
                            {
                                turn = "black";
                            }
                            else if (turn == "black")
                            {
                                turn = "white";
                            }
                            turnLabel.Text = turn;
                        }
                        Variables.questionCorrect = false;
                    }
                    else
                    {
                        Variables.questionCorrect = false;
                    }
                }
                
                // If the game is over, this if statement will be entered.
                if(isBoardChange)
                {
                    if(!checkBoard("white") && !checkBoard("black"))
                    {
                        for (int column = 0; column < theBoard.Size; column++)
                        {
                            for (int row = 0; row < theBoard.Size; row++)
                            {
                                if (btnGrid[column, row].BackColor == Color.White)
                                {
                                    whiteCounter++;
                                }
                                else if (btnGrid[column, row].BackColor == Color.Black)
                                {
                                    blackCounter++;
                                }
                            }
                        }
                        if (whiteCounter < blackCounter)
                        {
                            turnLabel.Text = "BLACK is the winner!";
                        }
                        else if (whiteCounter > blackCounter)
                        {
                            turnLabel.Text = "WHITE is the winner!";
                        }
                        else
                        {
                            turnLabel.Text = "The game was a draw!";
                        }
                        isOver = true;
                    }
                    else if (!checkBoard("white"))
                    {
                        turn = "black";
                        turnLabel.Text = turn;
                    }
                    else if (!checkBoard("black"))
                    {
                        turn = "white";
                        turnLabel.Text = turn;
                    }
                }
            }
            if(isOver)
            {
                MessageBox.Show("The game is over!");
            }
        }

        private void reset_board()
        {
            //logic to reset board
            //reset all buttons to grey
            
            turn = "black";
            whiteCounter = 0;
            blackCounter = 0;
            turnLabel.Text = turn;
            isOver = false;
            
            for (int column = 0; column < theBoard.Size; column++)
            {
                for (int row = 0; row < theBoard.Size; row++)
                {
                    btnGrid[column, row].BackColor = Color.LightGray;
                    cellGrid[column, row].notOccupied = true;
                    cellGrid[column, row].LegalNextMove = false;
                }
            }

            //reset all starting places
            int startingPlace = (theBoard.Size - 1) / 2;
            populateStartingPieces(startingPlace, startingPlace);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //Do NOT remove this method. doing so will break this application.

            Variables.questionCorrect = false;
            //Variables.questionArr = new string[8, 8];
            Variables.question_array = new string[64];
            Variables.questionArrLength = 64;

            //load in the questions.
            try 
            {
                string path = Environment.CurrentDirectory;
                path = path + @"\questions.txt";
                //MessageBox.Show(path);

                Variables.question_array = File.ReadAllLines(path);
            } 
            catch (Exception)
            {
                //MessageBox.Show(ex.ToString());
                //MessageBox.Show("please select the 'load questions' button to initialize the questions.");
                generateDefaultQuestions();
            }

            /*
            //int counter = 0;
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    int theY = y + 1;
                    int theX = x + 1;

                    Variables.questionArr[y, x] = "Question " + "X: " + theY + " " + "Y: " + theX;
                    //counter++;
                }
            }
            */

            //MessageBox.Show(Variables.questionArr[5, 3]););
        }

        //reset board
        private void reset_button_Click(object sender, EventArgs e)
        {
            reset_board();
        }

        private void button_load_Click(object sender, EventArgs e)
        {
            generateDefaultQuestions();
        }

        private void generateDefaultQuestions()
        {
            int theCount = 1;
            for (int i = 0; i < 64; i++)
            {
                Variables.question_array[i] = "default question " + theCount;
                theCount++;
            }

            string path = Environment.CurrentDirectory;
            path = path + @"\questions.txt";

            MessageBox.Show("default questions generated");

            File.WriteAllLines(path, Variables.question_array);
        }
        
        // button1 is the button that loads custom questions.
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please select a text file with 64 questions.\nOne question per line.", "Message");
            string path = Environment.CurrentDirectory;
            path = path + @"\questions.txt";

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var fileStream = openFileDialog.OpenFile();
                //var fileContent = "";
                string line;
                int i = 0;

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    //fileContent = reader.ReadToEnd();
                    //Variables.question_array = reader.ReadLine();
                    while ((line = reader.ReadLine()) != null)
                    //for (int x = 0; x < 64; x++)
                    {
                        //Console.WriteLine(line);
                        //line = reader.ReadLine();
                        if(line != "")
                        {
                            Variables.question_array[i] = line;
                            i++;
                        }
                    }
                    if(i != 64)
                    {
                        MessageBox.Show("Please ensure the file contains 64 questions.");
                        generateDefaultQuestions();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Custom questions generated!");
                    }
                }
                //file_rich_textbox.Text = fileContent;
                openFileDialog.FileName = "";
            } 
        }

        private void menu_Button_Click(object sender, EventArgs e)
        {
            Form3 myForm = new Form3();
            this.Hide();
            myForm.ShowDialog();
            this.Close();
        }
    }
}