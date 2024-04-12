using ChessChallenge.API;
using System;
using System.Diagnostics;

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
            
            Square square = move.TargetSquare;

            int moveEval = Eval(board, move, square);



            if (moveEval > HighestEval){
                moveToPlay = move;
                moveEval = HighestEval;
                
            }


                
        }

    

        return moveToPlay;

        int Eval(Board board, Move move, Square square){
            int eval = default;
            Piece capturedPiece = board.GetPiece(move.TargetSquare);
            board.MakeMove(move);
            bool isMate = board.IsInCheckmate();
            bool isCheck = board.IsInCheck();
            bool isAttacked = board.SquareIsAttackedByOpponent(square);
            int captureValue = pieceValues[(int)capturedPiece.PieceType];

            if (captureValue >= 0){
                eval = eval + captureValue;
            }
            if (isMate){
                eval = eval += 1000000;
            }
            if (isCheck){
                eval = eval -= 50;
            }
            if (isAttacked){
                eval = eval -= pieceValues[(int)move.MovePieceType];
            }
            board.UndoMove(move);
            Console.WriteLine(eval);
            return eval;
        }



        /*static bool MoveIsPromotion(Board board, Move move){
            board.MakeMove(move);
            bool IsPromotion = 
        }
        */

    }
}