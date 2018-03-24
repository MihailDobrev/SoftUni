namespace P01.Stream_Progress
{
    public class StreamProgressInfo
    {
        private IStreamProgress iStreamProgress;

        // If we want to stream a music file, we can't
        public StreamProgressInfo(IStreamProgress iStreamProgress)
        {
            this.iStreamProgress = iStreamProgress;
        }

        public int CalculateCurrentPercent()
        {
            return (this.iStreamProgress.BytesSent * 100) / this.iStreamProgress.Length;
        }
    }
}
