using RefactoringToPatterns.State.Common;
using RefactoringToPatterns.State.Common.Enum;
using RefactoringToPatterns.State.Common.Exceptions.Permission;
using RefactoringToPatterns.State.Common.Exceptions.Status;

namespace RefactoringToPatterns.State.Step0
{
    public class WishListItem
    {
        private const decimal AdditionalAcceptanceCostAmount = 5000;
        private readonly bool _areCostsInvoiced;
        private readonly decimal _itemCost;
        private readonly User _owner;
        private WishListItemStatus _status;

        public WishListItem(
            WishListItemStatus status,
            User owner,
            decimal itemCost,
            bool areCostsInvoiced = true)
        {
            _owner = owner;
            _status = status;
            _itemCost = itemCost;
            _areCostsInvoiced = areCostsInvoiced;
        }

        public void AcceptBy(User user)
        {
            if (_status != WishListItemStatus.Requested &&
                _status != WishListItemStatus.RequestedToDirector)
            {
                throw new CannotAcceptWishListItemWithCurrentStatusException(_status);
            }

            if (_status == WishListItemStatus.Requested)
            {
                if (!user.IsLeaderOf(_owner))
                {
                    throw new UserDoesNotHavePermissionToAcceptRequestedWishListItemException();
                }

                if (ShouldBeRequestedToDirector())
                {
                    _status = WishListItemStatus.RequestedToDirector;
                }
                else
                {
                    _status = WishListItemStatus.Accepted;
                }

                return;
            }

            if (!user.IsDirectorOf(_owner))
            {
                throw new UserDoesNotHavePermissionToAcceptRequestedWishListItemException();
            }

            _status = WishListItemStatus.Accepted;
        }

        public void RejectBy(User user)
        {
            if (_status != WishListItemStatus.Requested &&
                _status != WishListItemStatus.RequestedToDirector)
            {
                throw new CannotRejectWishListItemWithCurrentStatusException(_status);
            }

            if (_status == WishListItemStatus.Requested)
            {
                if (!user.IsLeaderOf(_owner))
                {
                    throw new UserDoesNotHavePermissionToRejectRequestedWishListItemException();
                }

                _status = WishListItemStatus.Rejected;

                return;
            }

            if (!user.IsDirectorOf(_owner))
            {
                throw new UserDoesNotHavePermissionToRejectRequestedWishListItemException();
            }

            _status = WishListItemStatus.Rejected;
        }

        public void StartRealizationBy(User user)
        {
            if (_status != WishListItemStatus.Accepted)
            {
                throw new CannotStartWishListItemRealizationWithCurrentStatusException(_status);
            }

            if (!user.IsSupervisor)
            {
                throw new UserDoesNotHavePermissionToStartWishListItemRealizationException();
            }

            _status = WishListItemStatus.InRealization;
        }

        public void FinishRealizationBy(User user)
        {
            if (_status != WishListItemStatus.InRealization)
            {
                throw new CannotFinishWishListItemRealizationWithCurrentStatusException(_status);
            }

            if (!user.IsSupervisor)
            {
                throw new UserDoesNotHavePermissionToFinishWishListItemRealizationException();
            }

            if (!_areCostsInvoiced)
            {
                throw new CannotFinishWishListItemRealizationWithNotInvoicedException();
            }

            _status = WishListItemStatus.Realized;
        }

        private bool ShouldBeRequestedToDirector()
        {
            return _itemCost >= AdditionalAcceptanceCostAmount;
        }
    }
}