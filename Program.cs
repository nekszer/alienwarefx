using System;
using System.Text;
using LightFX;
using System.Threading;
using ColorHelper;
using Pastel;
using System.Drawing;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;

namespace AlienColors
{
	class Program
	{
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll")]
        static extern IntPtr GetShellWindow();

        [DllImport("user32.dll")]
        static extern IntPtr GetDesktopWindow();

        static void Main(string[] args)
		{
            TraySystem();
            Console.ReadLine();
        }

        static NotifyIcon notifyIcon;
        static IntPtr processHandle;
        static IntPtr WinShell;
        static IntPtr WinDesktop;
        static MenuItem HideMenu;
        static MenuItem RestoreMenu;

        private static void TraySystem()
        {
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = new Icon("alien.ico");
            notifyIcon.Text = "Alienware FX";
            notifyIcon.Visible = true;

            ContextMenu menu = new ContextMenu();
            HideMenu = new MenuItem("Hide", new EventHandler(Minimize_Click));
            RestoreMenu = new MenuItem("Restore", new EventHandler(Maximize_Click));

            menu.MenuItems.Add(RestoreMenu);
            menu.MenuItems.Add(HideMenu);
            menu.MenuItems.Add(new MenuItem("Exit", new EventHandler(CleanExit)));

            notifyIcon.ContextMenu = menu;

            Task.Factory.StartNew(Run);

            processHandle = Process.GetCurrentProcess().MainWindowHandle;

            WinShell = GetShellWindow();

            WinDesktop = GetDesktopWindow();

            ResizeWindow(false);

            Application.Run();
        }

        private static void Run()
        {
            try
            {
                RandomColores();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {

            }
        }

        private static void CleanExit(object sender, EventArgs e)
        {
            LightFX.LFX_Release();
            notifyIcon.Visible = false;
            Application.Exit();
            Environment.Exit(1);
        }


        static void Minimize_Click(object sender, EventArgs e)
        {
            ResizeWindow(false);
        }


        static void Maximize_Click(object sender, EventArgs e)
        {
            ResizeWindow();
        }

        static void ResizeWindow(bool Restore = true)
        {
            if (Restore)
            {
                RestoreMenu.Enabled = false;
                HideMenu.Enabled = true;
                SetParent(processHandle, WinDesktop);
            }
            else
            {
                RestoreMenu.Enabled = true;
                HideMenu.Enabled = false;
                SetParent(processHandle, WinShell);
            }
        }

        private static async void RandomColores()
        {
            LightFX = new LightFXController();
            var result = LightFX.LFX_Initialize();
            if (result != LFX_Result.LFX_Success)
            {
                switch (result)
                {
                    case LFX_Result.LFX_Error_NoDevs:
                        Console.WriteLine("There is not AlienFX device available.");
                        break;
                    default:
                        Console.WriteLine("There was an error initializing the AlienFX device.");
                        break;
                }
                return;
            }
            while (true)
            {
                if (Current == null)
                    Current = ColorPallete.RandomColor();
                var random = ColorPallete.RandomColor();
                await Fade(Current, random, (rgb) =>
                {
                    SetColor(rgb, LightFX);
                });
                Current = random;
            }
        }

        private static void SetColor(RGB rgb, LightFXController lightFX)
        {
            try
            {
                Console.Clear();
                Console.WriteLine($"{rgb.R}, {rgb.G}, {rgb.B}".Pastel(Color.FromArgb(rgb.R, rgb.G, rgb.B)));
                lightFX.LFX_Light(LFX_Position.LFX_All, new LFX_ColorStruct(255, rgb.R, rgb.G, rgb.B));
                lightFX.LFX_Update();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        private static async Task Fade(RGB rGB1, RGB rGB2, Action<RGB> fade)
        {
            var redOperation = GetByteOperation(rGB1.R, rGB2.R, 0);
            var greenOperation = GetByteOperation(rGB1.G, rGB2.G, 1);
            var blueOperation = GetByteOperation(rGB1.B, rGB2.B, 2);

            var operations = new ByteOperation[]
            {
                redOperation, greenOperation, blueOperation
            };

            foreach (var operation in operations)
            {
                for (int i = 1; i <= operation.Result; i++)
                {
                    await Task.Delay(1);
                    var value = (operation.Operation == Operation.Positive ? i : (i * -1)) + operation.Current;
                    if (operation.Position == 0)
                        rGB1.R = (byte)value;
                    else if (operation.Position == 1)
                        rGB1.G = (byte)value;
                    else
                        rGB1.B = (byte)value;
                    rGB1 = new RGB(rGB1.R, rGB1.G, rGB1.B);
                    fade?.Invoke(rGB1);
                }
            }
        }

        public static ByteOperation GetByteOperation(byte start, byte end, int position)
        {
            byte result;
            Operation operation;
            if (start > end)
            {
                result = (byte) (start - end);
                operation = Operation.Negative;
            }
            else
            {
                result = (byte) (end - start);
                operation = Operation.Positive;
            }
            return new ByteOperation(result, operation, position, start);
        }

        public class ByteOperation
        {
            public byte Current { get; }
            public byte Result { get; }
            public Operation Operation { get; }
            public int Position { get; }

            public ByteOperation(byte result, Operation operation, int position, byte current)
            {
                Result = result;
                Operation = operation;
                Position = position;
                Current = current;
            }
        }


        public enum Operation
        {
            Negative, Positive
        }

        private static RGB Current { get; set; }
        public static LightFXController LightFX { get; private set; }
    }
}