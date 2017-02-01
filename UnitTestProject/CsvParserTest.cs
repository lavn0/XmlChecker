using Microsoft.VisualStudio.TestTools.UnitTesting;
using XmlChecker;

namespace UnitTestProject
{
	[TestClass]
	public class CsvUnitTest
	{
		[TestMethod]
		[TestCategory("Csv")]
		public void CsvTest1()
		{
			string source = "test1,test2,test3";
			var result = CsvParser.Parse(source);

			Assert.AreEqual(1, result.Count, "レコード数が想定外です");
			Assert.AreEqual(3, result[0].Length, "フィールド数1が想定外です");
			Assert.AreEqual("test1", result[0][0], "フィールド1-1が想定外です");
			Assert.AreEqual("test2", result[0][1], "フィールド1-2が想定外です");
			Assert.AreEqual("test3", result[0][2], "フィールド1-3が想定外です");
		}

		[TestMethod]
		[TestCategory("Csv")]
		public void CsvTest2()
		{
			string source = "test1,test2,test3\r\n" + "test1,test2,test3";
			var result = CsvParser.Parse(source);

			Assert.AreEqual(2, result.Count, "レコード数が想定外です");

			Assert.AreEqual(3, result[0].Length, "フィールド数1が想定外です");
			Assert.AreEqual("test1", result[0][0], "フィールド1-1が想定外です");
			Assert.AreEqual("test2", result[0][1], "フィールド1-2が想定外です");
			Assert.AreEqual("test3", result[0][2], "フィールド1-3が想定外です");

			Assert.AreEqual(3, result[1].Length, "フィールド数2が想定外です");
			Assert.AreEqual("test1", result[1][0], "フィールド2-1が想定外です");
			Assert.AreEqual("test2", result[1][1], "フィールド2-2が想定外です");
			Assert.AreEqual("test3", result[1][2], "フィールド2-3が想定外です");
		}

		[TestMethod]
		[TestCategory("Csv")]
		public void CsvTest3()
		{
			string source = "test1,test2,test3\n" + "test1,test2,test3";
			var result = CsvParser.Parse(source);

			Assert.AreEqual(2, result.Count, "レコード数が想定外です");

			Assert.AreEqual(3, result[0].Length, "フィールド数1が想定外です");
			Assert.AreEqual("test1", result[0][0], "フィールド1-1が想定外です");
			Assert.AreEqual("test2", result[0][1], "フィールド1-2が想定外です");
			Assert.AreEqual("test3", result[0][2], "フィールド1-3が想定外です");

			Assert.AreEqual(3, result[1].Length, "フィールド数2が想定外です");
			Assert.AreEqual("test1", result[1][0], "フィールド2-1が想定外です");
			Assert.AreEqual("test2", result[1][1], "フィールド2-2が想定外です");
			Assert.AreEqual("test3", result[1][2], "フィールド2-3が想定外です");
		}

		[TestMethod]
		[TestCategory("Csv")]
		public void CsvTest4()
		{
			string source = "test1,test2,test3\r" + "test4,test5,test6";
			var result = CsvParser.Parse(source);

			Assert.AreEqual(2, result.Count, "レコード数が想定外です");

			Assert.AreEqual(3, result[0].Length, "フィールド数1が想定外です");
			Assert.AreEqual(3, result[1].Length, "フィールド数1が想定外です");
			Assert.AreEqual("test1", result[0][0], "フィールド1-1が想定外です");
			Assert.AreEqual("test2", result[0][1], "フィールド1-2が想定外です");
			Assert.AreEqual("test3", result[0][2], "フィールド1-3が想定外です");

			Assert.AreEqual("test4", result[1][0], "フィールド1-4が想定外です");
			Assert.AreEqual("test5", result[1][1], "フィールド1-5が想定外です");
			Assert.AreEqual("test6", result[1][2], "フィールド1-6が想定外です");
		}
	}
}
