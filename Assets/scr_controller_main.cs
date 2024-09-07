using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_controller_main : MonoBehaviour
{

    public int w = 8;
    public int h = 8;
    public float[] a1Position = new float[] { 0, 0 };
    public float scale = 1;
    private SquareData[,] board;
    private PieceData[] piecesData;
    public GameObject squarePrefab;
    public GameObject piecePrefab;


    // Start is called before the first frame update
    void Start()
    {
        board = buildGameBoard(w, h);
        piecesData = buildGamePieces("clockwise");
        showBoard(board);
        showPieces(piecesData);
        
    }

    // Update is called once per frame
    void Update()
    {
        handleInput();
    }

/// <summary>
/// handles all input from the player
/// </summary>
    void handleInput()
    {
        // if space is pressed, rebuild the board
        if (Input.GetKeyDown("space"))
        {
            // destroy all squares and pieces
            GameObject[] squares = GameObject.FindGameObjectsWithTag("square");
            foreach (GameObject square in squares)
            {
                Destroy(square);
            }
            GameObject[] pieces = GameObject.FindGameObjectsWithTag("piece");
            foreach (GameObject piece in pieces)
            {
                Destroy(piece);
            }
            board = buildGameBoard(w, h);
            piecesData = buildGamePieces("clockwise");
            showBoard(board);
            showPieces(piecesData);
        }

        // if there is no active piece
        //   if a piece is clicked and the piece belongs to the active player
        //     make the piece the active piece
        

    }

    void validateMovement()
    {
        // accepts all piece positions and current board state
        // removes all illegal moves

    }

    void movePiece()
    {
        // accepts a piece and a position
        // moves the piece to the position
        // handles removing any pieces that are taken
        // handles any triggers that are activated (pawn promotion, etc.)
        // updates the board state
    }

    /// <summary>
    /// builds a 2D array of squares based on the width and height passed in
    /// </summary>
    /// <param name="length"></param>
    /// <param name="width"></param>
    /// <returns></returns>
    private SquareData[,] buildGameBoard(int width, int height)
    {
        SquareData[,] board = new SquareData[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                bool isWhite = (x + y) % 2 == 0;
                float[] coordinates = { y, x };
                board[x, y] = SquareBuilder.createSquareData(
                    x,
                    y,
                    isWhite,
                    scale,
                    a1Position,
                    squarePrefab

                );
                board[x, y].printSquareData();
            }
        }
        return board;
    }
    


    /// <summary>
    /// builds the game pieces based on the board type passed in
    /// </summary>
    /// <param name="boardType"></param>
    /// <returns></returns>
    private PieceData[] buildGamePieces(string boardType)
    {
        char[,] boardArray;
        switch (boardType)
        {
            case "standard":
                boardArray = DefaultBoards.standard;
                break;
            case "clockwise":
                boardArray = DefaultBoards.clockwise;
                break;
            default:
                boardArray = DefaultBoards.standard;
                break;
        }
        PieceData[] piecesData = PieceBuilder.createPiecesData(boardArray);
        foreach (PieceData piece in piecesData)
        {
            piece.printPieceData();
        }
        return piecesData;

    }

    /// <summary>
    /// uses the squareObject prefab's sprite renderer to show the squares of the board
    /// </summary>
    /// <param name="board"></param>
    private void showBoard(SquareData[,] b)
    {
        for (int x = 0; x < b.GetLength(0); x++)
        {
            for (int y = 0; y < b.GetLength(1); y++)
            {
                SquareData s = b[x, y];
                GameObject squareObject = Instantiate(squarePrefab, new Vector3(s.position[0], s.position[1], 0), Quaternion.identity);
                squareObject.transform.localScale = new Vector3(s.scale, s.scale, 1);
                SpriteRenderer sr = squareObject.GetComponent<SpriteRenderer>();
                sr.sprite = s.isWhite ? s.lightSquareSprite : s.darkSquareSprite;
            }
        }
    }

    /// <summary>
    /// uses the pieceObject prefab's sprite renderer to show the pieces
    /// </summary>
    /// <param name="piecesData"></param>
    /// <returns></returns>
    private void showPieces(PieceData[] piecesData)
    {
        foreach (PieceData piece in piecesData)
        {
            Debug.Log(piece.coordinates[0] + " " + piece.coordinates[1]);
            if (piece.pieceName == "empty" || piece == null) continue;
            
            GameObject pieceObject = Instantiate(piecePrefab, new Vector3(piece.coordinates[0], piece.coordinates[1], 0), Quaternion.identity);
            scr_piece_prefab pieceScript = pieceObject.GetComponent<scr_piece_prefab>();
            pieceScript.setSelf(piece.pieceName, piece.pieceColor);
            // SpriteRenderer sr = pieceObject.GetComponent<SpriteRenderer>();
            // sr.sprite = pieceObject.pieceSprite;
        }
    }

    private SquareData getSquareByNotation(string squareNotation)
    {
        // accepts a string in the format of "a1" and returns the square object
        foreach (SquareData square in board)
        {
            if (square.squareName == squareNotation)
            {
                return square;
            }
        }
        return null;
    }
}
