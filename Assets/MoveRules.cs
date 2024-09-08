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
  public static  List<List<int[]>> applyRules(List<List<int[]>> moveset, string[] rules)
  {
    if (Array.Exists(rules, element => element == "cannotMoveOffBoard"))
    {
      moveset = cannotMoveOffBoard(moveset, new int[] { 0, 0 });
    }
    return moveset;
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

  private static void logChanges(List<List<int[]>> moveset, List<List<int[]>> newMoveset)
  {
    foreach (List<int[]> ray in moveset)
    {
      string rayString = "ray: ";
      foreach (int[] move in ray)
      {
        rayString += $"({move[0]}, {move[1]})";
      }
      Debug.Log("original moveset: " + rayString);
    }
    foreach (List<int[]> ray in newMoveset)
    {
      string rayString = "ray: ";
      foreach (int[] move in ray)
      {
        rayString += $"({move[0]}, {move[1]})";
      }
      Debug.Log("new moveset: " + rayString);
    }
  }

}