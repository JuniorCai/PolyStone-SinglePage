using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyStone.Helpers
{
    public static class Utils
    {
        /// <summary>
        /// 模拟产生数字与字母的随机数
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string GetRandom(int num)
        {

            string chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";


            Random randrom = new Random((int)DateTime.Now.Ticks);

            string str = "";
            for (int i = 0; i < num; i++)
            {
                str += chars[randrom.Next(chars.Length)];
            }

            return str;

        }
    }
}
