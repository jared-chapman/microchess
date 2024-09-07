using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareData
{
  public bool isWhite;
  public string squareName;
  public int[] coordinates;
  public float[] position;
  public float scale; 

  public bool isOccupied = false;
  public PieceData pieceData = null;
  public Sprite lightSquareSprite;
  public Sprite darkSquareSprite;
 
  public SquareData(bool isWhite, string squareName, int r, int c, float x, float y, float scale, GameObject squarePrefab)
  {
    this.isWhite = isWhite;
    this.squareName = squareName;
    this.coordinates = new int[] { r, c };
    this.position = new float[] { x, y };
    this.scale = scale;
    this.lightSquareSprite = squarePrefab.GetComponent<scr_square_prefab>().lightSquareSprite;
    this.darkSquareSprite = squarePrefab.GetComponent<scr_square_prefab>().darkSquareSprite;
  }
 
  

  public void printSquareData()
  {
    string pieceDataString = "";
    if (pieceData != null)
    {
      pieceDataString = pieceData.pieceName;
    }
    Debug.Log("Square: " + squareName + "\n isWhite: " + isWhite + "\n isOccupied: " + isOccupied + "\n pieceData: " + pieceDataString);
  }

}