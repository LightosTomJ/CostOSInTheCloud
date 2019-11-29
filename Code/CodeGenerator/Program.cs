using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace CodeGenerator
{
    class Program
    {
        private const string dllPath = @"C:\GitHub\Repos\LightosTomJ\CostOSInTheCloud\Code\Models\bin\Debug\netcoreapp2.2\Models.dll";

        static void Main(string[] args)
        {
            try
            {
                //Clear previous files
                List<string> outputPaths = new List<string>();
                outputPaths.Add(@"C:\GitHub\Repos\LightosTomJ\CostOSInTheCloud\Code\Models\local\Extensions");
                outputPaths.Add(@"C:\GitHub\Repos\LightosTomJ\CostOSInTheCloud\Code\Models\local\Interfaces");
                DeleteFiles(outputPaths);


                Assembly myAssembly = Assembly.LoadFrom(dllPath);
                var types = myAssembly.GetTypes().ToList();
                Dictionary<string, List<cType>> lTypes = new Dictionary<string, List<cType>>();
                foreach (Type type in types)
                {
                    if (type.Namespace != null && type.Namespace.Contains("Models.local.BaseClass"))
                    {
                        lTypes.Add(GetClasses(type).Key, GetClasses(type).Value);
                    }
                    else
                    { }
                }

                AddExtenionClass(lTypes, outputPaths);
                //AddInterfaceClass(type);
                //AddStandardMethods(type);
            }
            catch (Exception ae)
            { string strError = ae.Message.ToString(); }
        }

        private static KeyValuePair<string, List<cType>> GetClasses(Type t)
        {
            KeyValuePair<string, List<cType>> kv = new KeyValuePair<string, List<cType>>();
            try
            {
                List<cType> vars = new List<cType>();
                foreach(var v in t.GetProperties())
                {
                    cType c = new cType();
                    c.Name = v.Name.ToString();
                    c.Optional = IsNullable(v);
                    c.Variable = ConvertSystemTypes(v);
                    vars.Add(c);
                }

                kv = new KeyValuePair<string, List<cType>>(t.Name.ToString(), vars);
            }
            catch (Exception ae)
            { string strError = ae.Message.ToString(); }
            return kv;
        }

        private static void AddExtenionClass(Dictionary<string, List<cType>> dTypes, List<string> paths)
        {
            try
            {
                string s = "";
                //foreach(string p in paths)
                //{
                //    s = p.Substring(p.LastIndexOf("\\") + 1, p.Length - p.LastIndexOf("\\") - 1);
                //}
                s = paths.First(p => p.Substring(p.LastIndexOf("\\") + 1, p.Length - p.LastIndexOf("\\") - 1) == "Extensions");
                foreach (var d in dTypes)
                {
                    using (StreamWriter sw = new StreamWriter(s + "\\" + d.Key.ToString() + ".cs"))
                    {
                        sw.WriteLine("");
                        sw.WriteLine("namespace Models.local.Extensions");
                        sw.WriteLine("{");
                        sw.WriteLine("\tpublic static class " + d.Key);
                        sw.WriteLine("\t{ }");
                        sw.WriteLine("}");
                        sw.Close();
                    }
                }
            }
            catch (Exception ae)
            { string strError = ae.Message.ToString(); }
        }

        private static void AddInterfaceClass(Dictionary<string, List<cType>> dTypes)
        {
            try
            {
                string extPath = @"C:\GitHub\Repos\LightosTomJ\CostOSInTheCloud\Code\Models\local\Interfaces";
                DirectoryInfo diExt = new DirectoryInfo(extPath);
                if (diExt.GetFiles().ToList().Count > 0) diExt.GetFiles().ToList().ForEach(f => f.Delete());
                foreach (var d in dTypes)
                {
                    using (StreamWriter sw = new StreamWriter(extPath + "\\" + d.Key.ToString() + ".cs"))
                    {
                        foreach (var a in d.Value)
                        {

                        }
                        sw.Close();
                    }
                }
            }
            catch (Exception ae)
            { string strError = ae.Message.ToString(); }
        }

        private static string IsNullable(PropertyInfo pi)
        {
            try
            {
                if (pi.PropertyType.ToString().Contains("System.Nullable"))
                { return "?"; }
                else
                { return ""; }
            }
            catch (Exception ae)
            { string strError = ae.Message.ToString(); }
            return "";
        }
    
        private static string ConvertSystemTypes(PropertyInfo pi)
        {
            string sType = "";
            try
            {
                if (pi.PropertyType.ToString().Contains("System.Nullable"))
                {
                    return ConvertSystemTypes(pi.PropertyType.GetProperties()[1]);
                }
                else
                {
                    sType = pi.PropertyType.ToString();
                    if (sType == "System.Int64")
                    { return "long"; }
                    else if (sType == "System.Boolean")
                    { return "bool"; }
                    else if (sType == "System.Byte")
                    { return "byte"; }
                    else if (sType == "System.SByte")
                    { return "sbyte"; }
                    else if (sType == "System.Char")
                    { return "char"; }
                    else if (sType == "System.Decimal")
                    { return "decimal"; }
                    else if (sType == "System.Double")
                    { return "double"; }
                    else if (sType == "System.Single")
                    { return "float"; }
                    else if (sType == "System.Int32")
                    { return "int"; }
                    else if (sType == "System.UInt32")
                    { return "uint"; }
                    else if (sType == "System.Int64")
                    { return "long"; }
                    else if (sType == "System.UInt64")
                    { return "ulong"; }
                    else if (sType == "System.Object")
                    { return "object"; }
                    else if (sType == "System.Int16")
                    { return "short "; }
                    else if (sType == "System.UInt16")
                    { return "ushort"; }
                    else if (sType == "System.String")
                    { return "string"; }
                    else
                    { return sType; }
                }
            }
            catch (Exception ae)
            { string strError = ae.Message.ToString(); }
            return "";
        }

        private static void AddStandardMethods()
        {
            try
            {
                //Private Sub AddStandardMethods(ByRef t As TextStream, ByVal fn As String, _
                //            ByVal lVar As Variant, lVMax As Long, IsInherited As Boolean)

                //Dim v2 As Long
                //Dim strT As String

                //    'Empty constructor
                //    t.WriteLine(vbTab + vbTab + "public " + fn + "()")
                //    t.WriteLine(vbTab + vbTab + "{ }")
                //    t.WriteBlankLines 1

                //    If lVMax > 0 Then
                //        'protected
                //        t.WriteLine(vbTab + vbTab + "protected " + fn + "(" + fn + " another)")
                //        t.WriteLine(vbTab + vbTab + "{")
                //        For v2 = 1 To lVMax
                //            If InStr(1, lVar(v2, 2), "public Enums", vbTextCompare) > 0 Then
                //                strT = lVar(v2, 2) + " = another." + lVar(v2, 2) + ";"
                //                t.WriteLine(vbTab + vbTab + vbTab + lVar(v2, 2) + " = another." + lVar(v2, 2) + ";")
                //            Else
                //                t.WriteLine(vbTab + vbTab + vbTab + lVar(v2, 2) + " = another." + lVar(v2, 2) + ";")
                //            End If
                //        Next v2
                //        t.WriteLine(vbTab + vbTab + "}")
                //        t.WriteBlankLines 1


                //        'clone
                //        If IsInherited = False Then
                //            t.WriteLine(vbTab + vbTab + "public " + fn + " Clone()")
                //            t.WriteLine(vbTab + vbTab + "{")
                //            t.WriteLine(vbTab + vbTab + vbTab + "return new " + fn + "(this);")
                //            t.WriteLine(vbTab + vbTab + "}")
                //            t.WriteBlankLines 1
                //        End If


                //        'Equals
                //        t.WriteLine(vbTab + vbTab + "public override bool Equals(object obj)")
                //        t.WriteLine(vbTab + vbTab + "{")
                //        t.WriteLine(vbTab + vbTab + vbTab + "return obj is " + fn + " " + LCase(fn) + " &&")
                //        For v2 = 1 To lVMax
                //            If v2<lVMax Then
                //                t.WriteLine (vbTab +vbTab + vbTab + vbTab + vbTab + lVar(v2, 2) + " == " + LCase(fn) + "." + lVar(v2, 2) + " &&")
                //            Else
                //                t.WriteLine(vbTab + vbTab + vbTab + vbTab + vbTab + lVar(v2, 2) + " == " + LCase(fn) + "." + lVar(v2, 2) + ";")
                //            End If
                //        Next v2
                //        t.WriteLine(vbTab + vbTab + "}")
                //        t.WriteBlankLines 1


                //        'Hashcode
                //        t.WriteLine(vbTab + vbTab + "public override int GetHashCode()")
                //        t.WriteLine(vbTab + vbTab + "{")
                //        t.WriteLine(vbTab + vbTab + vbTab + "var hashCode = -166403218;")
                //        For v2 = 1 To lVMax
                //            If lVar(v2, 1) = "String" Or lVar(v2, 1) = "Int32" Or lVar(v2, 1) = "Int64" Then
                //                t.WriteLine(vbTab + vbTab + vbTab + "hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(" + lVar(v2, 2) + ");")
                //            End If
                //        Next v2
                //        t.WriteLine(vbTab + vbTab + vbTab + "return hashCode;")
                //        t.WriteLine(vbTab + vbTab + "}")
                //        t.WriteBlankLines 1

                //        'Parameter constructor
                //        t.Write(vbTab + vbTab + "public " + fn + "(")
                //        For v2 = 1 To lVMax
                //            If v2<lVMax Then
                //                t.Write (lVar(v2, 1) +" " + LCase(lVar(v2, 2)) + ", ")
                //            Else
                //                t.WriteLine(lVar(v2, 1) + " " + LCase(lVar(v2, 2)) + ")")
                //            End If
                //        Next v2
                //        t.WriteLine(vbTab + vbTab + "{")
                //        For v2 = 1 To lVMax
                //            t.WriteLine(vbTab + vbTab + vbTab + lVar(v2, 2) + " = " + LCase(lVar(v2, 2)) + ";")
                //        Next v2
                //        t.WriteLine(vbTab + vbTab + "}")
                //    End If
                //End Sub
            }
            catch (Exception ae)
            { string strError = ae.Message.ToString(); }
        }
        private static void DeleteFiles(List<string> paths)
        {
            try
            {
                foreach (string s in paths)
                {
                    DirectoryInfo diExt = new DirectoryInfo(s);
                    if (diExt.GetFiles().ToList().Count > 0) diExt.GetFiles().ToList().ForEach(f => f.Delete());
                }
            }
            catch (Exception ae)
            { string strError = ae.Message.ToString(); }
        }
    }
}