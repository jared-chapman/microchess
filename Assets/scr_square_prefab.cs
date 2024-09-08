using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_square_prefab : MonoBehaviour



{
    public Sprite lightSquareSprite;
    public Sprite darkSquareSprite;
    public SquareData squareData;
    public TextController textController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // on mouse click on this object
        if (Input.GetMouseButtonDown(0)) // Left mouse button click
        {
            // Convert mouse position to world position in 2D
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Cast a ray at the mouse position
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            // Debug.Log("here");

            // Check if the ray hit any object
            if (hit.collider != null)
            {

                // Check if the object hit is the one this script is attached to
                if (hit.transform == transform)
                {
                    Debug.Log("Clicked on " + squareData.squareName + "With piece: " + squareData.pieceData.pieceName);
                    // Run your custom logic here
                    string debugString = squareData.squareName;
                    if (squareData.pieceData.pieceName != null)
                    {
                        debugString += "\n" + squareData.pieceData.pieceName;
                    }
                    textController.UpdateText(debugString);
                }
            }
        }
        
    }

    public void setSquareData(SquareData s)
    {
        squareData = s;
        // Debug.Log("SquareData set for " + squareData.squareName);
    }

    public void updatePieceData(PieceData p = null)
    {
        if (p != null)
        {
            squareData.isOccupied = true;
            squareData.pieceData = p;
        }
        else
        {
            squareData.isOccupied = false;
            squareData.pieceData = null;
        }
    }

}
