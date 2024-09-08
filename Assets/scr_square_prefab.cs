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
