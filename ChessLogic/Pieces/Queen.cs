using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public class Queen : Piece
    {
        public override PieceType Type => PieceType.Queen;
        public override Player Colour { get; }

        //Directions for the queen
        public readonly Direction[] dirs = new Direction[]
        {
            Direction.North,
            Direction.South,
            Direction.East,
            Direction.West,
            Direction.NorthWest,
            Direction.NorthEast,
            Direction.SouthEast,
            Direction.SouthWest
        };
        public Queen(Player colour)
        {
            Colour = colour;
        }

        public override Piece Copy()
        {
            Queen copy = new Queen(Colour);
            copy.HasMoved = HasMoved;
            return copy;
        }


        //Show Moves for the queen
        public override IEnumerable<Move> GetMoves(Position from, Board board)
        {
            return MovePositionsInDirs(from, board, dirs).Select(to => new NormalMove(from, to));
        }
    }
}
