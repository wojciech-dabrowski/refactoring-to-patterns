using RefactoringToPatterns.State.Common;
using RefactoringToPatterns.State.Common.Enum;
using RefactoringToPatterns.State.Step3.State;

namespace RefactoringToPatterns.State.Step3
{
    public class WishListItem
    {
        public WishListItem(
            WishListItemStatus status,
            User owner,
            decimal itemCost,
            bool areCostsInvoiced = true)
        {
            Owner = owner;
            ItemCost = itemCost;
            AreCostsInvoiced = areCostsInvoiced;
            State = WishListItemState.CreateState(status);
        }

        internal WishListItemState State { get; set; }
        public WishListItemStatus Status => State.Status;
        internal User Owner { get; }
        internal bool AreCostsInvoiced { get; }
        internal decimal ItemCost { get; }

        public void AcceptBy(User user)
        {
            State.AcceptBy(user, this);
        }

        public void RejectBy(User user)
        {
            State.RejectBy(user, this);
        }

        public void StartRealizationBy(User user)
        {
            State.StartRealizationBy(user, this);
        }

        public void FinishRealizationBy(User user)
        {
            State.FinishRealizationBy(user, this);
        }
    }
}