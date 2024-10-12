

public interface IPlayerSessionAPI
{
    PlayerSessionDTO RetrievePlayerSession(string playerId);
    SignInResultDTO SignIn(PlayerSessionDTO playerSession, SIGN_IN singIn);
}
