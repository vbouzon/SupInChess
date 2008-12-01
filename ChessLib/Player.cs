#region usings

using ChessLib.Pieces;

#endregion

namespace ChessLib
{
    public class Player
    {
        private readonly Game _parentGame;
        private readonly PieceColor _pieceColor;
        private readonly PiecesCollection _piecesCollection;

        ///<summary>
        ///
        ///</summary>
        ///<param name="parentGame"></param>
        ///<param name="pieceColor"></param>
        public Player(Game parentGame, PieceColor pieceColor)
        {
            this._parentGame = parentGame;
            this._pieceColor = pieceColor;
            this._piecesCollection = this._parentGame.Board.GetPiecesCollection(this.Color);
        }

        ///<summary>
        ///
        ///</summary>
        public bool IsChess
        {
            get
            {
                PiecePosition kingPosition = this._piecesCollection.Find(p => p.GetType() == typeof (King)).Position;

                foreach (BasePiece piece in this._parentGame.Board.GetPiecesCollection((this.Color == PieceColor.White) ? PieceColor.Black : PieceColor.White))
                {
                    if (piece.AvailableMovements.ContainsKey(kingPosition))
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        public bool IsMat
        {
            get
            {
                PiecePosition kingPosition = this._piecesCollection.Find(p => p.GetType() == typeof (King)).Position;

                foreach (BasePiece piece in this._parentGame.Board.GetPiecesCollection(this.Color))
                {
                    foreach (PiecePosition position in piece.AvailableMovements.Keys)
                    {
                        if (piece.CanMove(position))
                        {
                            return false;
                        }
                    }
                }

                return true;
            }
        }

        ///<summary>
        ///
        ///</summary>
        public PieceColor Color
        {
            get { return this._pieceColor; }
        }
    }
}