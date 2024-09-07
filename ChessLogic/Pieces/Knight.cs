namespace ChessLogic
{
    public class Knight : Piece
    {
        public override PieceType Type => PieceType.Knight;
        public override Player Colour { get; }

        public Knight(Player colour)
        {
            Colour = colour;
        }

        public override Piece Copy()
        {
            Knight copy = new Knight(Colour);
            copy.HasMoved = HasMoved;
            return copy;
        }

        //Direction that the knights can move
        private static IEnumerable<Position> PotentialToPositions(Position from)
        {
            foreach (Direction vDir in new Direction[] { Direction.North, Direction.South })
            {
                foreach (Direction hDir in new Direction[] { Direction.West, Direction.East })
                {
                    yield return from + 2 * vDir + hDir;
                    yield return from + 2 * hDir + vDir;
                }
            }
        }

        private IEnumerable<Position> MovePositions(Position from, Board board)
        {
            return PotentialToPositions(from).Where(pos => Board.IsInside(pos) && (board.IsEmpty(pos) || board[pos].Colour != Colour));

        }

        public override IEnumerable<Move> GetMoves(Position from, Board board)
        {
            return MovePositions(from, board).Select(to => new NormalMove(from, to));
        }

    }
}