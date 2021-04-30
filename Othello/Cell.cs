using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello
{
    //The cell class will represent the 64 playable spaces on our Othello board, by using a class instead of 64 individual buttons, we reduce the complexity of our project
    class Cell
    {
        public int RowNumber { get; private set; } //Row number & column number are used to determine the coordinates of the cell
        public int ColumnNumber { get; set; } //This information is needed in order to access that cell's assigned question, color, and legality for being a next move
        public bool OccupiedByWhite { get; set; } //We need this function in order to determine if the color of the tile is white. If it is false, it is either black or empty
        public bool LegalNextMove { get; set; } //We need this function to determine if a piece can be played down on this cell or not by looking at the properties of the surrounding tiles
        public bool notOccupied { get; set; } //We need this function in order to determine if the color is empty. If it is false, we can use the OccupidByWhite() method to determine if it is black or white
        public Cell up { get; set; } //Read only list with column and row of upper cell
        public Cell bottom { get; set; } //Read only list with column and row of bottom cell
        public Cell left { get; set; } //Read only list with column and row of left cell
        public Cell right { get; set; } //Read only list with column and row of right cell
        public Cell LowerLeftDiagonal { get; set; } //Read only list with column and row of lower left diagonal cell
        public Cell LowerRightDiagonal { get; set; } //Read only list with column and row of lower right diagonal cell
        public Cell UpperLeftDiagonal { get; set; } //Read only list with column and row of upper left diagonal cell
        public Cell UpperRightDiagonal { get; set; } //Read only list with column and row of upper right diagonal cell

        public Cell(int column, int row) //A cell object takes in two parameters, an x and a y integer coordinate to determine its position on our Board class
        {
            RowNumber = row;
            ColumnNumber = column;
            OccupiedByWhite = false;
            LegalNextMove = false;
            notOccupied = true;
        }
    }
}
