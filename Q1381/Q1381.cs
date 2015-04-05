using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace CodeIQ.Q1381
{
	/// <summary>
	/// CodeIQ Q1381
	/// </summary>
	class Q1381
	{
		/// <summary>
		/// プログラムのエントリポイント
		/// </summary>
		/// <param name="args"></param>
		static void Main( string[] args )
		{
			// 入力ファイルの最大数
			const int MaxCount = 100;

			try
			{
				// 入力ファイルの存在チェック
				if ( args.Length < 1 || !File.Exists( args[0] ) )
				{
					Console.WriteLine( "入力ファイルを指定してください。" );
					return;
				}

				// 入力ファイルの読み込み
				string[] lines;
				using ( var sr = new StreamReader( args[0] ) )
				{
					lines = sr.ReadToEnd().Split( Environment.NewLine.ToCharArray() );
				}

				// 整数値を英語に変換
				var query = lines
					// 先頭行（入力データ数）をスキップ
					.Skip( 1 )
					// 最大数以下の入力データを取得
					.Take( Math.Min( int.Parse( lines[0] ), MaxCount ) )
					// 入力データを変換
					.Select( strNum => Answer( int.Parse( strNum ) ) )
					;

				// 標準出力に結果を出力
				foreach ( var item in query )
				{
					Console.WriteLine( item );
				}
			}
			catch ( Exception e )
			{
				Console.WriteLine( e );
			}
		}

		/// <summary>
		/// 与えられた整数値を英語に変換します。
		/// </summary>
		/// <param name="number">整数値</param>
		/// <returns>文字列（英語）</returns>
		static string Answer( int number )
		{
			if ( number == 0 )
			{
				// 0
				return "Zero";
			}
			else
			{
				// 文字列（符号部）
				var strSign = number > 0 ? string.Empty : "Negative ";
				// 文字列（数字部）
				var strNum = GetThreeDigitGetEnumerator( Math.Abs( ( long )number ) )
					// ３桁区切りの整数を英語に変換
					.Select( threeDigits => ConvertToEnglish( threeDigits ) )
					// 単位を付加
					.Zip(
						new[] { "", "Thousand", "Million", "Billion", },
						( str, separator ) => string.Format( "{0} {1}", str, separator )
					)
					// 並び順を反転（上位から下位へ）
					.Reverse()
					// 一つの文字列にマージ
					.Aggregate( ( current, next ) => string.Format( "{0} {1}", current, next ) )
					;

				// 符号部と、連続する空白を単体に変換して先頭と末尾の空白を削除した数字部を結合して返す
				return strSign + Regex.Replace( strNum, @"\s+", " " ).Trim();
			}
		}

		/// <summary>
		/// 与えられた自然数を下位から３桁ずつに区切った列挙子を返します。
		/// </summary>
		/// <param name="number">自然数</param>
		/// <returns>列挙子（３桁区切り）</returns>
		static IEnumerable<long> GetThreeDigitGetEnumerator( long number )
		{
			if ( number <= 0 )
			{
				throw new ArgumentOutOfRangeException();
			}

			while ( number > 0 )
			{
				yield return number % 1000;
				number /= 1000;
			}
		}

		/// <summary>
		/// 与えられた正の整数を英語に変換します。
		/// </summary>
		/// <param name="number">正の整数（３桁以下）</param>
		/// <returns>文字列（英語）</returns>
		public static string ConvertToEnglish( long number )
		{
			var result = string.Empty;

			if ( number < 0 )
			{
				// 負数
				throw new ArgumentOutOfRangeException();
			}
			else if ( number < 20 )
			{
				// 0 - 19
				switch ( number )
				{
					case 1:
						result = "One";
						break;
					case 2:
						result = "Two";
						break;
					case 3:
						result = "Three";
						break;
					case 4:
						result = "Four";
						break;
					case 5:
						result = "Five";
						break;
					case 6:
						result = "Six";
						break;
					case 7:
						result = "Seven";
						break;
					case 8:
						result = "Eight";
						break;
					case 9:
						result = "Nine";
						break;
					case 10:
						result = "Ten";
						break;
					case 11:
						result = "Eleven";
						break;
					case 12:
						result = "Twelve";
						break;
					case 13:
						result = "Thirteen";
						break;
					case 14:
						result = "Fourteen";
						break;
					case 15:
						result = "Fifteen";
						break;
					case 16:
						result = "Sixteen";
						break;
					case 17:
						result = "Seventeen";
						break;
					case 18:
						result = "Eighteen";
						break;
					case 19:
						result = "Nineteen";
						break;
				}
			}
			else if ( number < 100 )
			{
				// 20 - 99
				var upper = string.Empty;
				switch ( number / 10 )
				{
					case 2:
						upper = "Twenty";
						break;
					case 3:
						upper = "Thirty";
						break;
					case 4:
						upper = "Forty";
						break;
					case 5:
						upper = "Fifty";
						break;
					case 6:
						upper = "Sixty";
						break;
					case 7:
						upper = "Seventy";
						break;
					case 8:
						upper = "Eighty";
						break;
					case 9:
						upper = "Ninety";
						break;
				}
				result = string.Format( "{0} {1}", upper, ConvertToEnglish( number % 10 ) );
			}
			else if ( number < 1000 )
			{
				// 100 - 999
				result = string.Format( "{0} {1} {2}", ConvertToEnglish( number / 100 ), "Hundred", ConvertToEnglish( number % 100 ) );
			}
			else
			{
				// 1000以上
				throw new ArgumentException();
			}

			return result;
		}
	}
}
