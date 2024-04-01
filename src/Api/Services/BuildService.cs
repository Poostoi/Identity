namespace Api.Services;

public class BuildService:IBaseService
{
    public string Print(string row)
    {
        return "Стройка: "+ row;
    }
}