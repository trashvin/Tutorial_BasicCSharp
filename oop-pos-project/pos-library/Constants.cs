using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos_library
{
    public static class Constants
    {
        public const string POS_TYPE_WIN_DESKTOP = "Windows Desktop POS";
        public const string POS_TYPE_LINUX_DESKTOP = "Linux Desktop POS";
        public const string POS_TYPE_WEB = "Web POS";
        public const string POS_TYPE_ANDROID_MOBILE = "Android Mobile POS";
        public const string POS_TYPE_IOS_MOBILE = "IOS Mobile POS";
        public const string POS_TYPE_DESKTOP = "Desktop POS";
        public const string POS_TYPE_MOBILE = "Mobile POS";

        public enum TranTypes
        {
            SALE,
            NO_SALE
        };
    }
}
