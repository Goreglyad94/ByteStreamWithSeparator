namespace ByteStreamWithSeparator
{
    public interface IStreamWithSeparatorService
    {
        List<string> Separate(byte[] source, byte separator);
    }

    public class StreamWithSeparatorService : IStreamWithSeparatorService
    {
        public List<string> Separate(byte[] source, byte separator)
        {
            var results = new List<string>();
            var index = 0;

            for (var i = 0; i < source.Length; i++)
            {
                if (source[i] == separator)
                {
                    if (i - index == 0)
                    {
                        index = i + 1;
                        continue;
                    }

                    var partOfSource = new byte[i - index];
                    
                    Array.Copy(source, index, partOfSource, 0, partOfSource.Length);
                    results.Add(System.Text.Encoding.Default.GetString(partOfSource));
                    index = i + 1;
                }
            }

            var finalPartOfSource = new byte[source.Length - index];

            if (finalPartOfSource.Length == 0)
                return results;

            Array.Copy(source, index, finalPartOfSource, 0, finalPartOfSource.Length);
            results.Add(System.Text.Encoding.Default.GetString(finalPartOfSource));

            return results;
        }
    }
}
