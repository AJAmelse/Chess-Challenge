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
            int whitePawns = pieces[0].Count * pieceValues[1];
            Console.WriteLine(whitePawns);
            int whiteKnights = pieces[1].Count * pieceValues[2];
            Console.WriteLine(whiteKnights);
            int whiteBishops = pieces[2].Count * pieceValues[3];
            Console.WriteLine(whiteBishops);
            int whiteRooks = pieces[3].Count * pieceValues[4];
            Console.WriteLine(whiteRooks);
            int whiteQueens = pieces[4].Count * pieceValues[5];
            Console.WriteLine(whiteQueens);
            int blackPawns = pieces[6].Count * pieceValues[1];
            Console.WriteLine(blackPawns);
            int blackKnights = pieces[7].Count * pieceValues[2];
            Console.WriteLine(blackKnights);
            int blackBishops = pieces[8].Count * pieceValues[3];
            Console.WriteLine(blackBishops);
            int blackRooks = pieces[9].Count * pieceValues[4];
            Console.WriteLine(blackRooks);
            int blackQueens = pieces[10].Count * pieceValues[5];
            Console.WriteLine(blackQueens);
            
            int whitePieceValue = whitePawns + whiteKnights + whiteBishops + whiteRooks + whiteQueens;
            int blackPieceValue = blackPawns + blackKnights + blackBishops + blackRooks + blackQueens; 

            bool isMate = board.IsInCheckmate();
            bool isCheck = board.IsInCheck();
            eval = eval + whitePieceValue - blackPieceValue;

 
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