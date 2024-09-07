using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_piece_prefab : MonoBehaviour
{
    public Sprite whitePawnSprite;
    public Sprite blackPawnSprite;
    public Sprite whiteKnightSprite;
    public Sprite blackKnightSprite;
    public Sprite whiteBishopSprite;
    public Sprite blackBishopSprite;
    public Sprite whiteRookSprite;
    public Sprite blackRookSprite;
    public Sprite whiteQueenSprite;
    public Sprite blackQueenSprite;
    public Sprite whiteKingSprite;
    public Sprite blackKingSprite;
    private string pieceName;
    private string pieceColor;
    private Sprite thisSprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setSelf(string name, string color)
    {
        this.pieceName = name;
        this.pieceColor = color;
        switch (name)
        {
            case "pawn":
                if (color == "white") thisSprite = whitePawnSprite;
                if (color == "black") thisSprite = blackPawnSprite;
                break;
            case "knight":
                if (color == "white") thisSprite = whiteKnightSprite;
                if (color == "black") thisSprite = blackKnightSprite;
                break;
            case "bishop":
                if (color == "white") thisSprite = whiteBishopSprite;
                if (color == "black") thisSprite = blackBishopSprite;
                break;
            case "rook":
                if (color == "white") thisSprite = whiteRookSprite;
                if (color == "black") thisSprite = blackRookSprite;
                break;
            case "queen":
                if (color == "white") thisSprite = whiteQueenSprite;
                if (color == "black") thisSprite = blackQueenSprite;
                break;
            case "king":
                if (color == "white") thisSprite = whiteKingSprite;
                if (color == "black") thisSprite = blackKingSprite;
                break;
            default:
                Debug.Log("Error: piece name not recognized");
                break;
        }
        this.GetComponent<SpriteRenderer>().sprite = thisSprite;

        

    }
}
