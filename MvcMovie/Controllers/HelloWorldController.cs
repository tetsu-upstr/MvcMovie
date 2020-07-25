using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings;
using System.Text.Encodings.Web;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        // HTTP GETメソッド ベースURLに/HelloWorld/を追加することで呼び出される
        // GET: /HelloWorld/

        public IActionResult Index()
        {
            return View();
        }

        //
        // GET: /HelloWorld/Welcome/
        // Requires using System.Text.Encodings.Web;
        public string Welcome(string name, int ID = 1)
        {
            // HtmlEncoder.Default.Encodeで 悪意のある入力 (つまり JavaScript) からアプリを保護
            // https://localhost:{PORT}/HelloWorld/Welcome?name=Rick&numtimes=4 引数をパラメータとして渡す（モデルバインド）
            //return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");
            return HtmlEncoder.Default.Encode($"Hello {name}. ID: {ID}");
        }

    }
}
