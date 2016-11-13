# コマンドラインアプリケーション(CLI アプリ)作成用テンプレート(C#)

[MainApp.cs](src/MainApp.cs)を編集して、CLIアプリを実装してください。
チャレンジ内でファイルの作成が許可されていれば、可読性等のためにファイルを分割する事も可能です。

## コマンドライン引数の取得方法
Main関数の引数 `args` で配列として取得することができます。

```cs
public class MainApp
{
    static public void Main(string[] args)
    {
        // code to run
    }
}
```

## コマンド実行結果の標準出力への出力
標準の `Console.WriteLine` メソッド等が使用可能です。

```cs
  Console.WriteLine("hoge")
```
