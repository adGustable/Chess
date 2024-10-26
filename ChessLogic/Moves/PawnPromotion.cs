using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public class PawnPromotion : Move
    {
        public override MoveType Type => MoveType.PawnPromotion;
        public override Position ToPos { get; }
        public override Position FromPos { get; }
        private readonly PieceType newType;

        public PawnPromotion(Position from, Position to, PieceType newType)
        {
            FromPos = from;
            ToPos = to;
            this.newType = newType;
        }

        private Piece CreatePromotionPiece(Player colour)
        {
            return newType switch
            {
                PieceType.Knight => new Knight(colour),
                PieceType.Bishop => new Bishop(colour),
                PieceType.Rook => new Rook(colour),
                _ => new Queen(colour),
            };
        }

        public override void Execute(Board board)
        {
            Piece pawn = board[FromPos];
            board[FromPos] = null;

            Piece promotionPiece = CreatePromotionPiece(pawn.Colour);
            promotionPiece.HasMoved = true;
            board[ToPos] = promotionPiece;
        }
    }
}
