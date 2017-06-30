## Specifications for C#1.0-5.0 are in the relevant folders.

## Few interesting facts:
- With the past few releases of Visual Studio, each Visual Studio release only supported a specific version of the .NET Framework.
- For example, VS 2002 only worked with .NET 1.0, VS 2003 only worked with .NET 1.1, and VS 2005 only worked with .NET 2.0.
- VS 2008 does run side-by-side, though, with VS 2005, VS 2003, and VS 2002.
- So it is definitely possible to continue targeting .NET 1.1 projects using VS 2003 on the same machine as VS 2008.
- Unfortunately the VS 2008 multi-targeting support only works with .NET 2.0, .NET 3.0 and .NET 3.5 - and not against older versions of the framework. The reason for this is that there were significant CLR engine changes between .NET 1.x and 2.x that make debugging very difficult to support.
- In the end the costing of the work to support that was so large and impacted so many parts of Visual Studio that we weren't able to add 1.1 support in this release.
-Visual Studio 2005 only supports .NET 2.0 out-of-the-box. It can be updated to support .NET 3.0.
- **[Link to proof article](http://weblogs.asp.net/scottgu/archive/2007/06/20/vs-2008-multi-targeting-support.aspx)**
- You can't use C# 2 features without at least VS 2005
- You can't use C# 3 features without VS 2008
- You can't ask VS 2005 or VS 2008 to target .NET 1.0 or 1.1 (there's an extension for it)
- You can't force VS 2008 to restrict you to only C# 2 features, or force VS 2005 to restrict you to C# 1 features
- Each version of Visual Studio has its own project file format and will upgrade your older projects when you first load them in that version. (The differences between VS 2003 and VS 2005 were significant; the differences between VS 2005 and VS 2008 are much smaller.)
- VS 2008 has special support (in project properties) for which framework version you want to target: 2.0, 3.0 or 3.5
- You can use most C# 3 features when targeting .NET 2.0 or 3.0, but not quite all
- **[Link to csharpindepth](http://csharpindepth.com/Articles/Chapter1/Versions.aspx)**
- [.net 1.1 with 2.0 compatibility](https://msdn.microsoft.com/en-us/library/ms994381.aspx#docum_topic4)

## [Overview of .NET Framework release history](https://en.wikipedia.org/wiki/.NET_Framework#Release_history)

## [C# versions](https://en.wikipedia.org/wiki/C_Sharp_(programming_language)#Versions)

## [Visual Studio history](https://en.wikipedia.org/wiki/Microsoft_Visual_Studio#History)