
using UnityEngine;

public static class BitPacker
{
	public static byte[] PackData(int size, byte[] data)
	{
		// Create a new byte array to hold the packed data
		byte[] packedData = new byte[size + 5];

		// Bit shifting and masking to pack the values into bits
		packedData[0] = (byte)((size >> 24) & 0xFF);
		packedData[1] = (byte)((size >> 16) & 0xFF);
		packedData[2] = (byte)((size >> 8) & 0xFF);
		packedData[3] = (byte)(size & 0xFF);

		data.CopyTo(packedData, 4);

		// Calculate the checksum and store it in the last byte
		byte checksum = CalculateChecksum(packedData);
		packedData[size + 4] = checksum;

		return packedData;
	}

	public static bool UnpackData(byte[] packedData, out int size, out byte[] data)
	{
		// Check the checksum
		size = (packedData[0] << 24) | (packedData[1] << 16) | (packedData[2] << 8) | packedData[3];

		data = new byte[size];
		System.Array.Copy(packedData, 4, data, 0, size);

		// Unpack the values from the packed data
		byte receivedChecksum = packedData[size + 4];
		byte calculatedChecksum = CalculateChecksum(packedData);

		bool isChecksumValid = receivedChecksum == calculatedChecksum;
		return isChecksumValid;
	}

	private static byte CalculateChecksum(byte[] data)
	{
		byte checksum = 0;

		for (int i = 0; i < data.Length - 1; i++)
		{
			checksum ^= data[i];
		}

		return checksum;
	}
}
