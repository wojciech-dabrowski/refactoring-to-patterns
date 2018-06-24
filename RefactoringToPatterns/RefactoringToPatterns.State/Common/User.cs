using System;

namespace RefactoringToPatterns.State.Common
{
    public class User : IEquatable<User>
    {
        public User(
            Guid id,
            string fullName,
            User leader = null,
            Department department = null,
            bool isSupervisor = false)
        {
            Id = id;
            FullName = fullName;
            Department = department;
            Leader = leader;
            IsSupervisor = isSupervisor;
        }

        public Guid Id { get; }
        public string FullName { get; }
        public Department Department { get; }
        public User Leader { get; }
        public bool IsSupervisor { get; }

        public bool Equals(User other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Id.Equals(other.Id) && string.Equals(FullName, other.FullName);
        }

        public bool IsLeaderOf(User user)
        {
            return user.Leader.Equals(this);
        }

        public bool IsDirectorOf(User user)
        {
            return user.Department.Director.Equals(this);
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj.GetType() == GetType() &&
                   Equals((User) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Id.GetHashCode() * 397) ^
                       (FullName != null
                           ? FullName.GetHashCode()
                           : 0);
            }
        }
    }
}