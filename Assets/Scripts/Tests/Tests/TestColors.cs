using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestColors
{
    public static IEnumerable ColorTestCases
    {
        get
        {
            yield return new TestCaseData(new Color(0, 0, 0), new Color(0, 0, 0)).SetName("Black stays black");
            yield return new TestCaseData(new Color(1, 1, 1), new Color(1, 1, 1)).SetName("White stays white");
            yield return new TestCaseData(new Color(0.5f, 0.5f, 0.5f), new Color(0.5f, 0.5f, 0.5f)).SetName("Grey stays grey");
            yield return new TestCaseData(new Color(1, 0.5f, 0.3f), new Color(1, 0.4f, 0.4f)).SetName("Mean under red");
            yield return new TestCaseData(new Color(0.3f, 0.5f, 0.4f), new Color(0.4f, 0.4f, 0.4f)).SetName("Mean above red");
            yield return new TestCaseData(new Color(0.4f, 0.6f, 0.2f), new Color(0.4f, 0.4f, 0.4f)).SetName("Mean equals red");
            yield return new TestCaseData(new Color(0, 1, 0), new Color(1 / 3.0f, 1 / 3.0f, 1 / 3.0f)).SetName("Mono Other Color");            yield return new TestCaseData(new Color(0, 1, 0), new Color(1 / 3.0f, 1 / 3.0f, 1 / 3.0f)).SetName("Mono Other Color");
            yield return new TestCaseData(new Color(1.0f, 0.9f, 0.2f), new Color(1.0f, 0.55f, 0.55f)).SetName("Extra Green");
            yield return new TestCaseData(new Color(0.5f, 0.7f, 0.35f), new Color(1.55f/3.0f, 1.55f/3.0f, 1.55f/3.0f)).SetName("Extra Green");
        }
    }

    [Test, TestCaseSource(nameof(ColorTestCases))]
    public void TestColorsSimplePasses(Color input, Color expectedOutput)
    {
        Color result = Test.RedFilter(input);
        Assert.AreEqual(expectedOutput, result);
    }
}
