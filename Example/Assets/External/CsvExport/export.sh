#!/bin/bash
mono ../../../Tools/STCsvExport/STCsvExport.exe ../../External/CsvExport/Numeric ../../../Tools/protogen ../../External/CsvExport/GenCode ../../Resources/CsvBin

mv ../../External/CsvExport/GenCode/STRes.proto ../../External/CsvExport/Proto/STRes.proto
