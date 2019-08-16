#!/bin/bash 

# Converts CSV chapter fiels into Podlove Simple Chapters
# Run once for any new export. 

#  usage: ./pscgen {slag}
# e.g.    ./pscgen htp001

dotnet pscgen.dll "../cdn/$1.csv" "../cdn/$1.psc"