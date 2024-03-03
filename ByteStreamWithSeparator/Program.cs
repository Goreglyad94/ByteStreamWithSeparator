using ByteStreamWithSeparator;

IStreamWithSeparatorService streamWithSeparatorService = new StreamWithSeparatorService();

var path = Console.ReadLine();

using (FileStream fs = File.OpenRead(path))
{
    byte[] buffer = new byte[fs.Length];
    await fs.ReadAsync(buffer, 0, buffer.Length);
    var messages = streamWithSeparatorService.Separate(buffer, (byte)';');
}