#region usings

using System;
using ChessLib.Pieces;

#endregion

namespace ChessLib.Actions
{
    ///<summary>
    ///
    ///</summary>
    public class DeleteAction : Action
    {
        private readonly Game _game;
        private readonly PiecePosition _piecePosition;
        private BasePiece _piece;

        ///<summary>
        ///
        ///</summary>
        ///<param name="game"></param>
        ///<param name="piecePosition"></param>
        public DeleteAction(Game game, PiecePosition piecePosition)
        {
            this._game = game;
            this._piecePosition = piecePosition;
        }

        ///<summary>
        ///
        ///</summary>
        ///<returns></returns>
        ///<exception cref="NotImplementedException"></exception>
        public override bool Do()
        {
            this._piece = this._game.Board.GetPiece(this._piecePosition);

            if (this._piecePosition == null)
            {
                return false;
            }


            return this._game.Board.GetPiecesCollection(this._piece.Color).Remove(this._piece);
        }

        ///<summary>
        ///
        ///</summary>
        ///<returns></returns>
        ///<exception cref="NotImplementedException"></exception>
        public override bool UnDo()
        {
            this._game.Board.GetPiecesCollection(this._piece.Color).Add(this._piece);

            return this._game.Board.GetPiece(this._piecePosition) == this._piece;
        }
    }
}