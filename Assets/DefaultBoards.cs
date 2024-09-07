// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

public static class DefaultBoards
{

    // default board positions
    public static readonly char[,] standard = new char[8, 8]
    {
        {'p', 'n', 'b', 'q', 'k', 'b', 'n', 'r'},
        {'p', 'p', 'p', 'p', 'p', 'p', 'p', 'p'},
        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
        {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
        {'P', 'P', 'P', 'P', 'P', 'P', 'P', 'P'},
        {'R', 'N', 'B', 'Q', 'K', 'B', 'N', 'R'}
    };

    public static readonly char[,] clockwise = new char[8, 8]
    {
        {'R', 'P', ' ', ' ', ' ', ' ', 'p', 'r'},
        {'N', 'P', ' ', ' ', ' ', ' ', 'p', 'n'},
        {'B', 'P', ' ', ' ', ' ', ' ', 'p', 'b'},
        {'K', 'P', ' ', ' ', ' ', ' ', 'p', 'k'},
        {'Q', 'P', ' ', ' ', ' ', ' ', 'p', 'q'},
        {'B', 'P', ' ', ' ', ' ', ' ', 'p', 'b'},
        {'N', 'P', ' ', ' ', ' ', ' ', 'p', 'n'},
        {'R', 'P', ' ', ' ', ' ', ' ', 'p', 'r'}
    };
}
