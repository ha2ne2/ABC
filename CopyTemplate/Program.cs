using System;
using System.IO;
using System.Text.RegularExpressions;

namespace CopyTemplate
{    
    class Program
    {
        /// <summary>
        /// テンプレートファイルのパス。
        /// とりあえず決め打ち。
        /// </summary>
        static string TemplateFilePath = Path.Combine(
            Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location),
            "Template.cs");

        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine(
@"使い方
./CopyTemplate CompetitionName ProblemName+
");
                return;
            }

            if (args.Length < 2)
            {
                Console.WriteLine("2つ以上の引数を指定してください。");
                return;
            }

            if (!File.Exists(TemplateFilePath))
            {
                Console.WriteLine(
@$"テンプレートファイルが見つかりませんでした。
ファイルが存在するか確認してください。
パス: {TemplateFilePath}");
            }

            string competitionName = args[0];
            if (Regex.IsMatch(competitionName, @"^\d"))
            {
                competitionName = "_" + competitionName;
            }

            for (int i = 1; i < args.Length; i++)
            {
                CreateFile(competitionName, args[i]);
            }
        }

        public static void CreateFile(string competitionName, string problemName)
        {
            string template = File.ReadAllText(TemplateFilePath);
            template = template.Replace("CompetitionName", competitionName);
            template = template.Replace("ProblemName", problemName);

            // 作業ディレクトリに書き込み
            string filePath = Path.Combine(
                System.Environment.CurrentDirectory,
                problemName + ".cs"
                );

            if (File.Exists(filePath))
            {
                Console.WriteLine($"{filePath}は既に存在していた為スキップしました。");
                return;
            }

            File.WriteAllText(filePath, template);
            Console.WriteLine($"{filePath}を作成しました。");
            return;
        }
    }
}
