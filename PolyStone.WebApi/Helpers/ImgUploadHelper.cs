using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace PolyStone.Helpers
{
    public class ImgUploadHelper
    {
        public string FileTypes => ConfigurationManager.AppSettings["FileTypes"];

        public string UploadPath => ConfigurationManager.AppSettings["UploadPath"];

        public int SizeLimit => int.Parse(ConfigurationManager.AppSettings["SizeLimit"]);

        public string FileServer => ConfigurationManager.AppSettings["FileServer"];

        public string WebRootPath { get; set; }

        public ImageUploadStatus UploadStatus { get; set; }


        private HttpPostedFileBase _uploadFile = null;
        private string _statusMsg = "";

        public ImgUploadHelper(HttpFileCollectionBase requestFiles, string webRootPath)
        {
            WebRootPath = webRootPath;

            if (requestFiles.Count > 0 && requestFiles[0] != null)
            {
                _uploadFile = requestFiles[0];
            }
        }

        private bool IsValid()
        {
            if (_uploadFile == null)
            {
                UploadStatus = ImageUploadStatus.NoFile;
                _statusMsg = "没有可上传的文件";
                return false;
            }

            UploadStatus = ImageUploadStatus.NoMatchTypes;
            _statusMsg = "图片类型不匹配，至支持gif,jpg,jpeg,png,bmp格式图片";
            string fileType = _uploadFile.ContentType;
            foreach (string type in FileTypes.Split(','))
            {
                if (fileType.Contains(type))
                {
                    UploadStatus = ImageUploadStatus.WaittingUpload;
                    break;
                }
            }
            if (UploadStatus == ImageUploadStatus.NoMatchTypes)
                return false;


            if (_uploadFile.ContentLength > SizeLimit)
            {
                UploadStatus = ImageUploadStatus.SizeLimitError;
                _statusMsg = "图片过大，图片大小应小于1M";
                return false;
            }

            UploadStatus = ImageUploadStatus.WaittingUpload;
            _statusMsg = "";
            return true;
        }

        public Tuple<ImageUploadStatus, string> UploadImg()
        {
            if (!IsValid())
            {
                return new Tuple<ImageUploadStatus, string>(UploadStatus, _statusMsg);
            }


            string newName = GetUploadFileNewName();
            string dirPath = $"{WebRootPath}/{UploadPath}/{DateTime.Now:yyyyMMdd}";

            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            string savePath = $"{WebRootPath}/{UploadPath}/{DateTime.Now:yyyyMMdd}/{newName}";

            try
            {
                _uploadFile.SaveAs(savePath);
                UploadStatus = ImageUploadStatus.Success;
                _statusMsg = $"{UploadPath}/{DateTime.Now:yyyyMMdd}/{newName}"; ;
            }
            catch (Exception e)
            {
                UploadStatus = ImageUploadStatus.Failed;
                _statusMsg = "保存时错误";
            }
            return new Tuple<ImageUploadStatus, string>(UploadStatus, _statusMsg);
        }

        private string GetUploadFileNewName()
        {
            Random randomPrefixProvider = new Random();
            string randomPrefix = randomPrefixProvider.Next(10000, 90000).ToString();

            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(Encoding.UTF8.GetBytes(randomPrefix));
            StringBuilder prefix = new StringBuilder();
            foreach (byte b in result)
            {
                prefix.Append(b.ToString("x2"));
            }

            return prefix.ToString() + Path.GetExtension(_uploadFile.FileName);
        }
    }

    /// <summary>
    /// 图片上传状态枚举
    /// </summary>
    public enum ImageUploadStatus
    {
        /// <summary>
        /// 等待上传
        /// </summary>
        WaittingUpload,
        /// <summary>
        /// 上传成功
        /// </summary>
        Success,
        /// <summary>
        /// 上传失败
        /// </summary>
        Failed,
        /// <summary>
        /// 上传类型不匹配
        /// </summary>
        NoMatchTypes,
        /// <summary>
        /// 文件长度超出
        /// </summary>
        SizeLimitError,
        /// <summary>
        /// 没有相关文件
        /// </summary>
        NoFile
    }
}