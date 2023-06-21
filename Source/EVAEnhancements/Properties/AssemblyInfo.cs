using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("EVAEnhancements")]
[assembly: AssemblyDescription("EVA Enhancements adds a number of features to the Kerbal Space Program EVA experience.")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany(EVAEnhancements.LegalMamboJambo.Company)]
[assembly: AssemblyProduct(EVAEnhancements.LegalMamboJambo.Product)]
[assembly: AssemblyCopyright(EVAEnhancements.LegalMamboJambo.Copyright)]
[assembly: AssemblyTrademark(EVAEnhancements.LegalMamboJambo.Trademark)]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("834b93bb-6d4b-4f78-8531-be0f1da587c5")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
[assembly: AssemblyVersion(EVAEnhancements.Version.Number)]
[assembly: AssemblyFileVersion(EVAEnhancements.Version.Number)]
[assembly: KSPAssembly("EVAEnhancements", EVAEnhancements.Version.major, EVAEnhancements.Version.minor)]

[assembly: KSPAssemblyDependency("KSPe", 2, 5)]
[assembly: KSPAssemblyDependency("KSPe.UI", 2, 5)]
