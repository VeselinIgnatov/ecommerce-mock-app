namespace Application.Interfaces
{
    public interface IAuthenticationService
    {
        public string IssueJwtToken(Guid id, string firstName, string lastName, bool isAdmin);
        public void AddToCookies(string token);
        public bool ValidateUser();
    }
}
