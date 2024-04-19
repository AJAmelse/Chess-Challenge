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

        foreach(Move move in allMoves){
            
            Square square = move.TargetSquare;

            int moveEval = Eval(board);

            int Negamax(int Depth)
        {
            if (Depth == 0){
                return Eval(board);
            } 

            int max = -2000000000;
            foreach(Move move in allMoves){
                board.MakeMove(move);
                int eval = -Negamax(Depth - 1);
                if(eval>max){
                    max = eval;
                }
                board.UndoMove(move);
            }

            return max;
        }


                
        }

    

        return moveToPlay;

        int Eval(Board board){
            int eval = default;
            
            PieceList[] pieces = board.GetAllPieceLists();
            int whitePawns = pieces[0].Count;
            Console.WriteLine(whitePawns);
            bool isMate = board.IsInCheckmate();
            bool isCheck = board.IsInCheck();

 
            if (isMate){
                eval = eval += 1000000;
            }
            if (isCheck){
                eval = eval -= 50;
            }

            
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