```
     _____           ______                       _   
    / ____|         |  ____|                     | |  
   | |     _____   _| |__  __  ___ __   ___  _ __| |_ 
   | |    / __\ \ / /  __| \ \/ / '_ \ / _ \| '__| __|
   | |____\__ \\ V /| |____ >  <| |_) | (_) | |  | |_ 
    \_____|___/ \_/ |______/_/\_\ .__/ \___/|_|   \__|
                                | |                   
                                |_|                   
```
⭐ Star us on GitHub — it helps!

[![repo-size](https://img.shields.io/github/languages/code-size/imacwink/CsvExport?style=flat)](https://github.com/imacwink/CsvExport/archive/main.zip) [![tag](https://img.shields.io/github/v/tag/imacwink/CsvExport)](https://github.com/imacwink/CsvExport/tags) [![license](https://img.shields.io/github/license/imacwink/CsvExport)](LICENSE) 

## Introduction
> This tool has been used in commercial game projects. The purpose of the tool is to facilitate planning and numerical configuration, and the configuration information can directly generate the corresponding code for programmers to use.

```console
macwink$ tree -C -L 2
.
├── Core
│   ├── STCsvExport
│   └── protogen
├── Example
│   ├── Assets
│   ├── Packages
│   ├── ProjectSettings
│   └── Tools
├── External
│   ├── README.md
│   └── protobuf
├── LICENSE
└── README.md

10 directories, 3 files
```

## Environment
> For mac, you need to install the mono environment, and for windows, no special environment configuration is required.

```console
macwink$ mono --version
Mono JIT compiler version 6.12.0.122 (2020-02/c621c35ffa0 Wed Feb 10 00:51:43 EST 2021)
Copyright (C) 2002-2014 Novell, Inc, Xamarin Inc and Contributors. www.mono-project.com
        TLS:           
        SIGSEGV:       altstack
        Notification:  kqueue
        Architecture:  amd64
        Disabled:      none
        Misc:          softdebug 
        Interpreter:   yes
        LLVM:          yes(610)
        Suspend:       hybrid
        GC:            sgen (concurrent by default)
```

## Usage

### Step.1
> You need to copy the two folders of the Core directory to the Example Tools directory. 

```console
'STCsvExport.exe' usage:[csvPath] [ProtoPath] [SourcePath] [BinPath]
```

### Step.2
> You need to write scripts according to the functions of the above exe（for example: usage:[csvPath] [ProtoPath] [SourcePath] [BinPath] ）, and generate corresponding files through script execution.

```sh
#!/bin/bash
mono ../../../Tools/STCsvExport/STCsvExport.exe ../../External/CsvExport/Numeric ../../../Tools/protogen ../../External/CsvExport/GenCode ../../Resources/CsvBin
mv ../../External/CsvExport/GenCode/STRes.proto ../../External/CsvExport/Proto/STRes.proto
```
### Step.3
> You only need to configure the configuration table, first build the csv table, as follows:

| ##这是一个测试 | ID | int    | 1     | 2     |
|----------|----|--------|-------|-------|
|          | 名字 | string | 谢大脚   | 赵四    |
|          | 描述 | string | 我是谢大脚 | 我不是找死 |
|          | 速度 | float  | 3.3   | 3.4   |

### Step.4
> Next you need to configure the description file for automatic code generation, as follows:

```xml
<?xml version="1.0" encoding="ascii"?>
<CsvExport class="Entity">
	<Field key="ID" value="mID" type="int32" filed = "1"/>
	<Field key="名字" value="mName" type="string" filed = "2"/>
	<Field key="描述" value="mDesc" type="string" filed = "3"/>
	<Field key="速度" value="mSpeed" type="float" filed = "4"/>
     	<!-- Note here, if your CSV is in UTF8 format, you need to add this option, otherwise it defaults to GBK. -->
	<Encode value = "UTF8" />
</CsvExport>
```
### Step.5
> You just need to execute the export.sh script on the command line.

```console
macwink$ sh export.sh
Convert file to bin: /Users/macwink/workspace/work/unity/CsvExport/Example/Assets/External/CsvExport/Numeric/Enity/Entity.csv
Createting file: /Users/macwink/workspace/work/unity/CsvExport/Example/Assets/External/CsvExport/GenCode/STCsvDataEnum.cs
Done
```
### Step.6
> The next step is how to use it through code, as follows:

```csharp
public class Simple : MonoBehaviour
{
    public Text mText = null;

    void Start()
    {
        CsvImport.LoadData<STCsv.Entity, STCsv.EntityItem>("Entity");
        string strContent = null;
        List<STCsv.EntityItem> entityItemList = CsvImport.GetData<STCsv.EntityItem>();
        if (entityItemList != null)
        {
            for (int i = 0; i < entityItemList.Count; i++)
            {
                Debug.Log("ID: " + entityItemList[i].mID + " Name: " + entityItemList[i].mName + " Desc: " + entityItemList[i].mDesc + " Speed: " + entityItemList[i].mSpeed);
                strContent += "ID: " + entityItemList[i].mID + " Name: " + entityItemList[i].mName + " Desc: " + entityItemList[i].mDesc + " Speed: " + entityItemList[i].mSpeed;
                strContent += " \n ";
            } 
        }

        mText.text = strContent;
    }
}
```

```console
ID: 1 Name: 谢大脚 Desc: 我是谢大脚 Speed: 3.3
ID: 2 Name: 赵四 Desc: 我不是找死 Speed: 3.4
```

