using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace ASP_ex4
{
    /// <summary>
    /// Сводное описание для PictureHandler
    /// </summary>
    public class PictureHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var o = context.Request["url"];
            byte[] img = ProcessBinaryFile(context.Server.MapPath("~/image/") + o);
            if (img != null)
            {
                context.Response.ContentType = "image/pjpeg";
                context.Response.Cache.SetCacheability(HttpCacheability.Public);
                context.Response.BufferOutput = true;
                context.Response.OutputStream.Write(img, 0, img.Length);
            }
        }
        public byte[] ProcessBinaryFile(string file)
        {
            string text = WebConfigurationManager.AppSettings["Text"];

            System.Drawing.Image img = System.Drawing.Image.FromFile(file);
            Graphics g = Graphics.FromImage(img);

            using (Graphics graphics = Graphics.FromImage(img))
            {
                using (Font arialFont = new Font("Arial", 20))
                {
                    graphics.DrawString(text, arialFont, Brushes.LightCoral, 1, 1);
                }
            }
            //Сохраняем в памяти...
            MemoryStream stream = new MemoryStream();
            img.Save(stream, ImageFormat.Jpeg);
            stream.Position = 0;
            int streamBytes = (int)stream.Length;
            byte[] fileBytes = new byte[streamBytes];
            //Читаем из памяти (как вариант)
            BinaryReader reader = new BinaryReader(stream);
            fileBytes = reader.ReadBytes(streamBytes);
            reader.Close();
            return fileBytes;
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}