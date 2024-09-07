using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public abstract class Piece
    {
        public abstract PieceType Type { get; }
        public abstract Player Colour { get; }
        public bool HasMoved { get; set; } = false;

        public abstract Piece Copy();

        public abstract IEnumerable<Move> GetMoves(Position from, Board board);

        //Finds where the piece can move too
        protected IEnumerable<Position> MovePositionsInDir(Position from, Board board, Direction dir)
        {
            for(Position pos = from + dir; Board.IsInside(pos); pos += dir)
            {
                if (board.IsEmpty(pos))
                {
                    yield return pos;
                    continue;
                }

                Piece piece = board[pos];

                if (piece.Colour != Colour)
                {
                    yield return pos;
                }

                yield break;


            }
        }


        protected IEnumerable<Position> MovePositionsInDirs(Position from, Board board, Direction[] dirs)
        {
            //Gives all reachable squares in the given directions
            return dirs.SelectMany(dir => MovePositionsInDir(from, board, dir));
        }

    }
}
