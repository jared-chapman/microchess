// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

public static class DefaultBoards
{



    public static readonly char[,] standard = new char[8, 8]
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

    public static readonly char[,] test = new char[8, 8]
    {
        {'R', 'P', ' ', ' ', ' ', ' ', 'p', 'r'},
        {'N', 'P', ' ', ' ', ' ', ' ', 'p', 'n'},
        {'B', 'P', ' ', ' ', ' ', ' ', 'p', 'b'},
        {'K', 'P', ' ', ' ', ' ', ' ', 'p', 'k'},
        {'Q', ' ', ' ', ' ', ' ', ' ', 'p', 'q'},
        {'B', 'P', ' ', ' ', ' ', ' ', 'p', 'b'},
        {'N', 'P', ' ', ' ', ' ', ' ', 'p', 'n'},
        {'R', ' ', ' ', ' ', ' ', ' ', 'p', 'r'}
    };
}
