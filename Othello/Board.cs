using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello
{
    class Board
    {
        public int Size { get; set; } //init size int variable
        public Cell[,] theGrid { get; } //init board 2d array of cells
        public Board(int s)
        {
            Size = s; // set size of 2d array
            theGrid = new Cell[Size, Size];

            //fill 2d array
            for (int column = 0; column < Size; column++)
            {
                for (int row = 0; row < Size; row++)
                {
                    var cell = new Cell(column, row);
                    theGrid[column, row] = cell;
                }
            }

            //fill 2d array
            for (int column = 0; column < Size; column++)
            {
                for (int row = 0; row < Size; row++)
                {
                    var cell = theGrid[column, row];

                    //Looks at the top row
                    if (row == 0)
                    {
                        //Top left row corner
                        if (column == 0)
                        {
                            
                            cell.LowerRightDiagonal =  theGrid[column + 1, row + 1];
                            cell.right = theGrid[column + 1, row];
                            cell.bottom = theGrid[column, row + 1];
                        }
                        //Top right row corner
                        else if (column == s - 1)
                        {
                            cell.LowerLeftDiagonal = theGrid[column - 1, row + 1];
                            cell.left = theGrid[column - 1, row];
                            cell.bottom = theGrid[column, row + 1];
                        }
                        //Remaining cells in the top
                        else
                        {
                            cell.LowerLeftDiagonal = theGrid[column - 1, row + 1];
                            cell.LowerRightDiagonal = theGrid[column + 1, row + 1];
                            cell.left = theGrid[column - 1, row];
                            cell.right = theGrid[column + 1, row];
                            cell.bottom = theGrid[column, row + 1];
                        }
                    }
                    //Looks at the bottom row
                    else if (row == s - 1)
                    {
                        //Bottom left row corner
                        if (column == 0)
                        {
                            cell.UpperRightDiagonal = theGrid[column + 1, row - 1];
                            cell.up = theGrid[column, row - 1];
                            cell.right = theGrid[column + 1, row];
                        }
                        //Bottom right row corner
                        else if (column == s - 1)
                        {
                            cell.UpperLeftDiagonal = theGrid[column - 1, row - 1];
                            cell.up = theGrid[column, row - 1];
                            cell.left = theGrid[column - 1, row];

                        }
                        //Remaining cells in the bottom
                        else
                        {
                            cell.left = theGrid[column - 1, row];
                            cell.right = theGrid[column + 1, row];
                            cell.up = theGrid[column, row - 1];
                            cell.UpperRightDiagonal = theGrid[column + 1, row - 1];
                            cell.UpperLeftDiagonal = theGrid[column - 1, row - 1];
                        }
                    }
                    //Cells in the first column on the edge
                    else if (column == 0)
                    {
                        cell.up = theGrid[column, row - 1];
                        cell.right = theGrid[column + 1, row];
                        cell.bottom = theGrid[column, row + 1];
                        cell.LowerRightDiagonal = theGrid[column + 1, row + 1];
                        cell.UpperRightDiagonal = theGrid[column + 1, row - 1];

                    }
                    //Cells in the last column on the edge
                    else if (column == s - 1)
                    {
                        cell.up = theGrid[column, row - 1];
                        cell.left = theGrid[column - 1, row];
                        cell.bottom = theGrid[column, row + 1];
                        cell.UpperLeftDiagonal = theGrid[column - 1, row - 1];
                        cell.LowerLeftDiagonal = theGrid[column - 1, row + 1];
                    }
                    //Cells in the middle of the board
                    else
                    {
                        cell.up = theGrid[column, row - 1];
                        cell.bottom = theGrid[column, row + 1];
                        cell.left = theGrid[column - 1, row];
                        cell.right = theGrid[column + 1, row];
                        cell.LowerLeftDiagonal = theGrid[column - 1, row + 1];
                        cell.LowerRightDiagonal = theGrid[column + 1, row + 1];
                        cell.UpperLeftDiagonal = theGrid[column - 1, row - 1];
                        cell.UpperRightDiagonal = theGrid[column + 1, row - 1];
                    }

                }
            }
        }
    }
}