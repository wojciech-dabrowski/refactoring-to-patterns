using RefactoringToPatterns.State.Common;
using RefactoringToPatterns.State.Common.Enum;
using RefactoringToPatterns.State.Common.Exceptions.Permission;
using RefactoringToPatterns.State.Common.Exceptions.Status;
using RefactoringToPatterns.State.Step2.State;

namespace RefactoringToPatterns.State.Step2
{
    public class WishListItem
    {
        private const decimal AdditionalAcceptanceCostAmount = 5000;
        private readonly bool _areCostsInvoiced;
        private readonly decimal _itemCost;
        private readonly User _owner;

        public WishListItem(
            WishListItemStatus status,
            User owner,
            decimal itemCost,
            bool areCostsInvoiced = true)
        {
            _owner = owner;
            _itemCost = itemCost;
            _areCostsInvoiced = areCostsInvoiced;
            State = WishListItemState.CreateState(status);
        }

        private WishListItemState State { get; set; }
        public WishListItemStatus Status => State.Status;

        public void AcceptBy(User user)
        {
            if (State.Status != WishListItemStatus.Requested &&
                State.Status != WishListItemStatus.RequestedToDirector)
            {
                throw new CannotAcceptWishListItemWithCurrentStatusException(State.Status);
            }

            if (State.Status == WishListItemStatus.Requested)
            {
                if (!user.IsLeaderOf(_owner))
                {
                    throw new UserDoesNotHavePermissionToAcceptRequestedWishListItemException();
                }

                if (ShouldBeRequestedToDirector())
                {
                    State = WishListItemState.RequestedToDirector;
                }
                else
                {
                    State = WishListItemState.Accepted;
                }

                return;
            }

            if (!user.IsDirectorOf(_owner))
            {
                throw new UserDoesNotHavePermissionToAcceptRequestedWishListItemException();
            }

            State = WishListItemState.Accepted;
        }

        public void RejectBy(User user)
        {
            if (State.Status != WishListItemStatus.Requested &&
                State.Status != WishListItemStatus.RequestedToDirector)
            {
                throw new CannotRejectWishListItemWithCurrentStatusException(State.Status);
            }

            if (State.Status == WishListItemStatus.Requested)
            {
                if (!user.IsLeaderOf(_owner))
                {
                    throw new UserDoesNotHavePermissionToRejectRequestedWishListItemException();
                }

                State = WishListItemState.Rejected;

                return;
            }

            if (!user.IsDirectorOf(_owner))
            {
                throw new UserDoesNotHavePermissionToRejectRequestedWishListItemException();
            }

            State = WishListItemState.Rejected;
        }

        public void StartRealizationBy(User user)
        {
            if (State.Status != WishListItemStatus.Accepted)
            {
                throw new CannotStartWishListItemRealizationWithCurrentStatusException(State.Status);
            }

            if (!user.IsSupervisor)
            {
                throw new UserDoesNotHavePermissionToStartWishListItemRealizationException();
            }

            State = WishListItemState.InRealization;
        }

        public void FinishRealizationBy(User user)
        {
            if (State.Status != WishListItemStatus.InRealization)
            {
                throw new CannotFinishWishListItemRealizationWithCurrentStatusException(State.Status);
            }

            if (!user.IsSupervisor)
            {
                throw new UserDoesNotHavePermissionToFinishWishListItemRealizationException();
            }

            if (!_areCostsInvoiced)
            {
                throw new CannotFinishWishListItemRealizationWithNotInvoicedException();
            }

            State = WishListItemState.Realized;
        }

        private bool ShouldBeRequestedToDirector()
        {
            return _itemCost >= AdditionalAcceptanceCostAmount;
        }
    }
}