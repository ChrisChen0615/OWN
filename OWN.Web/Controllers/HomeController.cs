using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OWN.Service;
using OWN.Web.Models;
using System.Diagnostics;
using System.Threading.Tasks;

namespace OWN.Web.Controllers
{
    [AutoValidateAntiforgeryToken]//此項跟資安有關，只要是http method post，都要驗證token
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //讀取組態用
        private readonly IConfiguration _config;
        private readonly IAddressService _address;

        public HomeController(ILogger<HomeController> logger, IConfiguration config, IAddressService address)
        {
            _logger = logger;
            _config = config;
            _address = address;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        public async Task<IActionResult> Address()
        {
            var data = await _address.GetAll();
            return View("TestAddress", data);
        }

        ///// <summary>
        ///// 表單post提交，準備登入
        ///// </summary>
        ///// <param name="form"></param>
        ///// <returns></returns>
        //[HttpPost]
        //public async Task<IActionResult> Login(string Account, string pd, string ReturnUrl)
        //{//未登入者想進入必須登入的頁面，他會被導頁至/Home/Login，網址後面會加上QueryString:ReturnUrl(原始要求網址)


        //    //從自己的DB檢查帳&密，輸入是否正確
        //    if ((Account == "shadow" && pd == "shadow") == false)
        //    {
        //        //帳&密不正確
        //        ViewBag.errMsg = "帳號或密碼輸入錯誤";
        //        return View();//流程不往下執行
        //    }

        //    //帳密都輸入正確，ASP.net Core要多寫三行程式碼 
        //    Claim[] claims = new[] { new Claim(ClaimTypes.Name, Account) };  //取名Account，在登入後的頁面，讀取登入者的帳號會用得到，自己先記在大腦
        //    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);//Scheme必填
        //    ClaimsPrincipal principal = new ClaimsPrincipal(claimsIdentity);
        //    //執行登入，相當於以前的FormsAuthentication.SetAuthCookie()
        //    //從組態讀取登入逾時設定
        //    double loginExpireMinute = _config.GetValue<double>("LoginExpireMinute");
        //    await HttpContext.SignInAsync(principal,
        //        new AuthenticationProperties()
        //        {
        //            IsPersistent = false, //IsPersistent = false，瀏覽器關閉即刻登出
        //                                  //用戶頁面停留太久，逾期時間，在此設定的話會覆蓋Startup.cs裡的逾期設定
        //            /* ExpiresUtc = DateTime.Now.AddMinutes(loginExpireMinute) */
        //        });
        //    //加上 Url.IsLocalUrl 防止Open Redirect漏洞
        //    if (!string.IsNullOrEmpty(ReturnUrl) && Url.IsLocalUrl(ReturnUrl))
        //    {
        //        return Redirect(ReturnUrl);//導到原始要求網址
        //    }
        //    else
        //    {
        //        return RedirectToAction("ListData", "AfterLogin");//到登入後的第一頁，自行決定
        //    }

        //}
    }
}
