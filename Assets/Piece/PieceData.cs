using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PieceData
    {
        public string pieceName;
        public string pieceColor;
        public List<List<int[]>> moveset;
        public bool hasMoved;
        public bool inCheck;
        public string squareName;
        public int[] coordinates;
        public List<List<int[]>> currentMoveset;

        public PieceData(string pieceName, string pieceColor, List<List<int[]>> moveset, int[] coordinates, bool hasMoved, bool inCheck)
        {
            this.pieceName = pieceName;
            this.pieceColor = pieceColor;
            this.moveset = moveset;
            this.hasMoved = hasMoved;
            this.inCheck = inCheck;
            this.coordinates = new int[] {coordinates[0], coordinates[1]};
            this.squareName = SquareBuilder.getSquareName(coordinates[0], coordinates[1]);
            this.currentMoveset = getAdjustedMoveset();
        }

        public void printPieceData()
        {
            string movesetString = "";
            foreach (List<int[]> ray in moveset)
            {
                string rayString = "ray: ";
                foreach (int[] move in ray)
                {
                    string specialString = "";
                    if (move[2] == 1) specialString = "moveOnly";
                    if (move[2] == 2) specialString = "captureOnly";
                    rayString += $"({move[0]}, {move[1]}) {specialString}";

                }
                movesetString += rayString + "\n";
            }

            string currentMovesetString = "";
            foreach (List<int[]> ray in currentMoveset)
            {
                string rayString = "ray: ";
                foreach (int[] move in ray)
                {
                    string specialString = "";
                    if (move[2] == 1) specialString = "moveOnly";
                    if (move[2] == 2) specialString = "captureOnly";
                    rayString += $"({move[0]}, {move[1]}) {specialString}";

                }
                currentMovesetString += rayString + "\n";
            }


            Debug.Log("Piece: " + pieceName + "\n Color: " + pieceColor + "\n moveset: \n" + movesetString + "\n currentMoveset: \n" + currentMovesetString + "\n hasMoved: " + hasMoved + "\n inCheck: " + inCheck);
        }

/// <summary>
/// Adjusts the moveset to the current position of the piece
/// </summary>
/// <returns></returns>
        public List<List<int[]>> getAdjustedMoveset()
        {
            List<List<int[]>> adjustedMoveset = new List<List<int[]>>();
            foreach (List<int[]> ray in moveset)
            {
                List<int[]> adjustedRay = new List<int[]>();
                foreach (int[] move in ray)
                {
                    int[] adjustedMove = new int[] {move[0] + coordinates[0] + 1, move[1] + coordinates[1] + 1, move[2]};
                    adjustedRay.Add(adjustedMove);
                }
                adjustedMoveset.Add(adjustedRay);
            }
            return adjustedMoveset;
        }

    }