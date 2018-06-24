namespace RefactoringToPatterns.State.Common
{
    public class Department
    {
        public Department(
            string name,
            User director)
        {
            Name = name;
            Director = director;
        }

        public string Name { get; }
        public User Director { get; }
    }
}