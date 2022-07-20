// See LICENSE.txt for license information.

using VictorBush.Ego.NefsLib.Source.Utility;
using VictorBush.Ego.NefsLib.Utility;
using Xunit;

namespace VictorBush.Ego.NefsLib.Tests.Item;

public class HashHelperTests
{
	private const int TestHashBlockSize = 0x60;

	/// <summary>
	/// Expected SHA-256: 5CDAB7B5BD21A625EDFBE2EBEF280981EF609A5420EB40B5D52538A602DA81EF.
	/// </summary>
	private static readonly byte[] TestData1 =
	{
		0x67, 0x5F, 0x64, 0x75, 0x62, 0x61, 0x69, 0x5F, 0x32, 0x5F, 0x72, 0x6F,
		0x75, 0x74, 0x65, 0x2E, 0x74, 0x70, 0x6B, 0x00, 0x69, 0x67, 0x5F, 0x64,
		0x75, 0x62, 0x61, 0x69, 0x5F, 0x32, 0x5F, 0x74, 0x72, 0x61, 0x63, 0x6B,
		0x2E, 0x74, 0x70, 0x6B, 0x00, 0x69, 0x67, 0x5F, 0x64, 0x75, 0x62, 0x61,
		0x69, 0x5F, 0x33, 0x5F, 0x72, 0x6F, 0x75, 0x74, 0x65, 0x2E, 0x74, 0x70,
		0x6B, 0x00, 0x69, 0x67, 0x5F, 0x64, 0x75, 0x62, 0x61, 0x69, 0x5F, 0x33,
		0x5F, 0x74, 0x72, 0x61, 0x63, 0x6B, 0x2E, 0x74, 0x70, 0x6B, 0x00, 0x69,
		0x67, 0x5F, 0x64, 0x75, 0x62, 0x61, 0x69, 0x5F, 0x34, 0x5F, 0x72, 0x6F,
	};

	private static readonly Sha256Hash TestData1Hash = new Sha256Hash(new byte[]
	{
			0x5C, 0xDA, 0xB7, 0xB5, 0xBD, 0x21, 0xA6, 0x25, 0xED, 0xFB, 0xE2, 0xEB,
			0xEF, 0x28, 0x09, 0x81, 0xEF, 0x60, 0x9A, 0x54, 0x20, 0xEB, 0x40, 0xB5,
			0xD5, 0x25, 0x38, 0xA6, 0x02, 0xDA, 0x81, 0xEF,
	});

	/// <summary>
	/// Expected SHA-256: 36CB4E36C819423262DA8DB8DB6E0444B0FBCBD91D0DC868D937E375A16E1F4B.
	/// </summary>
	private static readonly byte[] TestData2 =
	{
		0x75, 0x74, 0x65, 0x2E, 0x74, 0x70, 0x6B, 0x00, 0x69, 0x67, 0x5F, 0x64,
		0x75, 0x62, 0x61, 0x69, 0x5F, 0x34, 0x5F, 0x74, 0x72, 0x61, 0x63, 0x6B,
		0x2E, 0x74, 0x70, 0x6B, 0x00, 0x69, 0x67, 0x5F, 0x64, 0x75, 0x62, 0x61,
		0x69, 0x5F, 0x35, 0x5F, 0x72, 0x6F, 0x75, 0x74, 0x65, 0x2E, 0x74, 0x70,
		0x6B, 0x00, 0x69, 0x67, 0x5F, 0x64, 0x75, 0x62, 0x61, 0x69, 0x5F, 0x35,
		0x5F, 0x74, 0x72, 0x61, 0x63, 0x6B, 0x2E, 0x74, 0x70, 0x6B, 0x00, 0x69,
		0x67, 0x5F, 0x64, 0x79, 0x6E, 0x61, 0x74, 0x65, 0x63, 0x68, 0x5F, 0x30,
		0x2E, 0x74, 0x70, 0x6B, 0x00, 0x69, 0x67, 0x5F, 0x64, 0x79, 0x6E, 0x61,
	};

	private static readonly Sha256Hash TestData2Hash = new Sha256Hash(new byte[]
	{
		0x36, 0xCB, 0x4E, 0x36, 0xC8, 0x19, 0x42, 0x32, 0x62, 0xDA, 0x8D, 0xB8,
		0xDB, 0x6E, 0x04, 0x44, 0xB0, 0xFB, 0xCB, 0xD9, 0x1D, 0x0D, 0xC8, 0x68,
		0xD9, 0x37, 0xE3, 0x75, 0xA1, 0x6E, 0x1F, 0x4B,
	});

	/// <summary>
	/// Expected SHA-256: 37FE472B230C498039F3AB499C1DA278D5461AC81774191EF99256B660AE189A.
	/// </summary>
	private static readonly byte[] TestData3 =
	{
		0x74, 0x65, 0x63, 0x68, 0x5F, 0x31, 0x2E, 0x74, 0x70, 0x6B, 0x00, 0x69,
		0x67, 0x5F, 0x65, 0x61, 0x72, 0x6C, 0x73, 0x5F, 0x30, 0x2E, 0x74, 0x70,
		0x6B, 0x00, 0x69, 0x67, 0x5F, 0x65, 0x62, 0x63, 0x5F, 0x30, 0x2E, 0x74,
		0x70, 0x6B, 0x00, 0x69, 0x67, 0x5F, 0x65, 0x62, 0x63, 0x5F, 0x31, 0x2E,
		0x74, 0x70, 0x6B, 0x00, 0x69, 0x67, 0x5F, 0x65, 0x69, 0x62, 0x61, 0x63,
		0x68, 0x5F, 0x30, 0x2E, 0x74, 0x70, 0x6B, 0x00, 0x69, 0x67, 0x5F, 0x65,
		0x69, 0x62, 0x61, 0x63, 0x68, 0x5F, 0x31, 0x2E, 0x74, 0x70, 0x6B, 0x00,
		0x69, 0x67, 0x5F, 0x65, 0x6D, 0x61, 0x61, 0x72, 0x5F, 0x31, 0x2E, 0x74,
	};

	private static readonly Sha256Hash TestData3Hash = new Sha256Hash(new byte[]
	{
		0x37, 0xFE, 0x47, 0x2B, 0x23, 0x0C, 0x49, 0x80, 0x39, 0xF3, 0xAB, 0x49,
		0x9C, 0x1D, 0xA2, 0x78, 0xD5, 0x46, 0x1A, 0xC8, 0x17, 0x74, 0x19, 0x1E,
		0xF9, 0x92, 0x56, 0xB6, 0x60, 0xAE, 0x18, 0x9A,
	});

	[Fact]
	public async Task HashDataFileBlocksAsync_StreamHasExtraData_HashesReturned()
	{
		using (var testStream = new MemoryStream())
		{
			await testStream.WriteAsync(TestData3, 0, TestData1.Length);
			await testStream.WriteAsync(TestData1, 0, TestData1.Length);
			await testStream.WriteAsync(TestData2, 0, TestData1.Length);
			await testStream.WriteAsync(TestData3, 0, TestData1.Length);
			await testStream.WriteAsync(TestData1, 0, TestData1.Length);

			var hashes = await HashHelper.HashDataFileBlocksAsync(testStream, TestHashBlockSize, TestHashBlockSize, 3);
			Assert.Equal(3, hashes.Count);
			Assert.Equal(TestData1Hash, hashes[0]);
			Assert.Equal(TestData2Hash, hashes[1]);
			Assert.Equal(TestData3Hash, hashes[2]);
		}
	}

	[Fact]
	public async Task HashDataFileBlocksAsync_StreamIsExactSize_HashesReturned()
	{
		using (var testStream = new MemoryStream())
		{
			await testStream.WriteAsync(TestData1, 0, TestData1.Length);
			await testStream.WriteAsync(TestData2, 0, TestData1.Length);
			await testStream.WriteAsync(TestData3, 0, TestData1.Length);

			var hashes = await HashHelper.HashDataFileBlocksAsync(testStream, 0, TestHashBlockSize, 3);
			Assert.Equal(3, hashes.Count);
			Assert.Equal(TestData1Hash, hashes[0]);
			Assert.Equal(TestData2Hash, hashes[1]);
			Assert.Equal(TestData3Hash, hashes[2]);
		}
	}
}