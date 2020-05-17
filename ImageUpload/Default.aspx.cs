using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ImageUpload
{
    public partial class Default : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        [WebMethod]
        public static string SaveImg(string ImgCoding)
        {
            //对编码进行处理
            ImgCoding = DisposeCode(ImgCoding);
            //解码
            byte[] arr2 = Convert.FromBase64String(ImgCoding);
            MemoryStream stream = new MemoryStream(arr2);
            Bitmap img = new Bitmap(stream);
            Default d = new Default();
            //获取图片地址
            string FilePath = CreateImgFilePath();
            //保存图片
            img.Save(d.Server.MapPath("~/Images/" + FilePath));
            //返回路径
            return "Images/" + FilePath;
        }
        //创建文件目录地址
        public static string CreateImgFilePath() {
            //获取页面对象
            Default d = new Default();
            //创建文件目录地址
            string filename = DateTime.Now.ToString("yyyyMMdd");
            //判断地址是否存在  --这里判断不存在-创建目录
            if (!Directory.Exists(d.Server.MapPath("~/Images/"+filename)))
            {
                Directory.CreateDirectory(d.Server.MapPath("~/Images/" + filename));
            }
            //生成完整的图片路径
            filename=filename+"/"+ DateTime.Now.ToString("HHmmssffff") + ".jpg";
            //返回
            return filename;
        }
        /// <summary>
        /// 对base64编码进行处理
        /// </summary>
        /// <param name="ImgCoding">编码</param>
        /// <returns></returns>
        public static string DisposeCode(string ImgCoding)
        {
            //过滤编码头部
            ImgCoding = ImgCoding.Replace("data:image/jpeg;base64", "").Replace("data:image/png;base64", "").Replace("data:image/gif;base64", "");
            //过滤不能识别的字符
            ImgCoding = ImgCoding.Trim().Replace("%", "").Replace(",", "").Replace(" ", "+");
            if (ImgCoding.Length % 4 > 0)
            {
                ImgCoding = ImgCoding.PadRight(ImgCoding.Length + 4 - ImgCoding.Length % 4, '=');
            }
            //返回编码后的字符串
            return ImgCoding;
        }
    }
}