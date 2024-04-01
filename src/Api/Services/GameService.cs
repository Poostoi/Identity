namespace Api.Services;

public class GameService:IBaseService
{
    public string Print(string row)
    {
        return "Игра: "+ row;
    }
}