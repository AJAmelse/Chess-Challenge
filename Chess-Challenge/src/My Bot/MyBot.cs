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
            
            Piece capturedPiece = board.GetPiece(move.TargetSquare);
            int capturedPieceValue = pieceValues[(int)capturedPiece.PieceType];
            Square square = move.TargetSquare;

            int moveEval = capturedPieceValue;



            if (moveEval > HighestEval){
                moveToPlay = move;
                moveEval = HighestEval;
                
            }
            Console.WriteLine(moveEval);


                
        }

    

        return moveToPlay;

        int Eval(Board board, Move move, Square square){
            int eval = -200000;
            board.MakeMove(move);
            bool isMate = board.IsInCheckmate();
            bool isCheck = board.IsInCheck();
            bool isAttacked = board.SquareIsAttackedByOpponent(square);
            
            if (isMate){
                eval = eval += 1000000;
            }
            if (isCheck){
                eval = eval -= 70;
            }
            if (isAttacked){
                eval = eval -= pieceValues[(int)move.MovePieceType];
            }
            
            return eval;
        }



        /*static bool MoveIsPromotion(Board board, Move move){
            board.MakeMove(move);
            bool IsPromotion = 
        }
        */

    }
}