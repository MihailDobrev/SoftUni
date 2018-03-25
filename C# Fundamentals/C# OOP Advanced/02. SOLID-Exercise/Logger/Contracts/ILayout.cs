namespace Logger
{
    public interface ILayout
    {
        string FormatError(IError error);
    }
}