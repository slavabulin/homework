using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace NUnitTestRunner
{
    public class TestRunner
    {
        private readonly Assembly _testAssembly;

        public TestRunner(Assembly testAssembly)
        {
            _testAssembly = testAssembly;
        }

        public void RunTests()
        {
            var testTypes = GetTestTypes();

            foreach (var testType in testTypes)
            {
                RunTestType(testType);
            }
        }

        ICollection<Type> GetTestTypes()
        {
            return _testAssembly.ExportedTypes
                .Where(x => x.IsClass && x.GetCustomAttributes<TestFixtureAttribute>().Any())
                .ToList();
        }
        
        void RunTestType(Type testType)
        {
            var testMethods = GetTestMethods(testType);
            var setupMethod = GetSetupMethod(testType);
            var tearDownMethod = GetTeardownMethod(testType);

            if (!testMethods.Any())
                return;

            var instance = Activator.CreateInstance(testType);

            foreach (var testMethod in testMethods)
            {
                var testCaseAttributes = GetTestCaseAttributes(testMethod);

                var arguments = new List<object[]>();

                if(testCaseAttributes.Any())
                {
                    arguments.AddRange(testCaseAttributes.Select(x => x.Arguments));
                }
                ///---------------------------------------------------------------------------
                #region
                var testCaseSourceAttrMethods = GetTestCaseSourceAttribute(testMethod);
                if (testCaseSourceAttrMethods != null)
                {
                    foreach (TestCaseSourceAttribute testCaseSourceMethod in testCaseSourceAttrMethods)
                    {
                        var testCaseSources = 
                        _testAssembly.DefinedTypes.Select(x => x.DeclaredMembers
                        .Where(y => y.Name == testCaseSourceMethod.SourceName))
                        .ToArray();
                        
                        foreach (var testCaseSrc in testCaseSources)
                        {
                            testCaseSrc.Select(x =>
                            {
                                object[] testCaseSrcData = null;

                                switch (x.MemberType)
                                {
                                    case (MemberTypes.Field):
                                        testCaseSrcData =
                                        testType.GetRuntimeField(testCaseSourceMethod.SourceName).GetValue(x) as object[];
                                        break;
                                    case (MemberTypes.Method):
                                        testCaseSrcData =
                                        testType.GetRuntimeMethod(testCaseSourceMethod.SourceName, null).Invoke(null, null) as object[];
                                        break;
                                    case (MemberTypes.Property):
                                        testCaseSrcData =
                                        testType.GetRuntimeProperty(testCaseSourceMethod.SourceName).GetValue(null) as object[];
                                        break;
                                    default:
                                        throw new ArgumentException("unsupported test data source", nameof(x.MemberType));
                                }

                                foreach (var arg in testCaseSrcData)
                                {
                                    if (arg is IEnumerable sourceValueCases)
                                    {
                                        var listArguments = new List<object>();
                                        foreach (var sourceCase in sourceValueCases)
                                        {
                                            listArguments.Add((object)sourceCase);
                                        }
                                        arguments.Add(listArguments.ToArray());
                                    }
                                    else
                                    {
                                        arguments = Enumerable.Repeat(new object[1] { arg }, 1).ToList();
                                    }
                                }
                                return x;
                            }
                            ).ToList();
                        }
                    }
                }
                #endregion
                ///---------------------------------------------------------------------------
                foreach (var args in arguments)
                {
                    try
                    {
                        if (setupMethod != null) setupMethod.Invoke(instance, null);
                        var argsString = args == null ? string.Empty : string.Join(", ", args);
                        Console.WriteLine($"Run method {testType.Name}.{testMethod.Name}({argsString})");
                        testMethod.Invoke(instance, args);
                        Console.WriteLine("   success");
                        if (tearDownMethod != null) tearDownMethod.Invoke(instance, null);
                    }
                    catch (TargetInvocationException exception)
                    {
                        if (exception.InnerException is AssertionException)
                        {
                            Console.WriteLine(exception.InnerException.Message);
                        }
                        else
                        {
                            Console.WriteLine($"Unexpected: {exception.Message}");
                        }
                    }
                }
            }
        }

        MethodInfo GetTeardownMethod(Type testType)
        {
            return testType.GetRuntimeMethods()

                .Where(x => x.GetCustomAttributes<TearDownAttribute>().Any()).FirstOrDefault();
        }

        MethodInfo GetSetupMethod(Type testType)
        {
            return testType.GetRuntimeMethods()
                .Where(x => x.GetCustomAttributes<SetUpAttribute>().Any()).FirstOrDefault();
        }

        ICollection<MethodInfo> GetTestMethods(Type testType)
        {
            return testType.GetRuntimeMethods()
                .Where(x => x.GetCustomAttributes<TestAttribute>().Any() ||
                            x.GetCustomAttributes<TestCaseAttribute>().Any()||
                            x.GetCustomAttributes<TestCaseSourceAttribute>().Any()
                            )
                .ToList();
        }
        
        ICollection<TestCaseAttribute> GetTestCaseAttributes(MethodInfo testMethod)
        {
            return testMethod.GetCustomAttributes<TestCaseAttribute>().ToList();
        }
        ICollection<TestCaseSourceAttribute>GetTestCaseSourceAttribute(MethodInfo testMethod)
        {
            var retVal = testMethod.GetCustomAttributes<TestCaseSourceAttribute>().ToList();
            return retVal;
        }
    }
}
