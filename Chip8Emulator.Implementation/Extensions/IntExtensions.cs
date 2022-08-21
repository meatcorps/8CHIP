namespace Chip8Emulator.Implementation.Extensions;

public static class IntExtensions
{
    public static bool IsEquals(this int value, int compareTo, 
        bool byte1 = true, bool byte2 = true,
        bool byte3 = true, bool byte4 = true)
    {
        if (byte1 && byte2 && byte3 && byte4)
            return value == compareTo;
        
        var isEquals = new []{false, false, false, false};

        isEquals[0] = value.Nibble(3) == compareTo.Nibble(3) || !byte1;
        isEquals[1] = value.Nibble(2) == compareTo.Nibble(2) || !byte2;
        isEquals[2] = value.Nibble(1) == compareTo.Nibble(1) || !byte3;
        isEquals[3] = value.Nibble(0) == compareTo.Nibble(0) || !byte4;
        
        return isEquals.All(x => x);
    }

    public static int Nibble(this int value, int index, bool moveBytes = false)
    {
        return (value & (0xF << index * 4)) >> index * (moveBytes ? 4 : 0);
    }

    public static string DebugBinary(this int value, string label, int size = 8)
    {
        return label + Convert.ToString(value, 2).PadLeft(size, '0');
    }
}