using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        // HTTP GETメソッド ベースURLに/HelloWorld/を追加することで呼び出される
        // GET: /HelloWorld/

        public IActionResult Index()
        {
            // 既定のビューファイル Indexが呼ばれる
            return View();
        }

        //
        // GET: /HelloWorld/Welcome/
        // Requires using System.Text.Encodings.Web;
        public IActionResult Welcome(string name, int numTimes = 1)
        {
            // HtmlEncoder.Default.Encodeで 悪意のある入力 (つまり JavaScript) からアプリを保護
            // https://localhost:{PORT}/HelloWorld/Welcome?name=Rick&numtimes=4 引数をパラメータとして渡す（モデルバインド）
            //return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");
            //return HtmlEncoder.Default.Encode($"Hello {name}. ID: {ID}");

            // ViewDFataディレクトリでコントローラーからビューにデータを渡す
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }

    }
}
