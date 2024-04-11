using System.Security.Cryptography.X509Certificates;
using ChessChallenge.API;

public class MyBot : IChessBot
{
    

    public Move Think(Board board, Timer timer)
    {
        Move[] allMoves = board.GetLegalMoves();
        Move rBestMove = default;
        int score = -2000000;

    int Negamax(int Depth)
        {
            if (Depth == 0){
                rBestMove = allMoves[1];
                return rBestMove;
            } 

            int max = -2000000000;
            foreach(Move move in allMoves){
                rBestMove
            }
        }

        Move[] moves = board.GetLegalMoves();
        return moves[0];
    }
}