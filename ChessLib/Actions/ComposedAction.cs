#region usings

using System.Collections.Generic;

#endregion

namespace ChessLib.Actions
{
    ///<summary>
    ///
    ///</summary>
    public class ComposedMoveAction : MoveAction
    {
        private readonly List<MoveAction> _movesList;

        ///<summary>
        ///
        ///</summary>
        ///<param name="movesList"></param>
        public ComposedMoveAction(IEnumerable<MoveAction> movesList)
        {
            this._movesList = new List<MoveAction>(movesList);
        }

        ///<summary>
        ///Position de départ du mouvement
        ///</summary>
        public override PiecePosition StartingPosition
        {
            get { return this._movesList[0].StartingPosition; }
        }

        ///<summary>
        ///
        ///</summary>
        public override PiecePosition ArrivalPosition
        {
            get { return this._movesList[this._movesList.Count - 1].ArrivalPosition; }
        }

        ///<summary>
        ///
        ///</summary>
        public bool VerifyMovement { get; set; }

        ///<summary>
        ///Effectue l'action de mouvement.
        ///</summary>
        ///<returns></returns>
        public override bool Do()
        {
            foreach (MoveAction action in this._movesList)
            {
                if (action.Do() == false)
                {
                    return false;
                }
            }

            return true;
        }

        ///<summary>
        ///Annule l'action de mouvement.
        ///</summary>
        ///<returns></returns>
        public override bool UnDo()
        {
            foreach (MoveAction action in this._movesList)
            {
                if (action.UnDo() == false)
                {
                    return false;
                }
            }

            return true;
        }
    }
}