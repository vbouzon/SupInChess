#region usings

using System.Collections.Generic;

#endregion

namespace ChessLib.Actions
{
    ///<summary>
    ///
    ///</summary>
    public class ActionsManager
    {
        private readonly Stack<Action> _actionsList;

        ///<summary>
        ///
        ///</summary>
        public ActionsManager()
        {
            this._actionsList = new Stack<Action>();
        }

        ///<summary>
        ///
        ///</summary>
        public Stack<Action> ActionsList
        {
            get { return this._actionsList; }
        }


        ///<summary>
        ///
        ///</summary>
        ///<param name="action"></param>
        ///<returns></returns>
        public bool Do(Action action)
        {
            if (action.Do() == false)
            {
                return false;
            }

            this.ActionsList.Push(action);

            return true;
        }

        ///<summary>
        ///
        ///</summary>
        ///<returns></returns>
        public bool UnDo()
        {
            do
            {
                Action action = this._actionsList.Pop();
                if (action.UnDo() == false)
                {
                    return false;
                }

                if (this._actionsList.Count == 0 || this._actionsList.Peek().GetType() != typeof (DeleteAction))
                {
                    break;
                }
            } while (true);

            return true;
        }
    }
}