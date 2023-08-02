using ChessChallenge.API;
using System;

public class MyBot : IChessBot
{
    
    readonly int[] pieceValues = { 0, 100, 300, 300, 500, 900, 10000 };
    readonly int checkValue = 50;
    public Move Think(Board board, Timer timer)
    {
        Move[] allMoves = board.GetLegalMoves();

        Random rng = new();
            Move moveToPlay = allMoves[rng.Next(allMoves.Length)];
            int HighestEval = 0;

        foreach(Move move in allMoves){
            
            Piece capturedPiece = board.GetPiece(move.TargetSquare);
            int capturedPieceValue = pieceValues[(int)capturedPiece.PieceType];

            int moveEval = capturedPieceValue;

            if(MoveIsCheck(board, move)){
                moveEval = checkValue + moveEval;
            }


            if (MoveIsCheckmate(board, move))
                {
                    moveToPlay = move;
                    break;
                }

            if (moveEval > HighestEval){
                moveToPlay = move;
                moveEval = HighestEval;
            }


                
        }

    

        return moveToPlay;

        static bool MoveIsCheckmate(Board board, Move move)
        {
            board.MakeMove(move);
            bool isMate = board.IsInCheckmate();
            board.UndoMove(move);
            return isMate;
        }

        static bool MoveIsCheck(Board board, Move move){
            board.MakeMove(move);
            bool isCheck = board.IsInCheck();
            board.UndoMove(move);
            return isCheck;
        }

        static bool PieceIsAttacked(Board board, Move move, Square square){
            board.MakeMove(move);
            bool IsAttacked = board.SquareIsAttackedByOpponent(Square )

        }
        

    }
}