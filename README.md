## Specifications for C#1.0-5.0 are in the relevant folders.

## Few interesting facts:
- With the past few releases of Visual Studio, each Visual Studio release only supported a specific version of the .NET Framework.
- For example, VS 2002 only worked with .NET 1.0, VS 2003 only worked with .NET 1.1, and VS 2005 only worked with .NET 2.0.
- VS 2008 does run side-by-side, though, with VS 2005, VS 2003, and VS 2002.
- So it is definitely possible to continue targeting .NET 1.1 projects using VS 2003 on the same machine as VS 2008.
- Unfortunately the VS 2008 multi-targeting support only works with .NET 2.0, .NET 3.0 and .NET 3.5 - and not against older versions of the framework. The reason for this is that there were significant CLR engine changes between .NET 1.x and 2.x that make debugging very difficult to support.
- In the end the costing of the work to support that was so large and impacted so many parts of Visual Studio that we weren't able to add 1.1 support in this release.
-Visual Studio 2005 only supports .NET 2.0 out-of-the-box. It can be updated to support .NET 3.0.
**[Link to proof article]{http://weblogs.asp.net/scottgu/archive/2007/06/20/vs-2008-multi-targeting-support.aspx}**

## [Overview of .NET Framework release history](https://en.wikipedia.org/wiki/.NET_Framework#Release_history)

## [C# versions](https://en.wikipedia.org/wiki/C_Sharp_(programming_language)#Versions)

## [Visual Studio history] (https://en.wikipedia.org/wiki/Microsoft_Visual_Studio#History)