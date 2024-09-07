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
        public float[] coordinates;

        public PieceData(string pieceName, string pieceColor, List<List<int[]>> moveset, int[] coordinates, bool hasMoved, bool inCheck)
        {
            this.pieceName = pieceName;
            this.pieceColor = pieceColor;
            this.moveset = moveset;
            this.hasMoved = hasMoved;
            this.inCheck = inCheck;
            this.coordinates = new float[] {coordinates[0], coordinates[1]};
            this.squareName = SquareBuilder.getSquareName(coordinates[0], coordinates[1]);
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


            Debug.Log("Piece: " + pieceName + "\n Color: " + pieceColor + "\n moveset: \n" + movesetString + "\n hasMoved: " + hasMoved + "\n inCheck: " + inCheck);
        }

    }