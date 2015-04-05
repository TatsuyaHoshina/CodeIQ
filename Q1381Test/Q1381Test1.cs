using CodeIQ.Q1381;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CodeIQ.Q1381
{
	[TestClass]
	public class Q1381Test
	{
		PrivateType Ptype = new PrivateType( "CodeIQ.Q1381", "CodeIQ.Q1381.Q1381" );

		[TestMethod]
		[TestProperty( "Number", "0" )]
		public void Answer()
		{
			var testCaseList = new Dictionary<int, string>()
			{
				{123, "One Hundred Twenty Three"},
				{4567, "Four Thousand Five Hundred Sixty Seven"},
				{89012, "Eighty Nine Thousand Twelve"},
				{0, "Zero"},
				{-34, "Negative Thirty Four"},
				{-5678901, "Negative Five Million Six Hundred Seventy Eight Thousand Nine Hundred One"},
				{1111111111, "One Billion One Hundred Eleven Million One Hundred Eleven Thousand One Hundred Eleven"},
				{15674873, "Fifteen Million Six Hundred Seventy Four Thousand Eight Hundred Seventy Three"},
				{4620818, "Four Million Six Hundred Twenty Thousand Eight Hundred Eighteen"},
				{14440117, "Fourteen Million Four Hundred Forty Thousand One Hundred Seventeen"},
				{6868461, "Six Million Eight Hundred Sixty Eight Thousand Four Hundred Sixty One"},
				{14181126, "Fourteen Million One Hundred Eighty One Thousand One Hundred Twenty Six"},
				{-311541354, "Negative Three Hundred Eleven Million Five Hundred Forty One Thousand Three Hundred Fifty Four"},
				{504349000, "Five Hundred Four Million Three Hundred Forty Nine Thousand"},
				{126556530, "One Hundred Twenty Six Million Five Hundred Fifty Six Thousand Five Hundred Thirty"},
				{1301679771, "One Billion Three Hundred One Million Six Hundred Seventy Nine Thousand Seven Hundred Seventy One"},
				{-223594969, "Negative Two Hundred Twenty Three Million Five Hundred Ninety Four Thousand Nine Hundred Sixty Nine"},
				{2147483647, "Two Billion One Hundred Forty Seven Million Four Hundred Eighty Three Thousand Six Hundred Forty Seven"},
				{-2147483648, "Negative Two Billion One Hundred Forty Seven Million Four Hundred Eighty Three Thousand Six Hundred Forty Eight"},
			};

			foreach ( var item in testCaseList )
			{
				var expected = item.Value;
				var actual = Ptype.InvokeStatic( "Answer", new object[] { item.Key, } ) as string;
				Assert.AreEqual( expected, actual );
			}
		}
	}
}
