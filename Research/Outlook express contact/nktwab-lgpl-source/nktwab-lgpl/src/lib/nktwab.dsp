# Microsoft Developer Studio Project File - Name="nktwab" - Package Owner=<4>
# Microsoft Developer Studio Generated Build File, Format Version 6.00
# ** DO NOT EDIT **

# TARGTYPE "Win32 (x86) Dynamic-Link Library" 0x0102

CFG=nktwab - Win32 Debug
!MESSAGE This is not a valid makefile. To build this project using NMAKE,
!MESSAGE use the Export Makefile command and run
!MESSAGE 
!MESSAGE NMAKE /f "nktwab.mak".
!MESSAGE 
!MESSAGE You can specify a configuration when running NMAKE
!MESSAGE by defining the macro CFG on the command line. For example:
!MESSAGE 
!MESSAGE NMAKE /f "nktwab.mak" CFG="nktwab - Win32 Debug"
!MESSAGE 
!MESSAGE Possible choices for configuration are:
!MESSAGE 
!MESSAGE "nktwab - Win32 Release" (based on "Win32 (x86) Dynamic-Link Library")
!MESSAGE "nktwab - Win32 Debug" (based on "Win32 (x86) Dynamic-Link Library")
!MESSAGE 

# Begin Project
# PROP AllowPerConfigDependencies 0
# PROP Scc_ProjName ""
# PROP Scc_LocalPath ""
CPP=cl.exe
MTL=midl.exe
RSC=rc.exe

!IF  "$(CFG)" == "nktwab - Win32 Release"

# PROP BASE Use_MFC 0
# PROP BASE Use_Debug_Libraries 0
# PROP BASE Output_Dir "Release"
# PROP BASE Intermediate_Dir "Release"
# PROP BASE Target_Dir ""
# PROP Use_MFC 0
# PROP Use_Debug_Libraries 0
# PROP Output_Dir "Release"
# PROP Intermediate_Dir "Release"
# PROP Ignore_Export_Lib 0
# PROP Target_Dir ""
# ADD BASE CPP /nologo /MD /W3 /GX /O1 /D "WIN32" /D "NDEBUG" /D "_WINDOWS" /Yu"std.h" /FD /c
# ADD CPP /nologo /MD /W3 /GX /O1 /D "NDEBUG" /D "WIN32" /D "_WINDOWS" /D "UNICODE" /D "_UNICODE" /Yu"std.h" /FD /c
# ADD BASE MTL /nologo /D "NDEBUG" /mktyplib203 /win32
# ADD MTL /nologo /D "NDEBUG" /mktyplib203 /win32
# ADD BASE RSC /l 0x409 /d "NDEBUG"
# ADD RSC /l 0x409 /d "NDEBUG"
BSC32=bscmake.exe
# ADD BASE BSC32 /nologo
# ADD BSC32 /nologo
LINK32=link.exe
# ADD BASE LINK32 kernel32.lib user32.lib gdi32.lib winspool.lib comdlg32.lib advapi32.lib shell32.lib ole32.lib oleaut32.lib uuid.lib odbc32.lib odbccp32.lib /nologo /subsystem:windows /dll /machine:I386 /opt:nowin98
# ADD LINK32 kernel32.lib ole32.lib advapi32.lib /nologo /subsystem:windows /dll /machine:I386 /out:"../Release/nktwab.dll"
# SUBTRACT LINK32 /pdb:none
# Begin Custom Build - Performing registration
OutDir=.\Release
TargetPath=\Documents and Settings\rodo\Desktop\NKTWAB\src.new\Release\nktwab.dll
InputPath=\Documents and Settings\rodo\Desktop\NKTWAB\src.new\Release\nktwab.dll
SOURCE="$(InputPath)"

"$(OutDir)\regsvr32.trg" : $(SOURCE) "$(INTDIR)" "$(OUTDIR)"
	regsvr32 /s /c "$(TargetPath)" 
	echo regsvr32 exec. time > "$(OutDir)\regsvr32.trg" 
	
# End Custom Build

!ELSEIF  "$(CFG)" == "nktwab - Win32 Debug"

# PROP BASE Use_MFC 0
# PROP BASE Use_Debug_Libraries 1
# PROP BASE Output_Dir "Debug"
# PROP BASE Intermediate_Dir "Debug"
# PROP BASE Target_Dir ""
# PROP Use_MFC 0
# PROP Use_Debug_Libraries 1
# PROP Output_Dir "Debug"
# PROP Intermediate_Dir "Debug"
# PROP Ignore_Export_Lib 0
# PROP Target_Dir ""
# ADD BASE CPP /nologo /MDd /W3 /Gm /GX /ZI /Od /D "WIN32" /D "_DEBUG" /D "_WINDOWS" /Yu"std.h" /FD /GZ /c
# ADD CPP /nologo /MDd /W3 /Gm /GX /ZI /Od /D "_DEBUG" /D "UNICODE" /D "WIN32" /D "_WINDOWS" /D "_UNICODE" /FR /Yu"std.h" /FD /GZ /Zm1000 /c
# ADD BASE MTL /nologo /D "_DEBUG" /mktyplib203 /win32
# ADD MTL /nologo /D "_DEBUG" /mktyplib203 /win32
# ADD BASE RSC /l 0x409 /d "_DEBUG"
# ADD RSC /l 0x409 /d "_DEBUG"
BSC32=bscmake.exe
# ADD BASE BSC32 /nologo
# ADD BSC32 /nologo
LINK32=link.exe
# ADD BASE LINK32 kernel32.lib user32.lib gdi32.lib winspool.lib comdlg32.lib advapi32.lib shell32.lib ole32.lib oleaut32.lib uuid.lib odbc32.lib odbccp32.lib /nologo /subsystem:windows /dll /debug /machine:I386 /pdbtype:sept
# ADD LINK32 kernel32.lib ole32.lib advapi32.lib /nologo /subsystem:windows /dll /debug /machine:I386 /pdbtype:sept
# Begin Custom Build - Performing registration
OutDir=.\Debug
TargetPath=.\Debug\nktwab.dll
InputPath=.\Debug\nktwab.dll
SOURCE="$(InputPath)"

"$(OutDir)\regsvr32.trg" : $(SOURCE) "$(INTDIR)" "$(OUTDIR)"
	regsvr32 /s /c "$(TargetPath)" 
	echo regsvr32 exec. time > "$(OutDir)\regsvr32.trg" 
	
# End Custom Build

!ENDIF 

# Begin Target

# Name "nktwab - Win32 Release"
# Name "nktwab - Win32 Debug"
# Begin Group "Source Files"

# PROP Default_Filter "cpp;c;cxx;rc;def;r;odl;idl;hpj;bat"
# Begin Group "com_interface"

# PROP Default_Filter ""
# Begin Source File

SOURCE=.\abstract_classes.cpp
# End Source File
# Begin Source File

SOURCE=.\contact.cpp
# End Source File
# Begin Source File

SOURCE=.\contacts.cpp
# End Source File
# Begin Source File

SOURCE=.\dll_server.cpp
# End Source File
# Begin Source File

SOURCE=.\folder.cpp
# End Source File
# Begin Source File

SOURCE=.\folders.cpp
# End Source File
# Begin Source File

SOURCE=.\group.cpp
# End Source File
# Begin Source File

SOURCE=.\groups.cpp
# End Source File
# Begin Source File

SOURCE=.\nktwab.cpp
# ADD CPP /Yu"std.h"
# End Source File
# Begin Source File

SOURCE=.\nktwab.def
# End Source File
# Begin Source File

SOURCE=.\nktwab.idl

!IF  "$(CFG)" == "nktwab - Win32 Release"

# PROP Ignore_Default_Tool 1
# Begin Custom Build - Compiling Type Library.
InputPath=.\nktwab.idl
InputName=nktwab

BuildCmds= \
	idl2h $(InputName)

"nktwablib.h" : $(SOURCE) "$(INTDIR)" "$(OUTDIR)"
   $(BuildCmds)

"nktwab.tlb" : $(SOURCE) "$(INTDIR)" "$(OUTDIR)"
   $(BuildCmds)
# End Custom Build

!ELSEIF  "$(CFG)" == "nktwab - Win32 Debug"

# PROP Ignore_Default_Tool 1
# Begin Custom Build - Compiling Type Library.
InputPath=.\nktwab.idl
InputName=nktwab

BuildCmds= \
	idl2h $(InputName)

"nktwablib.h" : $(SOURCE) "$(INTDIR)" "$(OUTDIR)"
   $(BuildCmds)

"nktwab.tlb" : $(SOURCE) "$(INTDIR)" "$(OUTDIR)"
   $(BuildCmds)
# End Custom Build

!ENDIF 

# End Source File
# Begin Source File

SOURCE=.\nktwab.rc
# End Source File
# End Group
# Begin Group "wab"

# PROP Default_Filter ""
# Begin Source File

SOURCE=.\wab_item.cpp
# End Source File
# Begin Source File

SOURCE=.\wab_mgr.cpp
# End Source File
# End Group
# Begin Source File

SOURCE=.\std.cpp
# ADD CPP /Yc"std.h"
# End Source File
# Begin Source File

SOURCE=.\WABLib.cpp
# End Source File
# End Group
# Begin Group "Resource Files"

# PROP Default_Filter "ico;cur;bmp;dlg;rc2;rct;bin;rgs;gif;jpg;jpeg;jpe"
# End Group
# Begin Group "Header Files"

# PROP Default_Filter "h;hpp;hxx;hm;inl"
# Begin Group "com_interface_h"

# PROP Default_Filter ""
# Begin Source File

SOURCE=.\abstract_classes.h
# End Source File
# Begin Source File

SOURCE=.\contact.h
# End Source File
# Begin Source File

SOURCE=.\contacts.h
# End Source File
# Begin Source File

SOURCE=.\folder.h
# End Source File
# Begin Source File

SOURCE=.\folders.h
# End Source File
# Begin Source File

SOURCE=.\group.h
# End Source File
# Begin Source File

SOURCE=.\groups.h
# End Source File
# Begin Source File

SOURCE=.\nktwab.h
# End Source File
# End Group
# Begin Group "wab_h"

# PROP Default_Filter ""
# Begin Source File

SOURCE=.\citem.h
# End Source File
# Begin Source File

SOURCE=.\cwab.h
# End Source File
# Begin Source File

SOURCE=.\wab_item.h
# End Source File
# Begin Source File

SOURCE=.\wab_mgr.h
# End Source File
# End Group
# Begin Source File

SOURCE=.\counted_ptr.h
# End Source File
# Begin Source File

SOURCE=.\resource.h
# End Source File
# Begin Source File

SOURCE=.\std.h
# End Source File
# Begin Source File

SOURCE=.\WABLib.h
# End Source File
# End Group
# Begin Source File

SOURCE=.\ReadMe.txt
# End Source File
# End Target
# End Project
