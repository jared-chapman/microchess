using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SquareBuilder
{

  public static SquareData createSquareData(
    int r,
    int c,
    bool isWhite,
    float scale,
    float[] a1Position,
    GameObject squarePrefab
  )  
  {
    float x = a1Position[0] + r * scale;
    float y = a1Position[1] + c * scale;
    string squareName = getSquareName(r, c);
    return new SquareData(isWhite, squareName, r, c, x, y, scale, squarePrefab);
  }

  /// <summary>
  /// hacky way to get the name of the square
  /// </summary>
  /// <param name="r">coordinates</param>
  /// <param name="c">coordinates</param>
  /// <returns></returns>
  public static string getSquareName(int r, int c)
  {
    return $"{(char)(r + 97)}{(c + 1)}";
  }


}