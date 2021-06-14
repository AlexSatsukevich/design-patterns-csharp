using System;

namespace DesignPatterns.Strategy
{
    public class ImageStorage
    {
        private readonly ICompressor _compressor;
        private readonly IFilter _filter;

        public ImageStorage(ICompressor compressor, IFilter filter)
        {
            _compressor = compressor ?? throw new ArgumentNullException(nameof(compressor));
            _filter = filter ?? throw new ArgumentNullException(nameof(filter));
        }

        public void Store(string fileName)
        {
            _compressor.Compress(fileName);
            _filter.Apply(fileName);
        }
    }
}
