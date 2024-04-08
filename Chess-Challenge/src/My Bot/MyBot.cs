using ChessChallenge.API;

public class MyBot : IChessBot
{
    (ulong, Move, int, int, byte)[] TT = new (ulong, Move, int, int, byte)[2097152];

    public Move Think(Board board, Timer timer)
    {
        Move rBestMove = default;

    var (killers, allocatedTime, i, score, depth) = (new Move[256], timer.MillisecondsRemaining / 8, 0, 0, 1);

 int Search(int ply, int depth, int alpha, int beta, bool nullAllowed)
        {
            
        }

        Move[] moves = board.GetLegalMoves();
        return moves[0];
    }
}