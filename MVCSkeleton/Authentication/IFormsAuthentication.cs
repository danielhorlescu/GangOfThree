namespace MVCSkeleton.Presentation.Authentication
{
    public interface IFormsAuthentication
    {
        void SignIn(string userName, bool createPersistentCookie);

        void SignOut();
    }
}