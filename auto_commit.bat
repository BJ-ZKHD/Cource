@echo off

set Info=
set /p Info=������汾�ύ��Ϣ��

"C:\Program Files (x86)\Git\bin\git.exe"  add .
"C:\Program Files (x86)\Git\bin\git.exe"  commit -m   %Info%
"C:\Program Files (x86)\Git\bin\git.exe"  push -u  git@git.oschina.net:ZKHD/KaiYuanFeiKongBeiFen.git

pause


