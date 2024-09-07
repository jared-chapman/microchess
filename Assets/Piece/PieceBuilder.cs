using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PieceBuilder
{

    /// <summary>
    /// creates a string based on the character passed in
    /// </summary>
    /// <param name="piece"></param>
    /// <returns></returns>
    public static string getNameFromChar(char piece)
  
      {
          char lowerPiece = char.ToLower(piece);
          switch (lowerPiece)
          {
              case 'p':
                  return "pawn";
              case 'r':
                  return "rook";
              case 'n':
                  return "knight";
              case 'b':
                  return "bishop";
              case 'q':
                  return "queen";
              case 'k':
                  return "king";
              case 'x':
                  return "laser";
              default:
                  return "empty";
          }
      }

    /// <summary>
    /// returns a string representing the color of the piece based on the character passed in
    /// </summary>
    /// <param name="piece"></param>
    /// <returns>string</returns>
    public static string getColorFromChar(char piece)
      {
          if (char.IsUpper(piece))
          {
              return "white";
          }
          if (char.IsLower(piece))
          {
              return "black";
          }
          return "empty";
      }

    /// <summary>
    /// returns a list of arrays of integers representing the moves a piece can make based on the character piece passed in
    /// note: this includes all moves possible at start. Moves like a pawn's double move will be removed later
    /// </summary>
    /// <param name="piece"></param>
    public static List<List<int[]>> getMovesetFromName(string piece, string color)
    {
      int isWhite = color == "white" ? 1 : -1;
      int f = 1 * isWhite;  // forward
      int b = -1 * isWhite; // backward
      int l = -1 * isWhite; // left
      int r = 1 * isWhite;  // right

    //   List<int[]> moveSet = new List<int[]>();
        List<List<int[]>> moveSet = new List<List<int[]>>();
        switch (piece)
        {
            case "laser":
                moveSet.Add(buildRay(0, f));
                break;
            case "pawn":
                moveSet.Add(buildRay(0, f, 1, moveOnly: true));
                moveSet.Add(buildRay(0, f, 2, moveOnly: true));
                break;
            case "bishop":
                moveSet.Add(buildRay(1, 1));
                moveSet.Add(buildRay(-1, 1));
                moveSet.Add(buildRay(1, -1));
                moveSet.Add(buildRay(-1, -1));
                break;
            case "knight":
                moveSet.Add(buildJump(2, 1));
                moveSet.Add(buildJump(2, -1));
                moveSet.Add(buildJump(-2, 1));
                moveSet.Add(buildJump(-2, -1));
                moveSet.Add(buildJump(1, 2));
                moveSet.Add(buildJump(1, -2));
                moveSet.Add(buildJump(-1, 2));
                moveSet.Add(buildJump(-1, -2));
                break;
            case "rook":
                moveSet.Add(buildRay(0, 1));
                moveSet.Add(buildRay(0, -1));
                moveSet.Add(buildRay(1, 0));
                moveSet.Add(buildRay(-1, 0));
                break;
            case "queen":
                moveSet.Add(buildRay(0, 1));
                moveSet.Add(buildRay(0, -1));
                moveSet.Add(buildRay(1, 0));
                moveSet.Add(buildRay(-1, 0));
                moveSet.Add(buildRay(1, 1));
                moveSet.Add(buildRay(-1, 1));
                moveSet.Add(buildRay(1, -1));
                moveSet.Add(buildRay(-1, -1));
                break;
            case "king":
                moveSet.Add(buildRay(0, 1, 1));
                moveSet.Add(buildRay(0, -1, 1));
                moveSet.Add(buildRay(1, 0, 1));
                moveSet.Add(buildRay(-1, 0, 1));
                moveSet.Add(buildRay(1, 1, 1));
                moveSet.Add(buildRay(-1, 1, 1));
                moveSet.Add(buildRay(1, -1, 1));
                moveSet.Add(buildRay(-1, -1, 1));
                break;
            default:
                // return new List<List<int[]>>();
                moveSet.Add(buildRay(0, f));
                break;
        }
        return moveSet;
    }

    /// <summary>
    /// builds a 2D array of integers in a given direction. encodes special types like moveOnly and captureOnly into third parameter
    /// </summary>
    /// <param name="xDir"></param>
    /// <param name="yDir"></param>
    /// <param name="maxLen"></param>
    /// <param name="minLen"></param>
    /// <returns></returns>
    public static List<int[]> buildRay(int xDir, int yDir, int maxLen =  7, int minLen = 1, bool moveOnly = false, bool captureOnly = false)
    {
        List<int[]> ray = new List<int[]>();
        int special = 0;
        if (moveOnly) special = 1;
        if (captureOnly) special = 2;
        for (int i = minLen-1; i < maxLen; i++)
        {
            ray.Add(new int[] {(i * xDir) + (1 * xDir) , (i * yDir) + (1 * yDir), special});
        }
        return ray;
    }

    public static List<int[]> buildJump(int xDir, int yDir, bool moveOnly = false, bool captureOnly = false)
    {
        int special = 0;
        if (moveOnly) special = 1;
        if (captureOnly) special = 2;
        return new List<int[]> {new int[] {xDir, yDir, special}};
    }


    /// <summary>
    /// creates an array of dictionaries representing the game pieces
    /// </summary>
    /// <param name="boardArray"></param>
    /// <returns></returns>
    public static PieceData[] createPiecesData(char[,] boardArray)
    {
        
        int boardWidth = boardArray.GetLength(0);
        int boardHeight = boardArray.GetLength(1);
        PieceData[] board = new PieceData[boardWidth * boardHeight];
        for (int x = 0; x < boardWidth; x++)
        {
            for (int y = 0; y < boardHeight; y++)
            {
                PieceData piece = PieceBuilder.createPieceData(x, y, boardArray[x, y]);
                board[x * boardWidth + y] = piece;
            }
        }

        return board;
    }

    /// <summary>
    /// creates an array of dictionaries representing the game board
    /// </summary>
    /// <param name="boardArray"></param>
    /// <returns>Dictionary<string, string>[]</returns>
    public static PieceData createPieceData(int x, int y, char pieceChar)
    {
        string pieceName = getNameFromChar(pieceChar);
        string pieceColor = getColorFromChar(pieceChar);
        List<List<int[]>> moveset = getMovesetFromName(pieceName, pieceColor);
        int[] coordinates = {x, y};

        return new PieceData(pieceName, pieceColor, moveset, coordinates, false, false);
    }


}