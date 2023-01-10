using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
//https://blog.51cto.com/u_13128832/3361311
namespace WindowsFormsPrint
{
    public class TSCLIB_DLL
    {
        [DllImport("TSCLIB.dll", EntryPoint = "about")]
        public static extern int about();

        [DllImport("TSCLIB.dll", EntryPoint = "openport")]
        public static extern int openport(string printername);

        [DllImport("TSCLIB.dll", EntryPoint = "barcode")]
        public static extern int barcode(string x, string y, string type,
                    string height, string readable, string rotation,
                    string narrow, string wide, string code);

        [DllImport("TSCLIB.dll", EntryPoint = "clearbuffer")]
        public static extern int clearbuffer();

        [DllImport("TSCLIB.dll", EntryPoint = "closeport")]
        public static extern int closeport();

        [DllImport("TSCLIB.dll", EntryPoint = "downloadpcx")]
        public static extern int downloadpcx(string filename, string image_name);

        [DllImport("TSCLIB.dll", EntryPoint = "formfeed")]
        public static extern int formfeed();

        [DllImport("TSCLIB.dll", EntryPoint = "nobackfeed")]
        public static extern int nobackfeed();

        [DllImport("TSCLIB.dll", EntryPoint = "printerfont")]
        public static extern int printerfont(string x, string y, string fonttype,
                        string rotation, string xmul, string ymul,
                        string text);

        [DllImport("TSCLIB.dll", EntryPoint = "printlabel")]
        public static extern int printlabel(string set, string copy);

        [DllImport("TSCLIB.dll", EntryPoint = "sendcommand")]
        public static extern int sendcommand(string printercommand);

        [DllImport("TSCLIB.dll", EntryPoint = "setup")]
        public static extern int setup(string width, string height,
                  string speed, string density,
                  string sensor, string vertical,
                  string offset);

        [DllImport("TSCLIB.dll", EntryPoint = "windowsfont")]
        public static extern int windowsfont(int x, int y, int fontheight,
                        int rotation, int fontstyle, int fontunderline,
                        string szFaceName, string content);




        //打开打印机端口,并进行相关设置
        public static void openportExt()
        {
            TSCLIB_DLL.openport("TSC TTP-244 Pro");//找打打印机端口
            TSCLIB_DLL.sendcommand("SIZE 60 mm,30 mm");//设置条码大小
            TSCLIB_DLL.sendcommand("GAP 2 mm,0");//设置条码间隙
            TSCLIB_DLL.sendcommand("SPEED 4");//设置打印速度
            TSCLIB_DLL.sendcommand("DENSITY 7");//设置墨汁浓度
            TSCLIB_DLL.sendcommand("DERECTION 1");//设置相对起点
            TSCLIB_DLL.sendcommand("REFERENCE 3 mm,3 mm");//设置偏移边框
            TSCLIB_DLL.sendcommand("CLS");//清除记忆（每次打印新的条码时先清除上一次的打印记忆）
        }
        //打印在用车档案二维码
        public static void printVehicleCode(string str_hetong, string str_zhengjian, string str_name)
        {
            char space = (char)(32);
            string codeValue = str_hetong + space + str_zhengjian;
            TSCLIB_DLL.sendcommand("CLS");//需要清除上一次的打印记忆
            TSCLIB_DLL.sendcommand("QRCODE 260,20,H,7,A,0,M2,S7,\"" + codeValue + "\"");
            TSCLIB_DLL.windowsfont(240, 100, 24, 180, 0, 0, "黑体", str_hetong);
            TSCLIB_DLL.windowsfont(240, 140, 24, 180, 0, 0, "黑体", str_zhengjian);
            TSCLIB_DLL.windowsfont(240, 180, 24, 180, 0, 0, "黑体", str_name);
            TSCLIB_DLL.printlabel("1", "1");
        }

        //打印财务条形码
        public static void printFinanceCode(string str_Date, string str_siteNo,
            string str_siteName, string str_Num, string str_Name, int count)
        {
            for (int i = 0; i < count; i++)
            {
                char Num = (char)(i + 65);
                char space = (char)(32);
                string value = str_Date + space + str_siteNo + space + str_Num + space + Num;
                string txt = str_Date + space + str_siteName + space + str_Num + space + str_Name + space + Num;
                TSCLIB_DLL.sendcommand("CLS");//需要清除上一次的打印记忆
                TSCLIB_DLL.barcode("40", "50", "128", "160", "0", "0", "2", "2", value);
                TSCLIB_DLL.windowsfont(440, 35, 24, 180, 0, 0, "黑体", txt);
                TSCLIB_DLL.printlabel("1", "1");
            }
        }

        //关闭打印机端口
        public static void closeportExt()
        {
            TSCLIB_DLL.closeport();
        }
    }
}
