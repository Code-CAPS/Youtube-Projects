using System.Collections;
using UnityEngine;

public class AIVersusAIGameState : MonoBehaviour
{
    public bool isReady = false;
    public bool isSimulating = false;

    public ChessBoard chessBoard = null;
    public ChessEngine white = null;
    public ChessEngine black = null;

    private float timeToThinkWhite = 1.0f;
    private float timeToThinkBlack = 1.0f;

    public int turn = 1;

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Assertions.Assert.IsNotNull(chessBoard);
        UnityEngine.Assertions.Assert.IsNotNull(white);
        UnityEngine.Assertions.Assert.IsNotNull(black);

        isReady = false;
        isSimulating = false;

        turn = 1;

        timeToThinkWhite = Random.Range(1.0f, 5.0f);
        timeToThinkBlack = Random.Range(1.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isReady)
        {
            if (!isSimulating)
            {
                isSimulating = true;
                StartCoroutine("SimulateTurn");
            }
        }
        else
        {
            if (white.isReady && black.isReady)
            {
                isReady = true;
            }
        }
    }

    IEnumerator SimulateTurn()
    {
        // have white move

        white.CalculateNextMove(chessBoard.boardState);

        yield return new WaitForSeconds(timeToThinkWhite);

        white.Stop();

        // poll it out
        while (string.IsNullOrWhiteSpace(white.bestMove))
        {
            yield return new WaitForSeconds(0.3f);
        }

        // update board state
        chessBoard.MovePiece(white.bestMove);

        // have black move

        black.CalculateNextMove(chessBoard.boardState);

        yield return new WaitForSeconds(timeToThinkBlack);

        black.Stop();

        // poll it out
        while (string.IsNullOrWhiteSpace(black.bestMove))
        {
            yield return new WaitForSeconds(0.3f);
        }

        // update board state
        chessBoard.MovePiece(black.bestMove);

        // end of turn
        turn = turn + 1;
        isSimulating = false;
    }
}
