using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// DIコンテナにデータベースコンテキストを登録
using MvcMovie.Data;
using Microsoft.EntityFrameworkCore;

namespace MvcMovie
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<MvcMovieContext>(optins =>
                optins.UseSqlite(Configuration.GetConnectionString("MvcMovieContext")));

            // DbContextOptions オブジェクトでメソッドが呼び出され、接続文字列の名前がコンテキストに渡されます。
            // ローカル開発の場合、ASP.NET Core 構成システムが appsettings.json ファイルから接続文字列を読み取ります。

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // ルーティングの設定
            // MVCは、着信 URLに応じてコントローラークラス(およびそれらに含まれるアクション メソッド)を呼ぶ
            // URLセグメントを指定しない場合、下記コントローラーとメソッドが既定値で実行される
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
