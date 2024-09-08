using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MoveRules
{
/// <summary>
/// Applies the rules to the moveset and returns the new moveset
/// </summary>
/// <param name="moveset"></param>
/// <param name="rules"></param>
/// <returns></returns>
  public static  List<List<int[]>> applyRules(PieceData piece, string[] rules, Dictionary<string, PieceData> pieceDictionary)
  {
    List<List<int[]>> newMoveset = piece.currentMoveset;
    if (Array.Exists(rules, element => element == "cannotMoveOffBoard"))
    {
      newMoveset = cannotMoveOffBoard(newMoveset, new int[] { 0, 0 });
    }
    if (Array.Exists(rules, element => element == "cannotMoveThroughFriends"))
    {
      piece.moveset = cannotMoveThroughFriends(newMoveset, piece, pieceDictionary);
    }
    return piece.moveset;
  }

  public static List<List<int[]>> cannotMoveOffBoard(List<List<int[]>> moveset, int[] coordinates, int l = 8, int w = 8)
  {
    List<List<int[]>> newMoveset = new List<List<int[]>>();
    foreach (List<int[]> ray in moveset)
    {
      List<int[]> newRay = new List<int[]>();
      foreach (int[] move in ray)
      {
        int[] newMove = new int[] { move[0], move[1], move[2] };
        if (newMove[0] >= 1 && newMove[0] <= l && newMove[1] >= 1 && newMove[1] <= w)
        {
          newRay.Add(newMove);
        }
      }
      newMoveset.Add(newRay);
    }
    logChanges(moveset, newMoveset);
    return newMoveset;
  }

  public static List<List<int[]>> cannotMoveThroughFriends(List<List<int[]>> moveset, PieceData piece, Dictionary<string, PieceData> pieceDictionary)
  {
    List<List<int[]>> originalMoveset = moveset;
    string color = piece.pieceColor;
    List<List<int[]>> newMoveset = new List<List<int[]>>();

    foreach (List<int[]> ray in originalMoveset)
    {
      List<int[]> newRay = new List<int[]>();
      foreach (int[] move in ray)
      {
        string squareName = SquareBuilder.getSquareName(move[0]-1, move[1]-1);
        Debug.Log("checking square: " + squareName);
        PieceData pieceOnSquare;
        if (pieceDictionary.TryGetValue(squareName, out pieceOnSquare))
        {
          Debug.Log("piece found. pieceColor: " + pieceOnSquare.pieceColor + ". my color: " + color);
          // if there is a piece on the square and it is a friend, do not add the move to the new moveset, and break the loop
          if (pieceOnSquare.pieceColor == color)
          {
            break;
          }

          // if there is no piece on the square, add the move to the new moveset
          if (pieceOnSquare.pieceColor != color)
          {
            newRay.Add(move);
          }
        }
      }
      newMoveset.Add(newRay);
    }
    logChanges(originalMoveset, newMoveset);
    return newMoveset;
  }


  // it may be better to nest rules like this so we don't have nested loops
  // but to simplify logic we'll keep them separate for now
  // public static List<List<int[]>> applyRules(List<List<int[]>> moveset, string[] rules)
  // {
  //   bool cannotMoveOffBoard = Array.Exists(rules, element => element == "cannotMoveOffBoard");
  //   bool cannotMoveThroughFriends = Array.Exists(rules, element => element == "cannotMoveThroughFriends");
  //   List<List<int[]>> newMoveset = new List<List<int[]>>();
  //   foreach (List<int[]> ray in moveset)
  //   {
  //     List<int[]> newRay = new List<int[]>();
  //     foreach (int[] move in ray)
  //     {
  //       int[] newMove = new int[] { move[0], move[1], move[2] };

  //       bool moveIsInBoard = (newMove[0] >= 1 && newMove[0] <= 8 && newMove[1] >= 1 && newMove[1] <= 8);
  //       bool doesNotMoveThroughFriends = 

  //       bool valid = true;
  //       if (cannotMoveOffBoard && !moveIsInBoard)
  //       {
  //         valid = false;
  //       }

  //       if (valid)
  //       {
  //         newRay.Add(newMove);
  //       }
  //     }
  //     newMoveset.Add(newRay);
  //   }
  //   logChanges(moveset, newMoveset);
  //   return newMoveset;
  // }

  private static void logChanges(List<List<int[]>> moveset, List<List<int[]>> newMoveset)
  {
    string originalMoveset = "";
    string newMovesetString = "";
    foreach (List<int[]> ray in moveset)
    {
      string rayString = "ray: ";
      foreach (int[] move in ray)
      {
        rayString += $"({move[0]}, {move[1]})";
      }
      originalMoveset += rayString;
    }
    foreach (List<int[]> ray in newMoveset)
    {
      string rayString = "ray: ";
      foreach (int[] move in ray)
      {
        rayString += $"({move[0]}, {move[1]})";
      }
      newMovesetString += rayString;
    }
    Debug.Log("original moveset: " + originalMoveset);
    Debug.Log("new moveset: " + newMovesetString);
  }

}