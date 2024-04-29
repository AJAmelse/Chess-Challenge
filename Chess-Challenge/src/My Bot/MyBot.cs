using ChessChallenge.API;
using System;
using System.Diagnostics;

public class MyBot : IChessBot
{
    
    readonly int[] pieceValues = { 0, 100, 300, 300, 500, 900, 10000 };
    readonly int checkValue = 50;

    private const int MaxDepth = 6;
    public Move Think(Board board, Timer timer)
    {
        Move[] allMoves = board.GetLegalMoves();

        
        Move moveToPlay = rootNegamax();
        

        Move rootNegamax(){
            Move bestMove = default;
            int bestScore = int.MinValue;
            Move[] allMoves = board.GetLegalMoves();

            foreach(Move move in allMoves){
                board.MakeMove(move);    
                bool playerColor = board.IsWhiteToMove;          
                int score = -Negamax(MaxDepth - 1, int.MinValue, int.MaxValue);
                board.UndoMove(move);

                if (score > bestScore){
                    bestScore = score;
                    bestMove = move;
                }
            }
            return bestMove;

        }

        int Negamax(int Depth, int alpha, int beta)
        {
            if (Depth == 0 || board.IsDraw()|| board.IsInCheckmate()){
                
                return Eval(board);
                
            } 

            int bestScore = int.MinValue;
            Move[] allMoves = board.GetLegalMoves();

            foreach(Move move in allMoves){
                board.MakeMove(move);
                int score = -Negamax(Depth - 1, -alpha, -beta);
                board.UndoMove(move);
                
                bestScore = Math.Max(bestScore, score);

                alpha = Math.Max(alpha, score);
                if (alpha >= beta){
                    return Eval(board);
                }

                
            }
            Console.WriteLine(bestScore);
            return bestScore;
        }


        int Eval(Board board){
            int eval = default;
            
            PieceList[] pieces = board.GetAllPieceLists();
            int whitePawns = pieces[0].Count * pieceValues[1];
            int whiteKnights = pieces[1].Count * pieceValues[2];
            int whiteBishops = pieces[2].Count * pieceValues[3];
            int whiteRooks = pieces[3].Count * pieceValues[4];
            int whiteQueens = pieces[4].Count * pieceValues[5];
            int whiteKings = pieces[5].Count * pieceValues[6];
            int blackPawns = pieces[6].Count * pieceValues[1];
            int blackKnights = pieces[7].Count * pieceValues[2];
            int blackBishops = pieces[8].Count * pieceValues[3];
            int blackRooks = pieces[9].Count * pieceValues[4];
            int blackQueens = pieces[10].Count * pieceValues[5];
            int blackKings = pieces[11].Count * pieceValues[6];
 
            
            int whitePieceValue = whitePawns + whiteKnights + whiteBishops + whiteRooks + whiteQueens;
            int blackPieceValue = blackPawns + blackKnights + blackBishops + blackRooks + blackQueens; 

            bool isMate = board.IsInCheckmate();
            bool isCheck = board.IsInCheck();
            bool isDraw = board.IsDraw();
            
            if(board.IsWhiteToMove){
                eval += whitePieceValue - blackPieceValue;
                if(isMate){
                    eval += 100000000;
                }
                if(isCheck){
                    eval += 50;
                }
                if(isDraw){
                    eval -= 300;
                }
            }
            if(!board.IsWhiteToMove){
                eval += blackPieceValue - whitePieceValue;
                if(isMate){
                    eval -= 100000000;
                }
                if(isCheck){
                    eval -= 50;
                }
                if (isDraw){
                    eval += 300;
                }
            }

        
            return eval;
        }

        

      return moveToPlay;

    }
}