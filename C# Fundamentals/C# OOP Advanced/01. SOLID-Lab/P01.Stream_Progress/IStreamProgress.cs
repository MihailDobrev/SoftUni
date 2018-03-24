namespace P01.Stream_Progress
{
    public interface IStreamProgress
    {
        int BytesSent { get; }

        int Length { get; }
    }
}
