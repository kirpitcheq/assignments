using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

using Structs.Lib;
namespace Structs.Tests
{

    public class InchTests
    {
        //-----------------------------------------------------------------------------------
        public delegate Inch InchFuncInchMetre(Inch inch, Metre metre);
        public static Inch InchAddMetreForward(Inch inch, Metre metre) => inch + metre;
        public static Inch InchAddMetreReverse(Inch inch, Metre metre) => metre + inch;
        public static Inch InchSubMetreForward(Inch inch, Metre metre) => inch - metre;
        public static Inch InchSubMetreReverse(Inch inch, Metre metre) => metre - inch;
        public static Inch InchMulMetreForward(Inch inch, Metre metre) => inch * metre;
        public static Inch InchMulMetreReverse(Inch inch, Metre metre) => metre * inch;
        public static Inch InchDivMetreForward(Inch inch, Metre metre) => inch / metre;
        public static Inch InchDivMetreReverse(Inch inch, Metre metre) => metre / inch;
        public static IEnumerable<object[]> InchBinInchMetreEnumerable()
        {   
            yield return new object[] { 1M, 1M, (object)InchAddMetreForward, new Inch(40.370078740157480314960629921M) };
            yield return new object[] { 1M, 1M, (object)InchAddMetreReverse, new Inch(40.370078740157480314960629921M) };
            yield return new object[] { 1M, 1M, (object)InchSubMetreForward, new Inch(-38.370078740157480314960629921M) };
            yield return new object[] { 1M, 1M, (object)InchSubMetreReverse, new Inch(38.370078740157480314960629921M) };
            yield return new object[] { 1M, 1M, (object)InchMulMetreForward, new Inch(39.370078740157480314960629921M) };
            // yield return new object[] { 1M, 1M, (object)InchMulMetreReverse, new Inch() };
            // yield return new object[] { 1M, 1M, (object)InchDivMetreForward, new Inch() }; //how use many ops overloads?
            // yield return new object[] { 1M, 1M, (object)InchDivMetreReverse, new Inch() };
        }
        [Theory, MemberData(nameof(InchBinInchMetreEnumerable))]
        public void InchBinInchMetreTests(decimal first, decimal second, Func<Inch, Metre, Inch> testfunc, Inch expected)
        {
            var firstStruct = new Inch(first); 
            var secondStruct = new Metre(second);
            Inch result = testfunc(firstStruct, secondStruct);
            Assert.Equal(expected.Value, result.Value);
        }
        //-----------------------------------------------------------------------------------
        public delegate Inch InchFuncInchs(Inch first, Inch second);
        public static Inch InchsAdd(Inch first, Inch second) => first + second;
        public static Inch InchsSub(Inch first, Inch second) => first - second;
        public static Inch InchsMul(Inch first, Inch second) => first * second;
        public static Inch InchsDiv(Inch first, Inch second) => first / second;
        public static IEnumerable<object[]> InchsBinEnumerable()
        {   
            yield return new object[] { 1M, 1M, (object)InchsAdd, new Inch(2M) };
            yield return new object[] { 1M, 1M, (object)InchsSub, new Inch(0M) };
            yield return new object[] { 1M, 1M, (object)InchsMul, new Inch(1M) };
            yield return new object[] { 1M, 1M, (object)InchsDiv, new Inch(1M) };
        }
        [Theory, MemberData(nameof(InchsBinEnumerable))]
        public void InchsBinTests(decimal first, decimal second, Func<Inch, Inch, Inch> testfunc, Inch expected)
        {
            var firstStruct = new Inch(first); 
            var secondStruct = new Inch(second);
            Inch result = testfunc(firstStruct, secondStruct);
            Assert.Equal(expected.Value, result.Value);
        }
        //-----------------------------------------------------------------------------------
        public delegate bool BoolFuncInchs(Inch first, Inch second);
        public static bool InchsEq(Inch first, Inch second) => first == second;
        public static bool InchsNotEq(Inch first, Inch second) => first != second;
        public static bool InchsLess(Inch first, Inch second) => first < second;
        public static bool InchsLessOrEq(Inch first, Inch second) => first <= second;
        public static bool InchsMore(Inch first, Inch second) => first > second;
        public static bool InchsMoreOrEq(Inch first, Inch second) => first >= second;
        public static IEnumerable<object[]> InchsBoolEnumerable()
        {   
            yield return new object[] { 1M, 1M, (object)InchsEq, true };
            yield return new object[] { 1M, 1M, (object)InchsNotEq, false };
            yield return new object[] { 1M, 1M, (object)InchsLess, false };
            yield return new object[] { 1M, 1M, (object)InchsLessOrEq, true};
            yield return new object[] { 1M, 1M, (object)InchsMore, false };
            yield return new object[] { 1M, 1M, (object)InchsMoreOrEq, true};
        }
        [Theory, MemberData(nameof(InchsBoolEnumerable))]
        public void InchsBoolTests(decimal first, decimal second, Func<Inch, Inch, bool> testfunc, bool expected)
        {
            var firstStruct = new Inch(first); 
            var secondStruct = new Inch(second);
            var result = testfunc(firstStruct, secondStruct);
            Assert.Equal(expected, result);
        }
        //-----------------------------------------------------------------------------------
        delegate bool BoolFuncInchMetre(Inch inch,Metre metre);
        public static bool InchEqMetre(Inch inch, Metre metre) => inch == metre;
        public static bool InchNotEqMetre(Inch inch, Metre metre) => inch != metre;
        public static bool InchLessMetre(Inch inch, Metre metre) => inch < metre;
        public static bool InchLessOrEqMetre(Inch inch, Metre metre) => inch <= metre;
        public static bool InchMoreMetre(Inch inch, Metre metre) => inch > metre;
        public static bool InchMoreOrEqMetre(Inch inch, Metre metre) => inch >= metre;
        public static IEnumerable<object[]> BoolInchMetreEnumerable()
        {   
            yield return new object[] { 1M, 1M, (object)InchEqMetre, false };
            yield return new object[] { 1M, 1M, (object)InchNotEqMetre, true };
            yield return new object[] { 1M, 1M, (object)InchLessMetre, true };
            yield return new object[] { 1M, 1M, (object)InchLessOrEqMetre, true };
            yield return new object[] { 1M, 1M, (object)InchMoreMetre, false };
            yield return new object[] { 1M, 1M, (object)InchMoreOrEqMetre, false };
        }
        [Theory, MemberData(nameof(BoolInchMetreEnumerable))]
        public void BoolInchMetreTests(decimal first, decimal second, Func<Inch, Metre, bool> testfunc, bool expected)
        {
            var firstStruct = new Inch(first); 
            var secondStruct = new Metre(second);
            var result = testfunc(firstStruct, secondStruct);
            Assert.Equal(expected, result);
        }
        //-----------------------------------------------------------------------------------
    }
}