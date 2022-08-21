using System;
using Chip8Emulator.Implementation.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace Chip8Emulator.Tests.Extensions;

[TestClass]
public class UShortExtensionsTests
{
    [DataTestMethod]
    [DataRow(0, 0x4, true)]
    [DataRow(1, 0x3, true)]
    [DataRow(2, 0x2, true)]
    [DataRow(3, 0xF, true)]
    [DataRow(0, 0x0004, false)]
    [DataRow(1, 0x0030, false)]
    [DataRow(2, 0x0200, false)]
    [DataRow(3, 0xF000, false)]
    public void IntExtensionsTests_Nibble_ShouldHaveCorrectNibble(int index, int expectedValue, bool moveBytes)
    {
        //arrange
        const int inputValue = 0xF234;
        Console.WriteLine(inputValue.DebugBinary("INPUT:    ", 16));
        
        //act
        var testValue = inputValue.Nibble(index, moveBytes);

        //assert
        Console.WriteLine(testValue.DebugBinary("ACTUAL:   ", 16));
        Console.WriteLine(expectedValue.DebugBinary("EXPECTED: ", 16));
        testValue.ShouldBe(expectedValue);
    }
    
    [DataTestMethod]
    [DataRow(0x0004, true, true, true, true, false)]
    [DataRow(0xF234, true, true, true, true, true)]
    [DataRow(0xFF35, false, false, true, true, false)]
    [DataRow( 0xFF34, false, false, true, true, true)]
    [DataRow(0xF234, true, true, false, false, true)]
    [DataRow(0xF234, true, true, false, false, true)]
    public void IntExtensionsTests_IsEquals_ShouldHaveCorrectReturnValue(int compareTo, bool byte1, bool byte2, bool byte3, bool byte4, bool expectedValue)
    {
        Console.WriteLine(Convert.ToString(compareTo, 16));
        //arrange
        const int inputValue = 0xF234;
        
        //act
        var testValue = inputValue.IsEquals(compareTo, byte1, byte2, byte3, byte4);

        //assert
        testValue.ShouldBe(expectedValue);
    }
    
}