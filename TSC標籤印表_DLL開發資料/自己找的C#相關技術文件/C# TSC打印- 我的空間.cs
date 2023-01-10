//----  program.cs
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.InteropServices;
public class TSCLIB_DLL
{
    [DllImport("TSCLIB.dll", EntryPoint = "about")]
    public static extern int about();
    [DllImport("TSCLIB.dll", EntryPoint = "openport")]
    public static extern int openport(string printername);
    [DllImport("TSCLIB.dll", EntryPoint = "barcode")]
    public static extern int barcode(string x, string y, string type,string height, string readable, string rotation,string narrow, string wide, string code);
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
    public static extern int printerfont(string x, string y, string fonttype,string rotation, string xmul, string ymul,string text);
    [DllImport("TSCLIB.dll", EntryPoint = "printlabel")]
    public static extern int printlabel(string set, string copy);
    [DllImport("TSCLIB.dll", EntryPoint = "sendcommand")]
    public static extern int sendcommand(string printercommand);
    [DllImport("TSCLIB.dll", EntryPoint = "setup")]
    public static extern int setup(string width, string height,string speed, string density,string sensor, string vertical,string offset);
    [DllImport("TSCLIB.dll", EntryPoint = "windowsfont")]
    public static extern int windowsfont(int x, int y, int fontheight,int rotation, int fontstyle, int fontunderline,string szFaceName, string content);
}
namespace TSCLIB_DLL_IN_C_Sharp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
//------ 另例
[System.Runtime.InteropServices.DllImport("tsclib.dll")]
private static extern void windowsfont(int a, int b, int c, int d, int e, int f, string g, string h);
[System.Runtime.InteropServices.DllImport("tsclib.dll")]
private static extern void openport(string printername);
[System.Runtime.InteropServices.DllImport("tsclib.dll")]
private static extern void closeport();
[System.Runtime.InteropServices.DllImport("tsclib.dll")]
private static extern void sendcommand(string command);
[System.Runtime.InteropServices.DllImport("tsclib.dll")]
private static extern void setup(string width, string height, string speed, string density, string sensor, string vertical, string offset);
[System.Runtime.InteropServices.DllImport("tsclib.dll")]
private static extern void clearbuffer();
[System.Runtime.InteropServices.DllImport("tsclib.dll")]
private static extern void printlabel(string Set, string Copy);
private void button1_Click(object sender, System.EventArgs e)
{
    openport("TSC TTP-343");
    setup("100", "65", "3", "10", "0", "3", "0");
    clearbuffer();
    windowsfont(50, 30, 70, 0, 0, 0, "黑体", "索书号：");
    printlabel("1", "1");
    closeport();
}