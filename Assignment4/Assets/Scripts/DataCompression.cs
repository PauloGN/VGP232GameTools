using UnityEngine;
using System.IO;
using System.IO.Compression;

public static class DataCompression
{
	public static byte[] CompressData(byte[] data)
	{
		using (MemoryStream compressedStream = new MemoryStream())
		{
			using (GZipStream gzipStream = new GZipStream(compressedStream, CompressionMode.Compress))
			{
				gzipStream.Write(data, 0, data.Length);
			}

			return compressedStream.ToArray();
		}
	}

	public static byte[] DecompressData(byte[] compressedData)
	{
		using (MemoryStream compressedStream = new MemoryStream(compressedData))
		{
			using (MemoryStream decompressedStream = new MemoryStream())
			{
				using (GZipStream gzipStream = new GZipStream(compressedStream, CompressionMode.Decompress))
				{
					gzipStream.CopyTo(decompressedStream);
				}

				return decompressedStream.ToArray();
			}
		}
	}
}
