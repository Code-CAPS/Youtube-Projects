using System.Diagnostics;
using System.Threading.Tasks;
using UnityEngine;

public class ChessEngine : MonoBehaviour
{
    public bool isReady = false;
    public bool isThinking = false;
    public string boardState = string.Empty;
    public string bestMove = string.Empty;

    Process process = null;
    Task<string> readingLineTask = null;

    // Start is called before the first frame update
    void Start()
    {
        isReady = false;
        isThinking = false;
        boardState = string.Empty;
        bestMove = string.Empty;

        // TODO: You will need to change this path to match your environment on your computer!
        string chessEnginePath = @"""E:\youtube\git\Youtube-Projects\Unity Plays Chess\Resources\stockfish_20090216_x64_bmi2.exe""";
        ProcessStartInfo processStartInfo = new ProcessStartInfo(chessEnginePath);

        processStartInfo.UseShellExecute = false;
        processStartInfo.RedirectStandardOutput = true;
        processStartInfo.RedirectStandardInput = true;
        processStartInfo.CreateNoWindow = true;

        if (process != null)
        {
            process.Kill();
            process = null;
        }

        process = Process.Start(processStartInfo);
    }

    // Update is called once per frame
    void Update()
    {
        if (process != null)
        {
            if (readingLineTask == null)
            {
                readingLineTask = process.StandardOutput.ReadLineAsync();
                readingLineTask.ContinueWith((readingLineTaskOutput) =>
                {
                    string theOutput = readingLineTaskOutput.Result;
                    if (!string.IsNullOrWhiteSpace(theOutput))
                    {
                        // too much spam
                        //UnityEngine.Debug.Log("Chess Engine Output: " + theOutput);

                        if (theOutput.Contains("Stockfish 12 by the Stockfish"))
                        {
                            // Continue startup.
                            process.StandardInput.WriteLine("uci");
                        }
                        else if (theOutput.Contains("uciok"))
                        {
                            // Continue startup.
                            process.StandardInput.WriteLine("ucinewgame");
                            process.StandardInput.WriteLine("isready");
                        }
                        else if (theOutput.Contains("readyok"))
                        {
                            // We are ready to play.
                            isReady = true;
                        }
                        else if (theOutput.Contains("bestmove"))
                        {
                            string[] theOutputDelimited = theOutput.Split(new[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries);
                            if (theOutputDelimited != null && theOutputDelimited.Length >= 2)
                            {
                                bestMove = theOutputDelimited[1];
                            }
                        }
                    }

                    // Setup to read the next line.
                    readingLineTask = null;
                });
            }
        }
    }

    void OnDestroy()
    {
        if (process != null && !process.HasExited)
        {
            process.Kill();
        }
        process = null;
    }

    [ContextMenu("Stop")]
    public void Stop()
    {
        if (process != null && !process.HasExited && isReady)
        {
            process.StandardInput.WriteLine("stop");

            isThinking = false;
        }
    }

    [ContextMenu("CalculateNextMove")]
    public void CalculateNextMove()
    {
        // helper function for messing around in the inspector
        this.CalculateNextMove(this.boardState);
    }

    public void CalculateNextMove(string boardState)
    {
        this.boardState = boardState;
        this.bestMove = string.Empty;

        if (process != null && !process.HasExited && isReady)
        {
            if (isThinking)
            {
                Stop();
            }

            if (!isThinking)
            {
                isThinking = true;

                if (!string.IsNullOrWhiteSpace(boardState))
                {
                    string theMove = "position startpos moves " + this.boardState;
                    process.StandardInput.WriteLine(theMove);
                }

                process.StandardInput.WriteLine("go");
            }
        }
    }
}
