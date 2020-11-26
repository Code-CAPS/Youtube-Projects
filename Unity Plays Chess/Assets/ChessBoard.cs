using System.Collections.Generic;
using UnityEngine;

public class ChessBoard : MonoBehaviour
{
    public GameObject whiteBishopPrefab = null;
    public GameObject whiteKingPrefab = null;
    public GameObject whiteKnightPrefab = null;
    public GameObject whitePawnPrefab = null;
    public GameObject whiteQueenPrefab = null;
    public GameObject whiteRookPrefab = null;

    public GameObject blackBishopPrefab = null;
    public GameObject blackKingPrefab = null;
    public GameObject blackKnightPrefab = null;
    public GameObject blackPawnPrefab = null;
    public GameObject blackQueenPrefab = null;
    public GameObject blackRookPrefab = null;

    public GameObject playableSurface = null;

    public string boardState = string.Empty;

    public Dictionary<string, GameObject> squares = null;

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Assertions.Assert.IsNotNull(whiteBishopPrefab);
        UnityEngine.Assertions.Assert.IsNotNull(whiteKingPrefab);
        UnityEngine.Assertions.Assert.IsNotNull(whiteKnightPrefab);
        UnityEngine.Assertions.Assert.IsNotNull(whitePawnPrefab);
        UnityEngine.Assertions.Assert.IsNotNull(whiteQueenPrefab);
        UnityEngine.Assertions.Assert.IsNotNull(whiteRookPrefab);

        UnityEngine.Assertions.Assert.IsNotNull(blackBishopPrefab);
        UnityEngine.Assertions.Assert.IsNotNull(blackKingPrefab);
        UnityEngine.Assertions.Assert.IsNotNull(blackKnightPrefab);
        UnityEngine.Assertions.Assert.IsNotNull(blackPawnPrefab);
        UnityEngine.Assertions.Assert.IsNotNull(blackQueenPrefab);
        UnityEngine.Assertions.Assert.IsNotNull(blackRookPrefab);

        UnityEngine.Assertions.Assert.IsNotNull(playableSurface);

        // Initialize the board.

        boardState = string.Empty;

        squares = new Dictionary<string, GameObject>();

        var boxCollider = playableSurface.GetComponent<BoxCollider>();
        UnityEngine.Assertions.Assert.IsNotNull(boxCollider);

        var playableSurfaceBounds = boxCollider.bounds;

        List<char> letters = new List<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
        List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };

        // this is bad again...

        Vector3 distanceBetweenSpaces = new Vector3();
        distanceBetweenSpaces.x = playableSurfaceBounds.size.x / letters.Count;
        distanceBetweenSpaces.z = playableSurfaceBounds.size.z / numbers.Count;

        for (int i = 0; i < letters.Count; ++i)
        {
            for (int j = 0; j < numbers.Count; ++j)
            {
                char letter = letters[i];
                int number = numbers[j];

                string squareName = letter + number.ToString();

                // hacky hacks - won't work in all directions and orienations!

                var theGO = new GameObject(squareName);
                theGO.transform.SetParent(playableSurface.transform);
                theGO.transform.localPosition = Vector3.zero;
                theGO.transform.localRotation = Quaternion.identity;
                theGO.transform.localScale = Vector3.one;

                // this part is specially bad

                float x = (i * distanceBetweenSpaces.x) + (distanceBetweenSpaces.x * 0.5f) - (playableSurfaceBounds.size.x * 0.5f);
                float z = (j * distanceBetweenSpaces.z) + (distanceBetweenSpaces.z * 0.5f) - (playableSurfaceBounds.size.z * 0.5f);

                theGO.transform.localPosition = new Vector3(x, 0.0f, z);

                // store it
                squares[squareName] = theGO;
            }
        }

        //
        // Create and place the pieces.

        // this part is not so bad

        // White Pieces
        var whitePawn = Instantiate(whitePawnPrefab);
        PlacePiece("a2", whitePawn);

        whitePawn = Instantiate(whitePawnPrefab);
        PlacePiece("b2", whitePawn);

        whitePawn = Instantiate(whitePawnPrefab);
        PlacePiece("c2", whitePawn);

        whitePawn = Instantiate(whitePawnPrefab);
        PlacePiece("d2", whitePawn);

        whitePawn = Instantiate(whitePawnPrefab);
        PlacePiece("e2", whitePawn);

        whitePawn = Instantiate(whitePawnPrefab);
        PlacePiece("f2", whitePawn);

        whitePawn = Instantiate(whitePawnPrefab);
        PlacePiece("g2", whitePawn);

        whitePawn = Instantiate(whitePawnPrefab);
        PlacePiece("h2", whitePawn);

        var whiteRook = Instantiate(whiteRookPrefab);
        PlacePiece("a1", whiteRook);

        whiteRook = Instantiate(whiteRookPrefab);
        PlacePiece("h1", whiteRook);

        var whiteKnight = Instantiate(whiteKnightPrefab);
        PlacePiece("b1", whiteKnight);

        whiteKnight = Instantiate(whiteKnightPrefab);
        PlacePiece("g1", whiteKnight);

        var whiteBishop = Instantiate(whiteBishopPrefab);
        PlacePiece("c1", whiteBishop);

        whiteBishop = Instantiate(whiteBishopPrefab);
        PlacePiece("f1", whiteBishop);

        var whiteQueen = Instantiate(whiteQueenPrefab);
        PlacePiece("d1", whiteQueen);

        var whiteKing = Instantiate(whiteKingPrefab);
        PlacePiece("e1", whiteKing);

        // Black Pieces
        var blackPawn = Instantiate(blackPawnPrefab);
        PlacePiece("a7", blackPawn);

        blackPawn = Instantiate(blackPawnPrefab);
        PlacePiece("b7", blackPawn);

        blackPawn = Instantiate(blackPawnPrefab);
        PlacePiece("c7", blackPawn);

        blackPawn = Instantiate(blackPawnPrefab);
        PlacePiece("d7", blackPawn);

        blackPawn = Instantiate(blackPawnPrefab);
        PlacePiece("e7", blackPawn);

        blackPawn = Instantiate(blackPawnPrefab);
        PlacePiece("f7", blackPawn);

        blackPawn = Instantiate(blackPawnPrefab);
        PlacePiece("g7", blackPawn);

        blackPawn = Instantiate(blackPawnPrefab);
        PlacePiece("h7", blackPawn);

        var blackRook = Instantiate(blackRookPrefab);
        PlacePiece("a8", blackRook);

        blackRook = Instantiate(blackRookPrefab);
        PlacePiece("h8", blackRook);

        var blackKnight = Instantiate(blackKnightPrefab);
        PlacePiece("b8", blackKnight);

        blackKnight = Instantiate(blackKnightPrefab);
        PlacePiece("g8", blackKnight);

        var blackBishop = Instantiate(blackBishopPrefab);
        PlacePiece("c8", blackBishop);

        blackBishop = Instantiate(blackBishopPrefab);
        PlacePiece("f8", blackBishop);

        var blackQueen = Instantiate(blackQueenPrefab);
        PlacePiece("d8", blackQueen);

        var blackKing = Instantiate(blackKingPrefab);
        PlacePiece("e8", blackKing);
    }

    GameObject GetPiece(string squareName)
    {
        GameObject result = null;

        if (squares.ContainsKey(squareName))
        {
            var square = squares[squareName];
            if (square.transform.childCount > 0)
            {
                result = square.transform.GetChild(0).gameObject;
            }
        }

        return result;
    }

    void PlacePiece(string squareName, GameObject piece)
    {
        if (squares.ContainsKey(squareName))
        {
            var square = squares[squareName];
            piece.transform.SetParent(square.transform, true);
            piece.transform.localRotation = Quaternion.identity;

            var theLerper = piece.AddComponent<Lerper>();
            theLerper.start = piece.transform.localPosition;
            theLerper.end = Vector3.zero;
        }
    }

    void RemovePiece(string squareName)
    {
        if (squares.ContainsKey(squareName))
        {
            var square = squares[squareName];
            foreach (Transform child in square.transform)
            {
                child.gameObject.AddComponent<Fader>();
            }
        }
    }

    public void MovePiece(string move)
    {
        UnityEngine.Assertions.Assert.IsTrue(move.Length == 4);

        if (string.IsNullOrEmpty(boardState))
        {
            boardState = move;
        }
        else
        {
            boardState = boardState + " " + move;
        }

        string originSquareName = move.Substring(0, 2);
        string destinationSquareName = move.Substring(2, 2);

        // we need to handle castling :(
        // uci considers it a GUI responsibility
        // :(

        // really crappy castling code
        // i didn't test it all
        // don't hate me

        bool didWeCastle = false;

        if (originSquareName == "e1")
        {
            // is it the white king?
            var king = GetPiece(originSquareName);
            if (king != null && king.name.Contains("White King"))
            {
                if (destinationSquareName == "g1")
                {
                    // short castle
                    // g1 and f1

                    didWeCastle = true;

                    PlacePiece(destinationSquareName, king);

                    var rook = GetPiece("h1");
                    if (rook != null)
                    {
                        PlacePiece("f1", rook);
                    }
                }
                else if (destinationSquareName == "c1")
                {
                    // long castle
                    // c1 and d1

                    didWeCastle = true;

                    PlacePiece(destinationSquareName, king);

                    var rook = GetPiece("a1");
                    if (rook != null)
                    {
                        PlacePiece("d1", rook);
                    }
                }
            }
        }
        else if (originSquareName == "e8")
        {
            // is it the black king?

            var king = GetPiece(originSquareName);
            if (king != null && king.name.Contains("Black King"))
            {
                if (destinationSquareName == "g8")
                {
                    // short castle
                    // g8 and f8

                    didWeCastle = true;

                    PlacePiece(destinationSquareName, king);

                    var rook = GetPiece("h8");
                    if (rook != null)
                    {
                        PlacePiece("f8", rook);
                    }
                }
                else if (destinationSquareName == "c8")
                {
                    // long castle
                    // c8 and d8

                    didWeCastle = true;

                    PlacePiece(destinationSquareName, king);

                    var rook = GetPiece("a8");
                    if (rook != null)
                    {
                        PlacePiece("d8", rook);
                    }
                }
            }
        }

        if (!didWeCastle)
        {
            // normal case!

            RemovePiece(destinationSquareName);

            var piece = GetPiece(originSquareName);
            if (piece != null)
            {
                PlacePiece(destinationSquareName, piece);
            }
        }
    }
}
