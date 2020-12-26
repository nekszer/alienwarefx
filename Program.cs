using System;
using System.Text;
using LightFX;
using System.Threading;
using ColorHelper;
using Pastel;
using System.Drawing;
using System.Threading.Tasks;

namespace AlienColors
{
	class Program
	{
		static void Main(string[] args)
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
            Console.ReadLine();
        }

        private static async void RandomColores()
        {
            while (true)
            {
                if (Current == null)
                    Current = ColorPallete.RandomColor();
                var random = ColorPallete.RandomColor();
                var lightFX = new LightFXController();
                var result = lightFX.LFX_Initialize();
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
                await Fade(Current, random, (rgb) =>
                {
                    SetColor(rgb, lightFX);
                });
                lightFX.LFX_Release();
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

        private static void useLFXLights(LightFXController lightFX)
		{
            /*
			lightFX.LFX_Reset();
			for (int i = 0; i <= 999; i++)
			{
				lightFX.LFX_Light(LFX_Position.LFX_All, new LFX_ColorStruct());
				Console.Clear();
				Console.Write("Iteration: " + i);
				lightFX.LFX_Update();
				Thread.Sleep(1000);
			}
            */
		}
	}
}