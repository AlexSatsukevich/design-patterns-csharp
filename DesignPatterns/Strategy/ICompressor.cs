namespace DesignPatterns.Strategy
{
    public interface ICompressor
    {
        // byte[] Compress(byte[] image);
        void Compress(string fileName);
    }
}