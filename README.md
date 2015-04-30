MyMins
==========

MyMins is a personal mineral collection program. You can use it to record information about every mineral you have collected. It can be seen as an alternative or addition to hand-written labels and catalogs. A digital collection makes it easier and faster to record information, look up information, gather meaningful results, organize, backup(in case of disaster), and share(on-line). A digital collection also helps to improve accuracy and legibility.

MyMins is designed with speed in mind. By default, the program has several fields that you can enter data into. If you want a more simple interface, you can hide every field shown except for the basics(specimen ID, mineral, acquired from). Using tab, enter, and arrow keys, all information can be entered with just the keyboard if desired. New specimens can reuse information already entered like Minerals and Locales/Contacts. Some fields can auto-fill as well.

If you only want to enter a locale, you can do that, but MyMins allows you to record the full acquisition history of a specimen before you came into possession of it and even after it is no longer in your possession such as being lost, destroyed, stolen, traded, or sold. Taking pictures of your specimens is particularly useful in these cases as well. It would allow you to display parts of your collection(on your computer or possibly on-line) that are in storage, or specimens that you no longer possess.

Adding information about a specimen like colors, transparency, size, rating, etc., can be useful in many ways. Size is most useful for putting images in perspective, but it also helps if your trying to figure out the best way to package/transport them.  You could search for your favorite pieces of a particular color to put on display. If looking to trade/sell minerals, you could search for multiple specimens you have of the same mineral from one locale.

---------------

Note: Version 1.0.0 does not support color, images, and search.

There is no official documentation yet but the myminsdb.rtf file has information about particular fields. The CHANGELOG lists many features that have been implemented, and TODO lists many desired features that have not been implemented yet.

Source: https://github.com/RendallTibb/mymins

Compiled with Visual Studio 2013 Community edition.

I started MyMins using Microsoft SQL express localDB, but switched to SQLite to ease installation requirements, also helping to make it XP compatible. The source is still configured to use localDB for development. Listed here are steps provided to adapt the source to SQLite.

Open MyMins in Visual Studio. Make sure nuget package "System.Data.SQLite Core (x86/x46)" is added to the project.

Uncomment "//dbValidate();" in Form1_load in Form1.cs.

Right-click project MSSQLDataSetToSQLite, go to Debug, and click Start new instance. Do this again whenever myminsDataSet.Designer.cs is generated.

Publishing with clickonce: You may need to add folders x86 and x64 to the project and add their respected net40 interop dlls from the SQLite package. Next, open mymins Properties, go to Publish, Application Files, Show all files. Set .mdf and .ldf files to Exclude. Set System.Data.SQLite.dll to Include and Click OK.  Click Prerequisites, Scroll down, un-check SQL Server 2012 Express LocalDB, and click OK.