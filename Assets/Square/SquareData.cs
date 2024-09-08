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
  public bool isAvailable = false;
  public Sprite lightSquareSprite;
  public Sprite darkSquareSprite;
  public Sprite circleSprite;
 
  public SquareData(bool isWhite, string squareName, int r, int c, float x, float y, float scale, PieceData pieceData, GameObject squarePrefab)
  {
    this.isWhite = isWhite;
    this.squareName = squareName;
    this.coordinates = new int[] { r, c };
    this.position = new float[] { x, y };
    this.scale = scale;
    this.pieceData = pieceData;
    this.lightSquareSprite = squarePrefab.GetComponent<scr_square_prefab>().lightSquareSprite;
    this.darkSquareSprite = squarePrefab.GetComponent<scr_square_prefab>().darkSquareSprite;
    this.circleSprite = squarePrefab.GetComponent<scr_square_prefab>().circleSprite;
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

  public void setAvailable(bool isAvailable)
  {
    this.isAvailable = isAvailable;
    if (isAvailable)
    {
      Debug.Log("setting " + squareName + " available");
      GameObject circleObject = new GameObject("AvailableCircle");
      circleObject.tag = "circle";
      circleObject.transform.position = new Vector3(position[0], position[1], 1);
      circleObject.transform.localScale = new Vector3(0.5f, 0.5f, 1);

      // add circle renderer
      SpriteRenderer circleRenderer = circleObject.AddComponent<SpriteRenderer>();
      circleRenderer.sprite = circleSprite;
      circleRenderer.sortingOrder = 1;
    }
  }

}